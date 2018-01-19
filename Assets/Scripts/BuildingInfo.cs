using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingInfo", menuName = "Building Info")]
public class BuildingInfo : SerializedScriptableObject
{
    public Wall North = new Wall(Vector3.zero, Wall.WallDirection.Top, WallInfo.None);
    public Wall South = new Wall(Vector3.zero, Wall.WallDirection.Bottom, WallInfo.None);
    public Wall East = new Wall(Vector3.zero, Wall.WallDirection.Left, WallInfo.None);
    public Wall West = new Wall(Vector3.zero, Wall.WallDirection.Right, WallInfo.None);
    
    public void AttachTo(Vector3 position)
    {
        North = new Wall(position, Wall.WallDirection.Top, North.Info);
        South = new Wall(position, Wall.WallDirection.Bottom, South.Info);
        East = new Wall(position, Wall.WallDirection.Left, East.Info);
        West = new Wall(position, Wall.WallDirection.Right, West.Info);
    }
}