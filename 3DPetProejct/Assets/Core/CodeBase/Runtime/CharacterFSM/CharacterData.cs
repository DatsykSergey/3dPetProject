using System;
using UnityEngine;

namespace Core.CodeBase.Runtime.CharacterFSM
{
  [CreateAssetMenu( menuName = "Data/CharacteFsmData")]
  public class CharacterData : ScriptableObject
  {
    [field: SerializeField] public MovementData Movement { get; private set; }
  }

  [Serializable]
  public class MovementData
  {
    [field:SerializeField] public float Speed { get; private set; }
    [field:SerializeField] public float RotationSpeed { get; private set; }
  }
}