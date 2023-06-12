using UnityEngine;

namespace Core.CodeBase.Runtime.Gameplay
{
  public static class MathExtension
  {
    public static Vector3 GetRightPoint(BoxCollider boxCollider)
    {
      return boxCollider.transform.position + boxCollider.transform.right * (boxCollider.size.x * 0.5f);
    }

    public static Vector3 GetLeftPoint(BoxCollider boxCollider)
    {
      return boxCollider.transform.position - boxCollider.transform.right * (boxCollider.size.x * 0.5f);
    }
  }
}