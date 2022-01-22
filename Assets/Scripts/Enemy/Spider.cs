	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class Spider : Enemy,IDamageable
	{
		
	   public GameObject proj;
	   public Vector3 proj_Offset;
	   public float distance_check;
	   public int Health{get;set;}	   
	   protected Player player_script;
	   //use for initialization
	   public override void Init()
	   {
		   player_script = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		   Health = base.health;
		   base.Init();
	   }
	   
	   public override void Update()
	   {
		   p_Distance_Check();
	   }
	   public override void Movement()
	   {
		   //sit still
	   }
	   public void Damage()
	   {
			   Health = Health - 1;
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
	   
	   public void p_Distance_Check()
	   {
		   float p_distance = Vector3.Distance(transform.localPosition,player_script.transform.localPosition);
		   if(p_distance <= distance_check)
		   {
			   anim.SetBool("InCombat",true);
		   }
			else if (p_distance > distance_check)
			{
				anim.SetBool("InCombat",false);
				
			}
	   }
	   public void Attack()
	   {
		   Instantiate(proj,transform.position + proj_Offset,Quaternion.identity);
	   }
	}
