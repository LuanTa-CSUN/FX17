using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "VehicleConfiguration", menuName = "Vehicle Configuration")]
public class VehicleConfiguration : ScriptableObject
{
    public int Hz = 60;
    public float DefaultSpeed = .3f;
    public float SearchSpeed = .1f;
}