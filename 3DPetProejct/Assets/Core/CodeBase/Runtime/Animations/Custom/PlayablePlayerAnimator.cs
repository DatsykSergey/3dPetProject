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
    [SerializeField] private float _maxDelta = 0.2f;
    [Header("Clips")]
    [SerializeField] private AnimationClip _idleClip;
    [SerializeField] private AnimationClip _forward;
    [SerializeField, Range(0, 1)] private float _mixWeight = 0f;

    private PlayableGraph _playableGraph;
    private AnimationMixerPlayable _mixer;

    private void Awake()
    {
      _playableGraph = PlayableGraph.Create();
      _playableGraph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);
      AnimationPlayableOutput output = AnimationPlayableOutput.Create(_playableGraph, "GraphPlayerAnimator", _animator);
      _mixer = AnimationMixerPlayable.Create(_playableGraph, 2);
      output.SetSourcePlayable(_mixer);

      AnimationClipPlayable idle = AnimationClipPlayable.Create(_playableGraph, _idleClip);
      AnimationClipPlayable forward = AnimationClipPlayable.Create(_playableGraph, _forward);

      _playableGraph.Connect(idle, 0, _mixer, 0);
      _playableGraph.Connect(forward, 0, _mixer, 1);
      
      _playableGraph.Play();
    }

    private void OnDestroy()
    {
      _playableGraph.Destroy();
    }

    public override void UpdateMovement(Vector3 velocity)
    {
      _mixWeight = Mathf.MoveTowards(_mixWeight, Mathf.Clamp01(velocity.magnitude), _maxDelta);
      
      _mixer.SetInputWeight(0, 1 - _mixWeight);
      _mixer.SetInputWeight(1, _mixWeight);
    }
  }
}