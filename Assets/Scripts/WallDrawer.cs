using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

[OdinDrawer]
public class WallDrawer : OdinValueDrawer<Wall>
{
    protected override void DrawPropertyLayout(IPropertyValueEntry<Wall> entry, GUIContent label)
    {
        EditorGUI.BeginChangeCheck();
        var info = SirenixEditorFields.EnumDropdown(entry.Property.Info.PropertyName, entry.SmartValue.Info);

        if (EditorGUI.EndChangeCheck())
        {
            entry.SmartValue = new Wall(entry.SmartValue.buildingPosition, entry.SmartValue.direction, (WallInfo)info);
        }
    }
}