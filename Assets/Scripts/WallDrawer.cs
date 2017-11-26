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
        var info = SirenixEditorFields.EnumDropdown("Info", entry.SmartValue.Info);

        if (EditorGUI.EndChangeCheck())
        {
            entry.SmartValue.Info = (WallInfo)info;
        }
    }
}