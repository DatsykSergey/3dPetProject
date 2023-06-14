using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace CustomTools.Core.CodeBase.Tools.CustomProperty
{
  [CustomPropertyDrawer(typeof(ReadonlyAttribute))]
  public class ReadonlyAttributeDrawer : PropertyDrawer
  {
    // public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    // {
    //   bool prevGUIState = GUI.enabled;
    //   GUI.enabled = false;
    //   EditorGUI.PropertyField(position, property, label);
    //   GUI.enabled = prevGUIState;
    // }

    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
  
      VisualElement root = new VisualElement();
      PropertyField propertyField = new PropertyField(property, property.displayName);
      propertyField.SetEnabled(false);
      root.Add(propertyField);
      return root;
    }
  }
}