using UnityEditor;
using UnityEngine;

namespace Core.CodeBase.Runtime.DebugTools.CustomGizmos
{
  public class DrawText : GizmosDrawer
  {
    private readonly Vector3 _position;
    private readonly string _text;
    private readonly Color _color;

    public DrawText(Vector3 position, string text, Color color)
    {
      _position = position;
      _text = text;
      _color = color;
    }

    public override void Draw()
    {
      GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
      centeredStyle.alignment = TextAnchor.MiddleCenter;
      Handles.color = _color;
      Handles.Label(_position, _text, centeredStyle);    
    }
  }
}