using System;
using System.Collections.Generic;
using UnityEngine;
using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;
using ROSBridgeLib.mavros_msgs;
using ROSBridgeLib.sensor_msgs;
using ROSBridgeLib.std_msgs;

[CreateAssetMenu(fileName = "VehicleController", menuName = "VehicleController/VehicleController", order = 1)]
public class VehicleController : ScriptableObject, IArmable, INavigation
{
    private ROSBridgeWebSocketConnection connection;
    private string host;
    private int port;
 
    public Pose PoseDesired { get; set; }
    public Pose PoseActual  { get; private set; }
    public List<Pose> Mission {get; set;}

    public BatteryStateMsg BatteryState { get; private set; }
    public StateMsg State { get; private set; }
    
    private int seq;

    public void Initialize(string host, int port)
    {
        this.host = host;
        this.port = port;
        
        connection = new ROSBridgeWebSocketConnection(this.host, this.port);
        connection.Connect();
        
        connection.AddServiceResponse(typeof(ServiceCallback));
        
        connection.AddSubscriber(typeof(PoseMsgSubscriber));
        connection.AddSubscriber(typeof(StateMsgSubscriber));
        connection.AddSubscriber(typeof(BatteryStateMsgSubscriber));
        
        connection.AddPublisher(typeof(PoseMsgPublisher));
        
        PoseMsgSubscriber.OnCallBack += PoseMsgSubscriber_OnCallBack;
        StateMsgSubscriber.OnCallBack += StateMsgSubscriber_OnCallback;
        BatteryStateMsgSubscriber.OnCallBack += BatteryStateMsgSubscriber_OnCallBack;
    }

    private void PoseMsgSubscriber_OnCallBack(ROSBridgeMsg msg)
    {
        PoseActual = ((PoseStampedMsg) msg)._pose;
    }

    private void BatteryStateMsgSubscriber_OnCallBack(ROSBridgeMsg msg)
    {
        BatteryState = (BatteryStateMsg) msg;
    }

    private void StateMsgSubscriber_OnCallback(ROSBridgeMsg msg)
    {
        State = (StateMsg) msg;
    }

    public void Update()
    {    
        connection.Render();
        
        //TODO abstract the "fcu" string
        HeaderMsg header = new HeaderMsg(seq++, RosTime.Now, "fcu");
        PoseStampedMsg poseStampedMsg = new PoseStampedMsg(header, PoseDesired);
        connection.Publish(PoseMsgPublisher.GetMessageTopic(), poseStampedMsg);
    }

    public void ProcessArm (bool arm, Action<bool> callback = null)
    {
        if(arm)
        {
            Arm(callback);
        }
        else
        {
            Disarm(callback);
        }
    }

    public void Arm (Action<bool> callback = null)
    {
        Arming = true;
        connection.CallService("mavros/cmd/arming", "[true]");
        //TODO handle callback 
        if (callback != null)
        {
            
        }
    }

    public void Disarm (Action<bool> callback = null)
    {
        Disarming = true;
        connection.CallService("mavros/cmd/arming", "[false]");
        if (callback != null)
        {
            
        }
    }

    public void EnableOffboard()
    {
        connection.CallService("/mavros/set_mode", "[0, \"OFFBOARD\"]");
    }
    
    public bool Armed { get; private set; }
    public bool ProcessingArm 
    { 
        get{ return Disarming || Arming; } 
    }

    public bool Disarming { get; private set; }
    public bool Arming { get; private set; }
} 