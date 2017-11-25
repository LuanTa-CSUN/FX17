using System;
using ROSBridgeLib.geometry_msgs;
using UnityEngine;

/**
 * ROS and Unity have their respective y and z axes swapped.
 * these conversions take that into account
 */

[Serializable]
public class Pose
{
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }
    
    public static implicit operator Pose(PoseMsg poseMsg)
    {
        return new Pose()
        {
            Position = poseMsg._position.ToVector3(), 
            Rotation = poseMsg._orientation.ToQuaternion()
        };
    }
    public static implicit operator PoseMsg(Pose pose)
    {
        PointMsg p = new PointMsg(
            pose.Position.x,
            pose.Position.z,
            pose.Position.y);
        
        QuaternionMsg q = new QuaternionMsg(
            pose.Rotation.x,
            pose.Rotation.z,
            pose.Rotation.y,
            pose.Rotation.w);
        
        return new PoseMsg(p, q);

    }
}
