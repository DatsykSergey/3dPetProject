using Core.CodeBase.Runtime.DebugTools.CustomGizmos;
using UnityEngine;

namespace Core.CodeBase.Runtime.Gameplay
{
  public class LedgeDetector : MonoBehaviour
  {
    [SerializeField] private Vector3 _boxSize = Vector3.one;
    [SerializeField] private LayerMask _layerMask;
    private readonly Collider[] _result = new Collider[8];


    private void FixedUpdate()
    {
      if (Time.frameCount % 3 != 0)
      {
        return;
      }

      int count = Physics.OverlapBoxNonAlloc(transform.position, _boxSize, _result, transform.rotation, _layerMask,
        QueryTriggerInteraction.UseGlobal);

      for (int i = 0; i < count; i++)
      {
        CustomGizmos.Isntance.DrawSphere(_result[i].transform.position, 0.5f, Color.green);
      }
    }

    private void OnDrawGizmos()
    {
      Gizmos.color = Color.blue;
      Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
      Gizmos.DrawWireCube(Vector3.zero, _boxSize*2);
    }
  }
}