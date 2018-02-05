using ROSBridgeLib.sensor_msgs;
using SimpleJSON;

public class UsbCamImageRawSubscriber
{
    public delegate void CallBackHandler(ROSBridgeMsg msg);
    public static event CallBackHandler OnCallBack;

    public static string GetMessageTopic()
    {
        return "usb_cam/image_raw";
    }

    public static string GetMessageType()
    {
        return ImageMsg.GetMessageType();
    }

    public static ROSBridgeMsg ParseMessage(JSONNode msg)
    {
        return new ImageMsg(msg);
    }

    public static void CallBack(ROSBridgeMsg msg)
    {
        OnCallBack?.Invoke(msg);
    }
}