using System;
using Core.CodeBase.Runtime.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Core.CodeBase.Runtime.Gameplay
{
  public class LedgeGrab : MonoBehaviour
  {
    [SerializeField] private Transform _root;
    [SerializeField] private ObstacleChecker _obstacleChecker;
    private IPlayerInput _playerInput;

    [Inject]
    private void Construct(IPlayerInput playerInput)
    {
      _playerInput = playerInput;
    }
    
    private void Update()
    {
      if (_obstacleChecker.HasObstacle == false)
      {
        return;
      }

      _root.forward = -_obstacleChecker.HitNormal;
      _root.position += (_obstacleChecker.HitPoint - transform.position);
    }
  }
}