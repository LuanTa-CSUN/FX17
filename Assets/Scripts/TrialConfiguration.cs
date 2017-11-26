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
        private BuildingInfo information;
        public BuildingInfo Information
        {
            get
            {
                return information;
            }
            set
            {
                information = Instantiate(value);
            }
        }
    }

    public VehicleConfiguration VehicleConfiguration;
    
    public TrialBuildingInfo[] Buildings;
}
