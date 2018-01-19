using Sirenix.OdinInspector;
using UnityEngine;

public struct Wall : ITarget
{
    public enum WallDirection
    {
        Bottom = -2,
        Right = -1,
        Left = 1,
        Top = 2
    }

    public WallInfo Info;

    [HideInInspector]
    public WallDirection direction;

    public float Length;

    public Vector3 buildingPosition;

    public Wall(Vector3 position, WallDirection direction, WallInfo info)
    {
        this.Length = 1;
        this.Info = info;
        this.buildingPosition = position;
        this.direction = direction;
    }

    public override string ToString()
    {
        return $"Position: {buildingPosition} | Wall: {direction}";
    }

    public Pose[] GetTargetPose(VehicleConfiguration vehicleConfiguration, Vector3? lastPosition = null, Vector3 offset = default(Vector3))
    {
        Vector3 movementDirection = new Vector3(((int)direction + 1) % 2, 0, (int)direction % 2);
        Vector3 paddingDirection = new Vector3((int)direction % 2, 0, ((int)direction + 1) % 2);
        Vector3 startPosition = buildingPosition - movementDirection * Length / 2 + paddingDirection + offset;
        Vector3 endPosition = buildingPosition + movementDirection * Length / 2 + paddingDirection + offset;

        if (lastPosition.HasValue && Vector3.Distance(endPosition, lastPosition.Value) < Vector3.Distance(startPosition, lastPosition.Value))
        {
            Vector3 second = startPosition;
            startPosition = endPosition;
            endPosition = second;
        }

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