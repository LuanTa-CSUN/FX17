using ROSBridgeLib.geometry_msgs;
using UnityEngine;

/**
 *  ROS and unity have two different coordinate systems that need conversions:
 
 *  ROS                 Unity
 * 
 *     x   z            y   z
 *      \  |            |  /
 *       \ |            | /
 *  y_____\|            |/_____x
 *
 *  So, +x in ROS is +z in Unity
 *      +z in ROS is +y in Unity
 *      +y in ROS is -x in Unity (likewise, -y in ROS in +x in Unity)
 */
    
public static class Extensions
{
    public static PointMsg ToPointMsg(this Vector3 position)
    {
        return new PointMsg(
             position.z,
            -position.x,
             position.y);
    }

    public static Vector3 ToVector3(this PointMsg pointMsg)
    {
        return new Vector3(
            -pointMsg.GetY(),
             pointMsg.GetZ(),
             pointMsg.GetX());
    }

    public static Quaternion ToQuaternion(this QuaternionMsg quaternionMsg)
    {
        return new Quaternion(
            -quaternionMsg.GetY(),
            quaternionMsg.GetZ(),
            quaternionMsg.GetX(),
            -quaternionMsg.GetW()); // negating because ROS is right handed and Unity is left handed
    }

    public static QuaternionMsg ToQuaternionMsg(this Quaternion quaternion)
    {       
        return new QuaternionMsg(
            quaternion.z,
            -quaternion.x,
            quaternion.y,
            -quaternion.w); // negating because ROS is right handed and Unity is left handed
    }
}