using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrialConfiguration", menuName = "Trial Configuration")]
public class TrialConfiguration : ScriptableObject {
    [Serializable]
    public class TrialBuildingInfo
    {
        public Vector3 Position;
        public BuildingInfo Inforamation;
    }
    
    public TrialBuildingInfo[] Buildings;
}
