using System;
using System.Collections;
using Core.CodeBase.Runtime.Gameplay.Player;
using Core.CodeBase.Runtime.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Core.CodeBase.Runtime.Gameplay
{
  public class LedgeGrab : MonoBehaviour
  {
    [SerializeField] private Transform _root;
    [SerializeField] private ObstacleChecker _leftObstacleChecker;
    [SerializeField] private ObstacleChecker _centerObstacleChecker;
    [SerializeField] private ObstacleChecker _rightObstacleChecker;
    [SerializeField] private LedgeDetector _ledgeDetector;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Transform _climbPoint;
    [SerializeField] private bool _hasObstacle = false;
    [SerializeField] private float _moveSpeed = 1f;

    [Header("jump to other ledge")]
    [SerializeField] private NeighbourLedge _leftNeighbourLedge;
    [SerializeField] private NeighbourLedge _rightNeighbourLedge;
    [SerializeField] private NeighbourLedge _upNeighbourLedge;

    private IPlayerInput _playerInput;
    [SerializeField] private GrabState _currentState = GrabState.Finding;
    [SerializeField] private float _jumpToNearLedgeSpeed = 1f;

    private enum GrabState
    {
      None = 0,
      Finding = 1,
      Grabbed = 2,
      JumpMove = 3,
    }

    [Inject]
    private void Construct(IPlayerInput playerInput)
    {
      _playerInput = playerInput;
    }

    private void StartClimb()
    {
      if (_centerObstacleChecker.HasObstacle == false)
      {
        return;
      }

      Debug.Log("StartClimb");
      _playerMovement.FreezeMovement();
      _currentState = GrabState.Grabbed;
      SetPositionToLedge();
    }

    private void Update()
    {
      if (_currentState == GrabState.Finding)
      {
        TryFindLedge();
      }
      else if(_currentState == GrabState.Grabbed)
      {
        MoveAlongLedge();

        if (_playerInput.IsPressJumpDown())
        {
          JumpDown();
        }

        if (_playerInput.IsPressJump())
        {
          Vector2 moveDirection = _playerInput.GetMoveDirection();
          Vector3 nearPoint; 
          if ((moveDirection.x > 0 && _rightNeighbourLedge.TryFindNearPoint(out nearPoint)) ||
              moveDirection.x < 0 && _leftNeighbourLedge.TryFindNearPoint(out nearPoint) ||
              moveDirection.y > 0 && _upNeighbourLedge.TryFindNearPoint(out nearPoint))
          {
            StartMoveToPoint(nearPoint);
          }
        }  
      }
    }

    private void TryFindLedge()
    {
      if (_playerMovement.IsGrounded)
      {
        return;
      }

      if (_ledgeDetector.HasLedge == false || _centerObstacleChecker.HasObstacle == false)
      {
        _hasObstacle = false;
        return;
      }

      _hasObstacle = true;
      StartClimb();
    }

    private void MoveAlongLedge()
    {
      if (_ledgeDetector.HasLedge || _centerObstacleChecker.HasObstacle)
      {
        float horizontalMovement = _playerInput.GetMoveDirection().x;
        if (horizontalMovement < 0 && _leftObstacleChecker.HasObstacle)
        {
          _root.position += _ledgeDetector.NearBoxCollider.transform.right * (_moveSpeed * Time.deltaTime);
        }
        else if (horizontalMovement > 0 && _rightObstacleChecker.HasObstacle)
        {
          _root.position -= _ledgeDetector.NearBoxCollider.transform.right * (_moveSpeed * Time.deltaTime);
        }
      }
      else
      {
        JumpDown();
      }
    }

    private void JumpDown()
    {
      StopAllCoroutines();
      StartCoroutine(JumpingDown());
    }

    private void JumpUp()
    {
      StopAllCoroutines();
      StartCoroutine(JumpingUp());
    }

    private void StartMoveToPoint(Vector3 point)
    {
      StopAllCoroutines();
      StartCoroutine(MovingToPoint(point));
    }

    private void SetPositionToLedge()
    {
      Vector3 rootForward = -_centerObstacleChecker.HitNormal;
      rootForward.y = 0;
      rootForward.Normalize();
      _root.forward = rootForward;
      SetRelativeRootPosition(_centerObstacleChecker.HitPoint);
    }

    private IEnumerator JumpingDown()
    {
      _currentState = GrabState.None;
      _hasObstacle = false;
      _playerMovement.UnfreezeMovement();

      
      yield return new WaitForSeconds(0.5f);
      _currentState = GrabState.Finding;
    }

    private IEnumerator JumpingUp()
    {
      _currentState = GrabState.None;
      _hasObstacle = false;
      _playerMovement.UnfreezeMovement();
      _playerMovement.JumpUp();
      
      yield return new WaitForSeconds(0.5f);
      _currentState = GrabState.Finding;
    }

    private IEnumerator MovingToPoint(Vector3 point)
    {
      _currentState = GrabState.JumpMove;
      while ((_climbPoint.position - point).sqrMagnitude > MathExtension.SqrDistanceAccuracy)
      {
        Vector3 moveTowards = Vector3.MoveTowards(_climbPoint.position, point, _jumpToNearLedgeSpeed * Time.deltaTime);
        SetRelativeRootPosition(moveTowards);
        yield return null;
      }
      SetRelativeRootPosition(point);
      _currentState = GrabState.Grabbed;
    }

    private void SetRelativeRootPosition(Vector3 position)
    {
      _root.position += (position - _climbPoint.position);
    }
  }
}