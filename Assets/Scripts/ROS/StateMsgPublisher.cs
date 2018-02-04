using ROSBridgeLib.mavros_msgs;

public class StateMsgPublisher
{
    public static string GetMessageTopic()
    {
        return "mavros/state";
    }

    public static string GetMessageType()
    {
        return StateMsg.GetMessageType();
    }
}
