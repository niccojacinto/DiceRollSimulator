using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Bar))]
public class BarEditor : UnityEditor.UI.SliderEditor
{
    public override void OnInspectorGUI()
    {
        Bar bar = (Bar)target;

        // Show default inspector property editor
        base.OnInspectorGUI();
    }
}
