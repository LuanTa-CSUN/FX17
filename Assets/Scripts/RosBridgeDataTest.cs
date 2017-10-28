using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;
using ROSBridgeLib.std_msgs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PoseMsg = ROSBridgeLib.geometry_msgs.PoseMsg;

public class RosBridgeDataTest : MonoBehaviour {
    [SerializeField]
    private ROSBridgeWebSocketConnection connection;
    [SerializeField]
    private string host;
    [SerializeField]
    private int port;


    public GameObject drone;
    PoseStampedMsg pose;

    // Use this for initialization
    void Start () {
        connection = new ROSBridgeWebSocketConnection(host, port);
        connection.Connect();
        connection.AddServiceResponse(typeof(ServiceCallback));
        connection.AddSubscriber(typeof(PoseMsgSubscriber));
        PoseMsgSubscriber.OnCallBack += PoseMsgSubscriber_OnCallBack;

        connection.AddPublisher(typeof(PoseMsgPublisher));
    }

    private void PoseMsgSubscriber_OnCallBack(ROSBridgeMsg msg)
    {
        pose = (PoseStampedMsg)msg;
        drone.transform.rotation = new Quaternion(pose._pose._orientation.GetX(), pose._pose._orientation.GetZ(), pose._pose._orientation.GetY(), pose._pose._orientation.GetW());
        drone.transform.position = new Vector3(pose._pose._position.GetX(), pose._pose._position.GetZ(), pose._pose._position.GetY());
        sec = pose._header.GetTimeMsg().GetSecs();
        nsec = pose._header.GetTimeMsg().GetNsecs();

    }

    private void OnDestroy()
    {
        connection.Disconnect();
    }

    public int seq = 0;
    public int sec;
    public int nsec;
    public int secondsSinceEpoch;
    public int nSeconds;
    public long unix;
    // Update is called once per frame
    void Update ()
    {
        unix = DateTimeOffset.Now.ToUnixTimeSeconds();
        TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
        secondsSinceEpoch = (int)t.TotalSeconds;
        nSeconds = t.Milliseconds * 10000;
        connection.Render();
        float xOffset = 0;
        if(Input.GetKeyDown(KeyCode.Return))
        {
            connection.CallService("mavros/cmd/arming", "[true]");
            connection.CallService("/mavros/set_mode", "[0, \"OFFBOARD\"]");
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            connection.CallService("mavros/cmd/arming", "[false]");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xOffset--;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xOffset++;
        }
        connection.Publish(
             PoseMsgPublisher.GetMessageTopic(),
             new PoseStampedMsg(
             new HeaderMsg(
                 seq,
                 new TimeMsg(
                     pose._header.GetTimeMsg().GetSecs(),//secondsSinceEpoch,
                     pose._header.GetTimeMsg().GetNsecs() + 10),//nSeconds),
                 pose._header.GetFrameId()),//"fcu"),
             new PoseMsg(
                 new PointMsg(pose._pose._position.GetX() + xOffset, pose._pose._position.GetY(), 2),//pose._pose._position.GetZ()),
                 pose._pose._orientation
                 )
             ));
        seq++;
    }
}
