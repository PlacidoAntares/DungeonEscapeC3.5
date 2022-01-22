using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
	protected bool canDamage = true;												
	[SerializeField]
	protected float damageDelay;
	[SerializeField]
	protected float dmg_val;
    void OnTriggerEnter2D(Collider2D other)
	{
		IDamageable hit = other.GetComponent<IDamageable>();
		if(hit != null)
		{	
			if(canDamage == true)
			{
			hit.Damage();
			canDamage = false;
			StartCoroutine(ResetAttackRoutine());
			}
			
		}
		
	}
	
	IEnumerator ResetAttackRoutine(){
		yield return new WaitForSeconds(damageDelay);
		canDamage = true;
	}
}
