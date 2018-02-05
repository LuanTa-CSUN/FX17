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
 
    private int seq;
    public Pose PoseDesired { get; set; }
    public Pose PoseActual  { get; private set; }
    public List<Pose> Mission {get; set;}

    public StateMsg State { get; private set; }
    public BatteryStateMsg BatteryState { get; private set; }
    public RosImageFeed ImageFeed { get; private set; }

    public void Initialize(string host, int port)
    {       
        connection = new ROSBridgeWebSocketConnection(host, port);
        connection.Connect();
        
        connection.AddServiceResponse(typeof(ServiceCallback));
        
        connection.AddSubscriber(typeof(MavrosLocalPositionPoseSubscriber));
        connection.AddSubscriber(typeof(MavrosStateSubscriber));
        connection.AddSubscriber(typeof(MavrosBatterySubscriber));
        
        connection.AddPublisher(typeof(MavrosSetpointPositionLocalPublisher));
        
        MavrosLocalPositionPoseSubscriber.OnCallBack += MavrosLocalPositionPoseSubscriber_OnCallBack;
        MavrosStateSubscriber.OnCallBack += MavrosStateSubscriber_OnCallback;
        MavrosBatterySubscriber.OnCallBack += MavrosBatterySubscriber_OnCallBack;
        
        ImageFeed = new RosImageFeed(connection, 10);
    }

    public void Update()
    {
        connection.Render();
        
        //TODO abstract the "fcu" string
        HeaderMsg header = new HeaderMsg(seq++, RosTime.Now, "fcu");
        PoseStampedMsg poseStampedMsg = new PoseStampedMsg(header, PoseDesired);
        connection.Publish(MavrosSetpointPositionLocalPublisher.GetMessageTopic(), poseStampedMsg);
    }

    public void ProcessArm (bool arm)
    {
        if(arm)
        {
            Arm();
        }
        else
        {
            Disarm();
        }
    }

    public void Arm()
    {
        connection.CallService("mavros/cmd/arming", "[true]"); 
    }

    public void Disarm()
    {
        connection.CallService("mavros/cmd/arming", "[false]");
    }
    
    public bool Armed
    {
        get { return State?.Armed ?? false; }
    }
    
    public void EnableOffboard()
    {
        if (Armed)
        {
            connection.CallService("mavros/set_mode", "[0, \"OFFBOARD\"]");   
        }
        else
        {
            Debug.Log("Vehicle must be armed first");
        }
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////////// subscriber callbacks
    
    private void MavrosLocalPositionPoseSubscriber_OnCallBack(ROSBridgeMsg msg)
    {
        PoseActual = ((PoseStampedMsg) msg)._pose;
    }

    private void MavrosStateSubscriber_OnCallback(ROSBridgeMsg msg)
    {
        State = (StateMsg) msg;
    }
    
    private void MavrosBatterySubscriber_OnCallBack(ROSBridgeMsg msg)
    {
        BatteryState = (BatteryStateMsg) msg;
    }

    private void UsbCamImageRawSubscriber_OnCallBack(ROSBridgeMsg msg)
    {
        
    }
    
} 