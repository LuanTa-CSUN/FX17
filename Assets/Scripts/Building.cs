using Sirenix.OdinInspector;
using UnityEngine;

public class Building : SerializedMonoBehaviour
{
    private BuildingInfo buildingInfo;
    public BuildingInfo BuildingInfo
    {
        get
        {
            return buildingInfo;
        }
        set
        {
            buildingInfo = Instantiate(value);
            buildingInfo.Attach(this);
        }
    }

    public GameObject NorthIndicator;
    public GameObject SouthIndicator;
    public GameObject WestIndicator;
    public GameObject EastIndicator;
    
    public bool CheckWest()
    {
        return BuildingInfo.West.Info == WallInfo.Door;
    }
    public bool CheckEast()
    {
        return BuildingInfo.East.Info == WallInfo.Door;
    }
    public bool CheckNorth()
    {
        return BuildingInfo.North.Info == WallInfo.Door;
    }
    public bool CheckSouth()
    {
        return BuildingInfo.South.Info == WallInfo.Door;
    }
}
