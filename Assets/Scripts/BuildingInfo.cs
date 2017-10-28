using UnityEngine;

[CreateAssetMenu(fileName = "BuildingInfo", menuName = "Building Info")]
public class BuildingInfo : ScriptableObject
{
    public WallInfo North;
    public WallInfo South;
    public WallInfo East;
    public WallInfo West;
}