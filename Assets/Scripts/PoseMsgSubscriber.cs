using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseMsgSubscriber
{
    public delegate void CallBackHandler(ROSBridgeMsg msg);
    public static event CallBackHandler OnCallBack;

    public new static string GetMessageTopic()
    {
        return "/mavros/local_position/pose";
    }

    public new static string GetMessageType()
    {
        return PoseStampedMsg.GetMessageType();
    }

    public new static ROSBridgeMsg ParseMessage(JSONNode msg)
    {
        return new PoseStampedMsg(msg);
    }

    public new static void CallBack(ROSBridgeMsg msg)
    {
        OnCallBack?.Invoke(msg);
        //Debug.Log("Render callback in /mavros/local_position/pose " + msg);
    }
}
