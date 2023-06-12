using UnityEngine;

namespace Core.CodeBase.Runtime.Gameplay
{
  [System.Serializable]
  public class OverlapBox
  {
    [field: SerializeField] public Vector3 Size { get; set; } = Vector3.one;
    [field: SerializeField] public Vector3 Offset { get; set; } = Vector3.zero;
    [SerializeField] private LayerMask _layerMask;
    public Collider[] Result { get; } = new Collider[8];
    public int Count { get; set; } = 0;

    public bool IsDrawGizmos = true;


    public void CheckOverlap(Transform root)
    {
      Count = Physics.OverlapBoxNonAlloc(root.transform.TransformPoint(Offset), Size, Result, root.transform.rotation, _layerMask,
        QueryTriggerInteraction.UseGlobal);
    }

    public void DrawGizmos(Transform root)
    {
      if (IsDrawGizmos == false)
      {
        return;
      }
      
      Gizmos.color = Color.blue;
      Gizmos.matrix = Matrix4x4.TRS(root.TransformPoint(Offset), root.rotation, Vector3.one);
      Gizmos.DrawWireCube(Vector3.zero, Size * 2);

    }
  }
}