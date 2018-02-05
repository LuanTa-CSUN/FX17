using ROSBridgeLib.mavros_msgs;
using SimpleJSON;

public class MavrosStateSubscriber
{
    public delegate void CallBackHandler(ROSBridgeMsg msg);
    public static event CallBackHandler OnCallBack;

    public static string GetMessageTopic()
    {
        return "mavros/state";
    }

    public static string GetMessageType()
    {
        return StateMsg.GetMessageType();
    }

    public static ROSBridgeMsg ParseMessage(JSONNode msg)
    {
        return new StateMsg(msg);
    }

    public static void CallBack(ROSBridgeMsg msg)
    {
        OnCallBack?.Invoke(msg);
    }
}
