using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrialConfiguration", menuName = "Trial Configuration")]
public class TrialConfiguration : ScriptableObject {
    public VehicleConfiguration VehicleConfiguration;
    
    public TrialBuildingInfo[] Buildings;

    public GameObject BuildingPrefab;

    [SerializeField] private Material machineTrailMat;
    public Material MachineTrailMat{ get{ return machineTrailMat; } }

    [SerializeField] private Material humanTrailMat;
    public Material HumanTrailMat{ get{ return humanTrailMat; } }

    [SerializeField] [Range(.1f, .5f)] private float trailThickness;
    public float TrailThickness { get { return trailThickness; } }

    [Button("GenerateTrial")]
    public GameObject GenerateTrial()
    {
        GameObject trialObject = new GameObject("Trial");
        foreach (var building in Buildings)
        {
            GameObject.Instantiate(BuildingPrefab, building.Position, Quaternion.identity, trialObject.transform);
        }
        return trialObject;
    }
}
