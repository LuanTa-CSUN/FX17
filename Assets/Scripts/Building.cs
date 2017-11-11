using UnityEngine;

public class Building : SerializedMonoBehaviour
{
    public BuildingInfo BuildingInfo;

    public ITarget Target;
    public GameObject NorthIndicator;
    public GameObject SouthIndicator;
    public GameObject WestIndicator;
    public GameObject EastIndicator;

    public bool CheckWest()
    {
        return BuildingInfo.West == WallInfo.Door;
    }
    public bool CheckEast()
    {
        return BuildingInfo.East == WallInfo.Door;
    }
    public bool CheckNorth()
    {
        return BuildingInfo.North == WallInfo.Door;
    }
    public bool CheckSouth()
    {
        return BuildingInfo.South == WallInfo.Door;
    }
}
