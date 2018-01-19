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
public class PositionTargetDrawer : OdinValueDrawer<PositionTarget>
{
    protected override void DrawPropertyLayout(IPropertyValueEntry<PositionTarget> entry, GUIContent label)
    {
        EditorGUI.BeginChangeCheck();
        var Position = SirenixEditorFields.Vector3Field("Position", entry.SmartValue.Position);
        var Rotation = SirenixEditorFields.QuaternionField("Rotation", entry.SmartValue.Rotation);

        if (EditorGUI.EndChangeCheck())
        {
            entry.SmartValue = new PositionTarget()
            {
                Position = Position,
                Rotation = Rotation
            };
        }
    }
}