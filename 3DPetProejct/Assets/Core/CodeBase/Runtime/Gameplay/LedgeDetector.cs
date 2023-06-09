using System.Linq;
using Core.CodeBase.Runtime.DebugTools.CustomGizmos;
using UnityEngine;

namespace Core.CodeBase.Runtime.Gameplay
{
  public class LedgeDetector : MonoBehaviour
  {
    [SerializeField] private Vector3 _boxSize = Vector3.one;
    [SerializeField] private LayerMask _layerMask;
    private readonly Collider[] _result = new Collider[8];
    private int _count = 0;


    private void FixedUpdate()
    {
      if (Time.frameCount % 3 != 0)
      {
        return;
      }

      _count = Physics.OverlapBoxNonAlloc(transform.position, _boxSize, _result, transform.rotation, _layerMask,
        QueryTriggerInteraction.UseGlobal);


    }

    private void Update()
    {
      for (int i = 0; i < _count; i++)
      {
        BoxCollider boxCollider = _result[i] as BoxCollider;
        if (boxCollider == null)
        {
          Debug.LogWarning("Find not box collider Ledge");
          continue;
        }
        CustomGizmos.Isntance.DrawSphere(boxCollider.transform.position, 0.5f, Color.green);
        Vector3 rightPoint = GetRightPoint(boxCollider);
        Vector3 leftPoint = GetLeftPoint(boxCollider);
        CustomGizmos.Isntance.DrawLine(rightPoint, leftPoint, Color.green);
      }
    }

    private static Vector3 GetRightPoint(BoxCollider boxCollider)
    {
      return boxCollider.transform.position + boxCollider.transform.right * (boxCollider.size.x * 0.5f);
    }

    private static Vector3 GetLeftPoint(BoxCollider boxCollider)
    {
      return boxCollider.transform.position - boxCollider.transform.right * (boxCollider.size.x * 0.5f);
    }

    private void OnDrawGizmos()
    {
      Gizmos.color = Color.blue;
      Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
      Gizmos.DrawWireCube(Vector3.zero, _boxSize*2);
    }
  }
}