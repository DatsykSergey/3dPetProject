using UnityEngine;

namespace Core.CodeBase.Runtime.Gameplay
{
  public class BaseObstacleChecker : MonoBehaviour
  {
    [SerializeField] protected float _castDistance = 1f;
    [SerializeField] protected LayerMask _layerMask;
    protected RaycastHit _hits;
    [field:SerializeField] public bool HasObstacle { get; protected set; }
    public Vector3 HitPoint => _hits.point;
    public Vector3 HitNormal => _hits.normal;
  }
}