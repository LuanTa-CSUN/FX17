using UnityEngine;

public class Wall : ITarget
{
    public enum WallDirection
    {
        Bottom = -2,
        Right = -1,
        Left = 1,
        Top = 2
    }

    public WallInfo Info = WallInfo.None;

    private WallDirection direction;

    public float Length;

    private Building building;

    public Vector3 buildingPosition;

    public Wall(Building building, WallDirection direction)
    {
        this.building = building;
        this.direction = direction;
    }

    public override string ToString()
    {
        return $"Building: {building?.name}, {buildingPosition} | Wall: {direction.ToString()}";
    }

    public Pose[] GetTargetPose(VehicleConfiguration vehicleConfiguration, Vector3 offset = default(Vector3))
    {
        Vector3 movementDirection = new Vector3(((int)Info + 1) % 2, 0, (int)Info % 2);
        Vector3 paddingDirection = new Vector3((int)Info % 2, 0, ((int)Info + 1) % 2);
        Vector3 startPosition = building.transform.position - movementDirection * Length / 2 + paddingDirection + offset;
        Vector3 endPosition = building.transform.position + movementDirection * Length / 2 + paddingDirection + offset;

        Quaternion rotation = Quaternion.LookRotation(-paddingDirection);

        return new Pose[]
        {
            new Pose()
            {
                Position = startPosition,
                Rotation = rotation
            },
            new Pose()
            {
                Position = endPosition,
                Rotation = rotation
            }
        };
    }
}