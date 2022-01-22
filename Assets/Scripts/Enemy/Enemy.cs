	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public abstract class Enemy : MonoBehaviour
	{
	  [SerializeField]
	  protected int  health;
	  [SerializeField]
	  protected float  speed;
	  [SerializeField]
	  protected int  gems;
	  [SerializeField]
	  protected Transform [] waypoints;
	  protected int WpID;
	  [SerializeField]
	  protected int startingWpID;
	  protected Transform targetWp;
	  protected Animator anim;
	  protected SpriteRenderer sprite;
	  protected bool isHit = false;
	  //Player position variable
	  protected Player player_script;
	  //Distance check variable.
	[SerializeField]
	  protected float d_Check;
	  protected BoxCollider2D boxCollider2D;
	  protected bool isDead = false;
	  //
	   public GameObject[] _lootTable;
	   public Vector3 _dropOffset;
	   protected Diamond _diamondScript;
	 public virtual void Init()
	 {
		 anim = GetComponentInChildren<Animator>();
		 sprite = GetComponentInChildren<SpriteRenderer>();
		 boxCollider2D = GetComponent<BoxCollider2D>();
		 WpID = startingWpID;
		 targetWp = waypoints[startingWpID];
		 player_script = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	 }
	 
	 private void Start()
	 {
		 Init();
	 }
	  public virtual void Update()
	  {
		   if((anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))&& (anim.GetBool("InCombat") == false))
		  {
			  return;
		  }	
		 
			if(isDead == false)
			{
				 Movement();
			}
		  
			DeathCheck();
	  }
	  
	 public virtual void DeathCheck()
	 {
		 if(isDead == true)
		 {
			 boxCollider2D.enabled = false;
		 }
	 }
	 public virtual void Movement()
	 {
		   if(targetWp == waypoints[0])
		  {
			  sprite.flipX = true;
		  }
		  if(targetWp == waypoints[1])
		  {
			  sprite.flipX = false;
		  }
		  
			if((transform.position != targetWp.position)&&(isHit == false))
			{
				if(anim.GetBool("InCombat") == false)
				{
					transform.position = Vector3.MoveTowards(transform.position,targetWp.position,speed * Time.deltaTime);

				}
			}
			else if(transform.position == targetWp.position)
			{
					if(targetWp == waypoints[1])
					{
						anim.SetTrigger("Idle");
						targetWp = waypoints[0];
					}
					else if(targetWp == waypoints[0])
					{
						anim.SetTrigger("Idle");
						targetWp = waypoints[1];
					}
			}
			float distance = Vector3.Distance(transform.localPosition,player_script.transform.localPosition);
			Vector3 direction = player_script.transform.localPosition - transform.localPosition;
			//Debug.Log("Side:" + direction.x);
			if(distance > d_Check)
			{
				anim.SetBool("InCombat",false);
				isHit = false;
			}
			
			if(direction.x > 0 && anim.GetBool("InCombat") == true)
			{
				//face right
				sprite.flipX = false;
			}
			else if(direction.x < 0 && anim.GetBool("InCombat") == true)
			{
				//face left
				sprite.flipX = true;
			}
	 }
	  
	 
	}
