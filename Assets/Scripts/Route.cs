using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Route", menuName = "Route")]
public class Route : ScriptableObject
{
    Pose[] GenerateWaypoints(VehicleConfiguration vehicleConfiguration)
    {
        return new Pose[0];
    }
}