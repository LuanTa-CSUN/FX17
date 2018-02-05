using ROSBridgeLib.sensor_msgs;
using SimpleJSON;

public class MavrosBatterySubscriber
{
    public delegate void CallBackHandler(ROSBridgeMsg msg);
    public static event CallBackHandler OnCallBack;

    public static string GetMessageTopic()
    {
        return "mavros/battery";
    }

    public static string GetMessageType()
    {
        return BatteryStateMsg.GetMessageType();
    }

    public static ROSBridgeMsg ParseMessage(JSONNode msg)
    {
        return new BatteryStateMsg(msg);
    }

    public static void CallBack(ROSBridgeMsg msg)
    {
        OnCallBack?.Invoke(msg);
    }
}