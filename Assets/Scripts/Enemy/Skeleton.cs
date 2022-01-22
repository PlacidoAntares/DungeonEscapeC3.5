	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class Skeleton : Enemy,IDamageable
	{
		public int Health{get;set;}
		public override void Init()
		   {
			   Health = base.health;
			   base.Init();
			  
		   }
		   public void Damage()
		   {
			   Health = Health - 1;
			   anim.SetTrigger("Hit");
			   isHit = true;
			   anim.SetBool("InCombat",true);
			   Debug.Log("Health:" + Health);
			   if((Health <= 0)&&(isDead == false))
			   {
				   if(isDead == false)
				   {
					GameObject _diamond = Instantiate(_lootTable[0],transform.position + _dropOffset,Quaternion.identity);
				   _diamondScript = _diamond.GetComponent<Diamond>();
				   _diamondScript._gems = gems;
				   anim.SetTrigger("Death");
				   }
				   
				    isDead = true;
				    
					
			   }
			  
		   }
	}
