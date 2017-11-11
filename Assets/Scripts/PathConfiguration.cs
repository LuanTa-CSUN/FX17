using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PathConfiguration : ScriptableObject
{
    public TrialConfiguration Configuration;

    public List<ITarget> Waypoints;
}