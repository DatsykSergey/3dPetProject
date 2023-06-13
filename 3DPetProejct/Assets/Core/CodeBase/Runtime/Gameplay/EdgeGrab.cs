using System.Collections;
using Core.CodeBase.Runtime.Gameplay.Player;
using Core.CodeBase.Runtime.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Core.CodeBase.Runtime.Gameplay
{
  public class EdgeGrab : MonoBehaviour
  {
    [SerializeField] private EdgeFinder _edgeFinder;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Transform _grabTransform;
  
    private EdgeGrabState _currentState = EdgeGrabState.None;
    private IPlayerInput _playerInput;

    private enum EdgeGrabState
    {
      None = 0,
      Grabbed = 1,
      Move = 2,
    }

    [Inject]
    private void Construct(IPlayerInput playerInput)
    {
      _playerInput = playerInput;
    }

    private void Update()
    {
      if (_currentState == EdgeGrabState.None &&
          _playerMovement.IsGrounded == false && 
          _edgeFinder.IsHasPoint)
      {
        GrabEdge(_edgeFinder.EdgePoint);
      }

      if (_currentState == EdgeGrabState.Grabbed && 
          (_edgeFinder.IsHasPoint == false || _playerInput.IsPressJumpDown()))
      {
        JumpDown();
      }
    }

    private void GrabEdge(Vector3 point)
    {
      Vector3 shit = point - _grabTransform.position;
      _playerMovement.FreezeMovement();
      _playerMovement.transform.position += shit;
      _currentState = EdgeGrabState.Grabbed;
    }

    private void JumpDown()
    {
      StopAllCoroutines();
      StartCoroutine(StartJumpDown());
    }

    private IEnumerator StartJumpDown()
    {
      _playerMovement.UnfreezeMovement();
      _currentState = EdgeGrabState.Move;
      yield return new WaitForSeconds(0.5f);
      _currentState = EdgeGrabState.None;
    }
  }
}