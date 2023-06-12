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

    private IPlayerInput _playerInput;
    private GrabState _currentState = GrabState.Finding;

    private enum GrabState
    {
      None = 0,
      Finding = 1,
      Grabbed = 2,
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

      _playerMovement.FreezeMovement();
      _currentState = GrabState.Grabbed;
      SetPositionToLedge();
    }

    private void Update()
    {
      if (_currentState == GrabState.None)
      {
        return;
      }
      
      if (_currentState == GrabState.Finding)
      {
        TryFindLedge();
      }
      else
      {
        MoveAlongLedge();

        if (_playerInput.IsPressJumpDown())
        {
          JumpDown();
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

    private void SetPositionToLedge()
    {
      Vector3 rootForward = -_centerObstacleChecker.HitNormal;
      rootForward.y = 0;
      rootForward.Normalize();
      _root.forward = rootForward;
      _root.position += (_centerObstacleChecker.HitPoint - _climbPoint.position);
    }

    private IEnumerator JumpingDown()
    {
      _currentState = GrabState.None;
      _hasObstacle = false;
      _playerMovement.UnfreezeMovement();

      
      yield return new WaitForSeconds(0.5f);
      _currentState = GrabState.Finding;
    }
  }
}