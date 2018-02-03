using UnityEngine;

public class VehicleRenderer : MonoBehaviour
{
	[SerializeField]
	private float minimumAltitude;
	
	private VehicleController vehicleController;
	public VehicleController VehicleController
	{
		get { return vehicleController; }
		set
		{
			vehicleController = value;
			SetPose(vehicleController.PoseActual);
		}
	}

	private void Update ()
	{
		if (vehicleController == null)
			return;
		
		//LerpPose(pose.Rotation, pose.Position);
		SetPose(vehicleController.PoseActual);
	}

	private void LerpPose(Pose pose)
	{
		Vector3 worldPos = GetPositionClamped(pose.Position);
		transform.position = Vector3.Lerp(transform.position, worldPos, Time.deltaTime);
		transform.rotation = Quaternion.Lerp(transform.rotation, pose.Rotation, Time.deltaTime);
	}
	
	private void SetPose(Pose pose)
	{
		transform.position = GetPositionClamped(pose.Position);
		transform.rotation = pose.Rotation;
	}
	
	private Vector3 GetPositionClamped(Vector3 worldPos)
	{
		worldPos.y = Mathf.Clamp(worldPos.y, minimumAltitude, float.PositiveInfinity);
		return worldPos;
	}
}
