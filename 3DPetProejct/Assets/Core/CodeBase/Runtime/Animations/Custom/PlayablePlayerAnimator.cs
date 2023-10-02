using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Core.CodeBase.Runtime.Animations.Custom
{
  [AddComponentMenu("My animation/Playable animation")]
  public class PlayablePlayerAnimator : BasePlayerAnimator
  {
    [SerializeField] private Animator _animator;
    [Header("Clips")] [SerializeField] private AnimationClip _idleClip;

    private PlayableGraph _playableGraph;

    private void Awake()
    {
      _playableGraph = PlayableGraph.Create();
      _playableGraph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);
      AnimationPlayableOutput output = AnimationPlayableOutput.Create(_playableGraph, "GraphPlayerAnimator", _animator);
      AnimationClipPlayable clipPlayable = AnimationClipPlayable.Create(_playableGraph, _idleClip);
      output.SetSourcePlayable(clipPlayable);
      _playableGraph.Play();
    }

    private void OnDestroy()
    {
      _playableGraph.Destroy();
    }

    public override void UpdateMovement(Vector3 velocity)
    {
    }
  }
}