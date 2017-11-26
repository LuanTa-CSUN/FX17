using System;
using ROSBridgeLib;
using UnityEditor;
using UnityEngine;public class RosBridgeVehicleTest : MonoBehaviour
{
    [SerializeField]
    private ROSBridgeWebSocketConnection connection;
    [SerializeField]
    private string host;
    [SerializeField]
    private int port;

    public GameObject drone;
    
    [SerializeField]
    private VehicleController vehicle;

    private Vector3 pos;
    
    void Start()
    {
        vehicle.Initialize();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if (vehicle.Armed)
            {
                vehicle.Disarm();
            }
            else
            {
                vehicle.Arm();
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            vehicle.EnableOffboard();
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= 0.5f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += 0.5f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.z += 0.5f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.z -= 0.5f;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            pos.y += 0.5f;
        }
        else if(pos.y > 0)
        {
            pos.y -= 0.25f;
        }

        vehicle.PoseDesired.Position = pos;
        //vehicle.PoseDesired.Rotation = vehicle.PoseActual.Rotation;
        vehicle.Update();
        drone.transform.position = vehicle.PoseActual.Position;
        //drone.transform.rotation = vehicle.PoseActual.Rotation;
    }

    void OnGUI()
    {
        int height = 0;
        GUI.Label(new Rect(0,0,500, 25), pos.ToString());
        GUI.Label(new Rect(0,25,500, 25), vehicle.PoseDesired.Position.ToString());
        GUI.Label(new Rect(0,50,500, 25), vehicle.PoseActual.Position.ToString());
    }

    void OnDestroy()
    {
        
    }
}