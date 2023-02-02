///
///
///
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(DisplayNameAttribute))]

public class DisplayNameInspector : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		DisplayNameAttribute displayNameAttritube = attribute as DisplayNameAttribute;
		
		var name = displayNameAttritube.Name;
		if (name != null && name.Length > 0)
		{
			label.text = name;
		}

		EditorGUI.PropertyField(position, property, label);
	}
}
#endif