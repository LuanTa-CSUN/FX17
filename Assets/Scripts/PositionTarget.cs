using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class PositionTarget : ITarget
{
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }

    public PositionTarget()
    {
        Position = new Vector3();
        Rotation = new Quaternion();
    }

    public Pose[] GetTargetPose(VehicleConfiguration vehicleConfiguration, Vector3 offset = default(Vector3))
    {
        return new Pose[]
        {
            new Pose()
            {
                Position = Position + offset,
                Rotation = Rotation
            }
        };
    }
}