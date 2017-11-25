using System;

public struct RosTime
{
    private static readonly DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public int sec;
    public int nsec;

    public static RosTime Now
    {
        get
        {
            RosTime rosTime = new RosTime();
            TimeSpan diff = DateTime.UtcNow - unixEpoch;

            rosTime.sec = (int) diff.TotalSeconds;
            rosTime.nsec = diff.Milliseconds * 1000000;

            return rosTime;
        }
    }
}
