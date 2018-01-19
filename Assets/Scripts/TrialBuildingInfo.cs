using Sirenix.OdinInspector;
using System;
using UnityEngine;

[Serializable]
public class TrialBuildingInfo
{
    public Vector3 Position;
    private BuildingInfo information;
    [ShowInInspector]
    public BuildingInfo Information
    {
        get
        {
            return information;
        }
        set
        {
            if (!value)
            {
                information = null;
                return;
            }
            information = ScriptableObject.Instantiate(value);
        }
    }
}