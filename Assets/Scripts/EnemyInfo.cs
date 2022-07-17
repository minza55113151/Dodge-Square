using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/enemy")]
public class EnemyInfo : ScriptableObject
{
    public float constSpeed; 
    public float speed;
}
