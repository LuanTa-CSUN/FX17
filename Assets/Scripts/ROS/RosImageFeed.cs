using System.Collections.Generic;
using ROSBridgeLib;
using ROSBridgeLib.sensor_msgs;
using UnityEngine;

public class RosImageFeed
{
    private Queue<ImageMsg> frames;
    private int size;

    public RosImageFeed(ROSBridgeWebSocketConnection connection, int size)
    {
        this.size = size;
        frames = new Queue<ImageMsg>(this.size);
        UsbCamImageRawSubscriber.OnCallBack += UsbCamImageRawSubscriber_OnCallBack;
        connection.AddSubscriber(typeof(UsbCamImageRawSubscriber));
    }

    public IReadOnlyCollection<ImageMsg> Frames
    {
        get { return frames; }
    }

    public ImageMsg PeekOldestFrame()
    {
        return frames.Count == 0 ? null : frames.Peek();
    }

    public ImageMsg TakeOldestFrame()
    {
        return frames.Count == 0 ? null : frames.Dequeue();
    }
    
    public void UsbCamImageRawSubscriber_OnCallBack(ROSBridgeMsg msg)
    {
        if (frames.Count > size)
        {
            frames.Dequeue();
        }
        
        frames.Enqueue((ImageMsg) msg);
    }
}