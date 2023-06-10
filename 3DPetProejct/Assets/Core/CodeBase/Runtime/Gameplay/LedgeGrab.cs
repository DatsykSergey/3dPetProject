using System;
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
    [SerializeField] private bool _hasObstacle = false;
    [SerializeField] private float _moveSpeed = 1f;

    private IPlayerInput _playerInput;
    private bool _isActive = false;

    [Inject]
    private void Construct(IPlayerInput playerInput)
    {
      _playerInput = playerInput;
    }

    private void StartClimb()
    {
      _playerMovement.enabled = false;
      _isActive = true;
      SetPositionToLedge();
    }

    private void Update()
    {
      if (_isActive == false)
      {
        TryFindLedge();
      }
      else
      {
        MoveAlongLedge();
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
    }

    private void SetPositionToLedge()
    {
      Vector3 rootForward = -_centerObstacleChecker.HitNormal;
      rootForward.y = 0;
      rootForward.Normalize();
      _root.forward = rootForward;
      _root.position += (_centerObstacleChecker.HitPoint - transform.position);
    }
  }
}