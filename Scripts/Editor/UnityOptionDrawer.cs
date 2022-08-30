using LanguageExt;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(UnityOption<>))]
public class UnityOptionDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PropertyField(position, property.FindPropertyRelative("_value"), new GUIContent($"({property.displayName})", "This field is optional."), true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int propertyCount = property.FindPropertyRelative("_value").CountInProperty();
        return propertyCount * EditorGUIUtility.singleLineHeight + (propertyCount - 1) * EditorGUIUtility.standardVerticalSpacing;
    }
}
