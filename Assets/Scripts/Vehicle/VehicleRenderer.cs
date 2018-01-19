using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleRenderer : MonoBehaviour
{
	
	private VehicleController vehicleController;

	public VehicleController VehicleController
	{
		get { return vehicleController; }
		set { vehicleController = value; }
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (vehicleController == null)
			return;
		
		Pose pose = vehicleController.PoseActual;
		
		transform.position = pose.Position;
		transform.rotation = pose.Rotation;
	}
}
