using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class MissingPropertyDrawer : PropertyDrawer
{
    protected static void DrawProperty(Rect position, SerializedProperty property, GUIContent label, bool isMissing)
    {
        EditorGUI.BeginProperty(position, label, property);

        if (isMissing)
        {
            GUI.color = new Color(1, .5f, .5f, 1);
            EditorGUI.PropertyField(position, property, label);
            GUI.color = Color.white;
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }

        EditorGUI.EndProperty();
    }
}

[CustomPropertyDrawer(typeof(Object), true)]
public class MissingObjectPropertyDrawer : MissingPropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        bool isUnityOptionValue = fieldInfo.DeclaringType.IsGenericType && fieldInfo.DeclaringType.GetGenericTypeDefinition() == typeof(UnityOption<>);
        DrawProperty(position, property, label, isUnityOptionValue == false && property.objectReferenceValue == null);
    }
}

[CustomPropertyDrawer(typeof(string), true)]
public class MissingStringPropertyDrawer : MissingPropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        bool isUnityOptionValue = fieldInfo.DeclaringType.IsGenericType && fieldInfo.DeclaringType.GetGenericTypeDefinition() == typeof(UnityOption<>);
        DrawProperty(position, property, label, isUnityOptionValue == false && string.IsNullOrEmpty(property.stringValue));
    }
}
