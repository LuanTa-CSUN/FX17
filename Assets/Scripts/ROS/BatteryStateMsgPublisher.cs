
using ROSBridgeLib.sensor_msgs;

public class BatteryStateMsgPublisher
{
    public static string GetMessageTopic()
    {
        return "mavros/battery";
    }

    public static string GetMessageType()
    {
        return BatteryStateMsg.GetMessageType();
    }
}