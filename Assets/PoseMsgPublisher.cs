using ROSBridgeLib.geometry_msgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PoseMsgPublisher
{
    public static string GetMessageTopic()
    {
        return "/mavros/setpoint_position/local";
    }

    public static string GetMessageType()
    {
        return PoseStampedMsg.GetMessageType();
    }
}
