using UnityEngine;

public interface ITarget
{
    Pose[] GetTargetPose(VehicleConfiguration vehicleConfiguration, Vector3? lastPosition = null, Vector3 offset = default(Vector3));
}