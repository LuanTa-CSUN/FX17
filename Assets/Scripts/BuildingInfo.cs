using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingInfo", menuName = "Building Info")]
public class BuildingInfo : SerializedScriptableObject
{
    public Wall North = new Wall(null, Wall.WallDirection.Top);
    public Wall South = new Wall(null, Wall.WallDirection.Bottom);
    public Wall East = new Wall(null, Wall.WallDirection.Left);
    public Wall West = new Wall(null, Wall.WallDirection.Right);
    
    public void Attach(Building building)
    {
        North = new Wall(building, Wall.WallDirection.Top);
        South = new Wall(building, Wall.WallDirection.Bottom);
        East = new Wall(building, Wall.WallDirection.Left);
        West = new Wall(building, Wall.WallDirection.Right);
    }
}