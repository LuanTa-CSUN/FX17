using System;
using System.Collections.Generic;
using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;
using ROSBridgeLib.std_msgs;
using UnityEngine;

public class VehicleController : ScriptableObject, IArmable, INavigation
{
    [SerializeField]
    private ROSBridgeWebSocketConnection connection;
    [SerializeField]
    private string host;
    [SerializeField]
    private int port;
 
    public Pose PoseDesired { get; set; }
    public Pose PoseActual  { get; private set; }

    private int seq;
    
    public List<Pose> Mission {get; set;}

    public VehicleController()
    {
        connection = new ROSBridgeWebSocketConnection(host, port);
        connection.Connect();
        connection.AddServiceResponse(typeof(ServiceCallback));
        connection.AddSubscriber(typeof(PoseMsgSubscriber));
        PoseMsgSubscriber.OnCallBack += PoseMsgSubscriber_OnCallBack;
    }

    private void PoseMsgSubscriber_OnCallBack(ROSBridgeMsg msg)
    {
        PoseActual = ((PoseStampedMsg) msg)._pose;
    }

    public void Update()
    {    
        //TODO abstract the "fcu" string
        HeaderMsg header = new HeaderMsg(seq++, RosTime.Now, "fcu");
        PoseStampedMsg poseStampedMsg = new PoseStampedMsg(header, PoseDesired);
        
        connection.Publish(PoseMsgPublisher.GetMessageTopic(), poseStampedMsg);
        connection.Render();
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
        //if(callback)
    }

    public void Disarm (Action<bool> callback = null)
    {
        Disarming = true;
        connection.CallService("mavros/cmd/arming", "[false]");
    }

    public bool Armed { get; private set; }
    public bool ProcessingArm 
    { 
        get
        {
            return Disarming || Arming;
        } 
    }

    public bool Disarming { get; private set; }
    public bool Arming { get; private set; }
} 