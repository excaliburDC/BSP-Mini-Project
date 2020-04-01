using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/EnemyStats")]
public class EnemyStats : ScriptableObject
{
	public float moveSpeed = 1f;
	public float lookRange = 50f;
	public float lookSphereCastRadius = 5f;

	public float attackRange = 1f;
	public float attackRate = 1f;
	public float attackForce = 15f;
	public int attackDamage = 25;

	public float searchDuration = 4f;
	
	
}
