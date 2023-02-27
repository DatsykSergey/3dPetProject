using CodeBase.Runtime.Gameplay.Character;
using UnityEngine;

namespace CodeBase.GameplayTest.Animation
{
  public class TestAnimation : MonoBehaviour
  {
    [SerializeField, Range(-1, 1)] private float _vertical;
    [SerializeField, Range(-1, 1)] private float _horizontal;
    [SerializeField] private CharacterAnimator _animator;
    
    private void Update()
    {
      _animator.UpdateMovement(_vertical, _horizontal);
    }
  }
}