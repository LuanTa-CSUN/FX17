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
			Pose pose = vehicleController.PoseActual;
			SetPose(pose.Rotation, pose.Position);
		}
	}

	private void Update ()
	{
		if (vehicleController == null)
			return;
		
		Pose pose = vehicleController.PoseActual;
		
		//LerpPose(pose.Rotation, pose.Position);
		SetPose(pose.Rotation, pose.Position);
	}

	private void LerpPose(Quaternion rotation, Vector3 worldPos)
	{
		worldPos = GetPositionClamped(worldPos);
		transform.position = Vector3.Lerp(transform.position, worldPos, Time.deltaTime);
		transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime);
	}
	
	private void SetPose(Quaternion rotation, Vector3 worldPos)
	{
		transform.position = GetPositionClamped(worldPos);
		transform.rotation = rotation;
	}
	
	private Vector3 GetPositionClamped(Vector3 worldPos)
	{
		worldPos.y = Mathf.Clamp(worldPos.y, minimumAltitude, float.PositiveInfinity);
		return worldPos;
	}
}
