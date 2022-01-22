	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class Moss_Giant : Enemy,IDamageable
	{
		public int Health{get;set;}	
	   //use for initialization
	   public override void Init()
	   {
		   base.Init();
		   Health = base.health;
	   }
	   public void Damage()
	   {
			   Health = Health - 1;
			   anim.SetTrigger("Hit");
			   isHit = true;
			   anim.SetBool("InCombat",true);
			   if(Health <= 0)
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
