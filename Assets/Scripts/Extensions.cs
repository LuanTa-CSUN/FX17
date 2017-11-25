using ROSBridgeLib.geometry_msgs;
using UnityEngine;

/**
 * ROS and Unity have their respective y and z axes swapped.
 * these conversions take that into account
 */

public static class Extensions
{
    public static PointMsg ToPointMsg(this Vector3 position)
    {
        return new PointMsg(
            position.x,
            position.z,
            position.y);
    }

    public static Vector3 ToVector3(this PointMsg pointMsg)
    {
        return new Vector3(
            pointMsg.GetX(),
            pointMsg.GetZ(),
            pointMsg.GetY());
    }

    public static Quaternion ToQuaternion(this QuaternionMsg quaternionMsg)
    {
        return new Quaternion(
            quaternionMsg.GetX(),
            quaternionMsg.GetZ(),
            quaternionMsg.GetY(),
            quaternionMsg.GetW());
    }

    public static QuaternionMsg ToQuaternionMsg(this Quaternion quaternion)
    {
        return new QuaternionMsg(
            quaternion.x,
            quaternion.z,
            quaternion.y,
            quaternion.w);
    }
}