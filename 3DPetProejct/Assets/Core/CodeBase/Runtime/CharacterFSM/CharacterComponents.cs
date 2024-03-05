using System;
using Core.CodeBase.Runtime.Animations;
using UnityEngine;

namespace Core.CodeBase.Runtime.CharacterFSM
{
  [Serializable]
  public class CharacterComponents
  {
    [field: SerializeField] public BasePlayerAnimator Animator {get; private set;}
    [field: SerializeField] public GroundChecker GroundChecker {get; private set;}
    [field: SerializeField] public CharacterController CharacterController {get; private set;}
  }
}