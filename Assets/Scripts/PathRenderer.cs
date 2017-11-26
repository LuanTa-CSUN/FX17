using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(LineRenderer))]
public class PathRenderer : SerializedMonoBehaviour
{
    private PathConfiguration pathConfiguration;

    [ShowInInspector]
    public PathConfiguration PathConfiguration
    {
        get
        {
            return pathConfiguration;
        }
        set
        {
            pathConfiguration = value;
            GenerateRenderedPath();
        }
    }

    LineRenderer lineRenderer;

    public void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void GenerateRenderedPath()
    {
        List<Pose> path = pathConfiguration.GeneratePath();
        Vector3[] positions = new Vector3[path.Count];
        for(int i = 0; i < path.Count; i++)
        {
            positions[i] = path[i].Position;
        }
        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }
}
