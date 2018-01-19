using System;
using ROSBridgeLib.std_msgs;

public struct RosTime
{
    private static readonly DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public int Sec { get; set; }
    public int Nsec { get; set; }

    public static RosTime Now
    {
        get
        {
            TimeSpan diff = DateTime.UtcNow - unixEpoch;

            return new RosTime()
            {
                Sec = (int) diff.TotalSeconds,
                Nsec = diff.Milliseconds * 1000000
            };
        }
    }

    public static implicit operator TimeMsg(RosTime rosTime)
    {
        return new TimeMsg(rosTime.Sec, rosTime.Nsec);
    }

    public static implicit operator RosTime(TimeMsg timeMsg)
    {
        return new RosTime()
        {
            Sec = timeMsg.GetSecs(),
            Nsec = timeMsg.GetNsecs()
        };
    }
}
