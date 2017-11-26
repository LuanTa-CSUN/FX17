using UnityEngine;

public interface ITarget
{
    Pose[] GetTargetPose(VehicleConfiguration vehicleConfiguration, Vector3 offset = default(Vector3));
}