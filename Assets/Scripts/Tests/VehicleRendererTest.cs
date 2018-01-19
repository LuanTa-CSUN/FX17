using UnityEngine;

public class VehicleRendererTest : MonoBehaviour
{

	[SerializeField] private string host;

	[SerializeField] private int port;

	[SerializeField] private VehicleController vehicleController;

	[SerializeField] private GameObject vehiclePrefab;

	private VehicleRenderer vehicleRenderer;

	void Start()
	{
		vehicleController.Initialize(host, port);

		GameObject vehicleGameObject = Instantiate(vehiclePrefab);
		vehicleRenderer = vehicleGameObject.GetComponent<VehicleRenderer>();

		vehicleRenderer.VehicleController = vehicleController;
	}

	private Vector3 position;
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if (vehicleController.Armed)
			{
				vehicleController.Disarm();
			}
			else
			{
				vehicleController.Arm();
			}
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			vehicleController.EnableOffboard();
		}
		
		if (Input.GetKey(KeyCode.D)) // moves right
		{
			position.x += 0.3f;
		}
		
		if (Input.GetKey(KeyCode.A)) // left
		{
			position.x -= 0.3f;
		}

		if (Input.GetKey(KeyCode.W)) //forwards
		{
			position.z += 0.3f;
		}

		if (Input.GetKey(KeyCode.S)) // backwards
		{
			position.z -= 0.3f;
		}


		if (Input.GetKey(KeyCode.Space))
		{
			position.y += 0.2f;
		}
		else
		{
			if (position.y > 0)
			{
				position.y -= 0.1f;	
			}
		}

		vehicleController.PoseDesired.Position = position;
		vehicleController.Update();
	}
}
