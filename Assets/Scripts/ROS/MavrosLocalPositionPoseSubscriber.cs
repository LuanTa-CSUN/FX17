using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MavrosLocalPositionPoseSubscriber
{
    public delegate void CallBackHandler(ROSBridgeMsg msg);
    public static event CallBackHandler OnCallBack;

    public static string GetMessageTopic()
    {
        return "mavros/local_position/pose";
    }

    public static string GetMessageType()
    {
        return PoseStampedMsg.GetMessageType();
    }

    public static ROSBridgeMsg ParseMessage(JSONNode msg)
    {
        return new PoseStampedMsg(msg);
    }

    public static void CallBack(ROSBridgeMsg msg)
    {
        OnCallBack?.Invoke(msg);
    }
}
