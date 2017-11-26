using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Path Configuration", menuName = "Path Configuration")]
public class PathConfiguration : SerializedScriptableObject
{
    public TrialConfiguration Configuration;

    public class TargetAbstractor
    {
        private Type type;

        [ShowInInspector]
        [ValueDropdown("GetPossibleTargets")]
        public Type Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                Target = Activator.CreateInstance(value) as ITarget;
            }
        }

        [ShowInInspector]
        public ITarget Target { get; set; }

        public List<String> GetPossibleTargets()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(
                    type =>
                    {
                        return typeof(ITarget).IsAssignableFrom(type);
                    })
                .Select(
                    type =>
                    {
                        return type.Name;
                    })
                .ToList();
        }
    }

    [ListDrawerSettings(HideAddButton = true, OnTitleBarGUI = "OnListTitleGUI")]
    public List<ITarget> Waypoints;

    public System.Object[] GetPossibleTargets()
    {
        IEnumerable<System.Object> objects = Assembly.GetExecutingAssembly().GetTypes()
            .Where(
                type =>
                {
                    return typeof(ITarget).IsAssignableFrom(type) && 
                        type != typeof(Wall) &&
                        !type.IsInterface &&
                        !type.IsAbstract;
                });
        return objects.Concat(
             Configuration.Buildings.SelectMany(
                 building =>
                 {
                     building.Information.North.buildingPosition = building.Position;
                     building.Information.South.buildingPosition = building.Position;
                     building.Information.West.buildingPosition = building.Position;
                     building.Information.East.buildingPosition = building.Position;
                     return new Wall[]
                     {
                            building.Information.North,
                            building.Information.South,
                            building.Information.West,
                            building.Information.East
                     };
                 })).ToArray();
    }

#if UNITY_EDITOR
    int selected = 0;
    private void OnListTitleGUI()
    {
        System.Object[] objects = GetPossibleTargets();
        string[] names = objects.Select(obj =>
        {
            if (obj is Type)
            {
                return ((Type)obj).Name;
            }
            else if (obj is Wall)
            {
                return ((Wall)obj).ToString();
            }
            else
            {
                return "Error";
            }
        }).ToArray();

        selected = UnityEditor.EditorGUILayout.Popup(selected, names);
        if (GUILayout.Button("Submit"))
        {
            if (objects[selected] is Type)
            {
                Waypoints.Add(Activator.CreateInstance(objects[selected] as Type) as ITarget);
            }
            else if (objects[selected] is Wall)
            {
                Waypoints.Add((Wall)objects[selected]);
            }
        }
    }
#endif

    public List<Pose> GeneratePath()
    {
        List<Pose> posePath = new List<Pose>();
        for (int i = 0; i < Waypoints.Count; i++)
        {
            posePath.AddRange(Waypoints[i].GetTargetPose(Configuration.VehicleConfiguration));
        }
        return posePath;
    }
}