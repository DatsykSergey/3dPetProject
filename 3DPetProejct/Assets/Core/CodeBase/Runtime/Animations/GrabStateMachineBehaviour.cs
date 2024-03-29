﻿using UnityEngine;
using UnityEngine.Animations;

namespace Core.CodeBase.Runtime.Animations
{
  public class GrabStateMachineBehaviour : StateMachineBehaviour
  {
    [SerializeField] private Vector3 _offset;
    private Vector3 _position;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      // _position = animator.transform.localPosition;
      animator.applyRootMotion = true;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      // animator.transform.localPosition = _position + _offset;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
      // animator.transform.localPosition = _position;
      animator.applyRootMotion = false;
    }
  }
}