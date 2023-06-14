using System.Collections;
using Core.CodeBase.Runtime.Gameplay.Player;
using Core.CodeBase.Runtime.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Core.CodeBase.Runtime.Gameplay
{
  public class EdgeGrab : MonoBehaviour
  {
    [SerializeField] private EdgeFinder _left;
    [SerializeField] private EdgeFinder _right;
    [SerializeField] private EdgeFinder _edgeFinder;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Transform _grabTransform;
    [SerializeField] private Transform _footTransform;
    [SerializeField] private float _moveSpeed = 5f;
  
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

      if (_currentState == EdgeGrabState.Grabbed)
      {
        UpdatePosition();
      }
    }

    private void UpdatePosition()
    {
      if (_edgeFinder.IsHasPoint == false || _playerInput.IsPressJumpDown())
      {
        JumpDown();
        return;
      }
      if (_playerInput.IsPressJump())
      {
        MoveOnEdge();
        return;
      }

      float horizontalMovement = _playerInput.GetMoveDirection().x;
      if (horizontalMovement > 0 && _right.IsHasPoint)
      {
        MoveToSideways(_right.EdgePoint);
      }
      if (horizontalMovement < 0 && _left.IsHasPoint)
      {
        MoveToSideways(_left.EdgePoint);
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

    private void MoveOnEdge()
    {
      StopAllCoroutines();
      StartCoroutine(StartMoveOnEdge());
    }
    
    private void MoveToSideways(Vector3 newPosition)
    {
      StopAllCoroutines();
      StartCoroutine(StartMoveToSideways(newPosition));
    }

    private IEnumerator StartJumpDown()
    {
      _playerMovement.UnfreezeMovement();
      _currentState = EdgeGrabState.Move;
      yield return new WaitForSeconds(0.5f);
      _currentState = EdgeGrabState.None;
    }

    private IEnumerator StartMoveOnEdge()
    {
      _currentState = EdgeGrabState.Move;
      
      Vector3 toEdgePoint = _edgeFinder.EdgePoint - _footTransform.position;
      while (toEdgePoint.sqrMagnitude > MathExtension.SqrDistanceAccuracy)
      {
        _playerMovement.transform.position = Vector3.MoveTowards(_playerMovement.transform.position, _playerMovement.transform.position + toEdgePoint, _moveSpeed * Time.deltaTime);
        toEdgePoint = _edgeFinder.EdgePoint - _footTransform.position;
        yield return null;
      }
      
      _playerMovement.transform.position += toEdgePoint;
      _playerMovement.UnfreezeMovement();
      _currentState = EdgeGrabState.None;
    }

    private IEnumerator StartMoveToSideways(Vector3 newPosition)
    {
      _currentState = EdgeGrabState.Move;
      
      Vector3 toEdgePoint = newPosition - _grabTransform.position;
      while (toEdgePoint.sqrMagnitude > MathExtension.SqrDistanceAccuracy)
      {
        _playerMovement.transform.position = Vector3.MoveTowards(_playerMovement.transform.position, _playerMovement.transform.position + toEdgePoint, _moveSpeed * Time.deltaTime);
        toEdgePoint = newPosition - _grabTransform.position;
        yield return null;
      }

      GrabEdge(newPosition);
    }
  }
}