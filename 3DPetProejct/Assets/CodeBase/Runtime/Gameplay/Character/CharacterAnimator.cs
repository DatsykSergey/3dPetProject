using System;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Character
{
  public class CharacterAnimator : MonoBehaviour
  {
    [SerializeField] private Animator _animator;

    private readonly int _verticalId = Animator.StringToHash("VerticalMovement");
    private readonly int _horizontalId = Animator.StringToHash("HorizontalMovement");


    public void UpdateMovement(float vertical, float horizontal)
    {
      _animator.SetFloat(_verticalId, vertical);
      _animator.SetFloat(_horizontalId, horizontal);
    }
  }
}