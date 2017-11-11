using UnityEngine;

public class Wall : MonoBehaviour, ITarget
{
    public WallInfo info = WallInfo.None;

    public Pose[] GetTargetPose()
    {
        throw new System.NotImplementedException();
    }
}