using UnityEngine;

namespace Core.CodeBase.Runtime.Gameplay
{
  public static class MathExtension
  {
    public static Vector3 GetRightPoint(BoxCollider boxCollider, float offset = 0)
    {
      return boxCollider.transform.position + boxCollider.transform.right * (boxCollider.size.x * 0.5f) - boxCollider.transform.right * offset;
    }

    public static Vector3 GetLeftPoint(BoxCollider boxCollider, float offset = 0)
    {
      return boxCollider.transform.position - boxCollider.transform.right * (boxCollider.size.x * 0.5f) + boxCollider.transform.right * offset;
    }

    public const float SqrDistanceAccuracy = 0.01f;
  }
}