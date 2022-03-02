#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using MRTKExtensions.Utilities;
using UnityEditor;
using UnityEngine;

namespace MRTKExtensions.SpatialUnderstanding.Editor
{
    /// <summary>
    /// Draws a EnumFlags enumeration (for instance Microsoft.MixedReality.Toolkit.SpatialAwareness.SpatialAwarenessSurfaceTypes)
    /// as a single select popup
    /// </summary>
    [CustomPropertyDrawer(typeof(SingleEnumFlagSelectAttribute))]
    public class SingleEnumFlagSelectAttributeEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var singleEnumFlagSelectAttribute = (SingleEnumFlagSelectAttribute)attribute;
            if (!singleEnumFlagSelectAttribute.IsValid)
            {
                return;
            }
            var displayTexts = new List<GUIContent>();
            var enumValues = new List<int>();
            foreach (var displayText in Enum.GetValues(singleEnumFlagSelectAttribute.EnumType))
            {
                displayTexts.Add(new GUIContent(displayText.ToString()));
                enumValues.Add((int)displayText);
            }

            property.intValue = EditorGUI.IntPopup(position, label, property.intValue,
                displayTexts.ToArray(), enumValues.ToArray());
        }
    }
}
#endif