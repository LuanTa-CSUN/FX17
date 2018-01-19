//using Sirenix.OdinInspector.Editor;
//using Sirenix.Utilities.Editor;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UnityEditor;
//using UnityEngine;

//[OdinDrawer]
//public class BuildingInfoDrawer : OdinValueDrawer<BuildingInfo>
//{
//    protected override void DrawPropertyLayout(IPropertyValueEntry<BuildingInfo> entry, GUIContent label)
//    {
//        EditorGUI.BeginChangeCheck();

//        WallDrawer wallDrawer = new WallDrawer();
//        //wallDrawer.DrawProperty(entry.SmartValue.North);

//        if (EditorGUI.EndChangeCheck())
//        {
//        }
//    }
//}