using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour,IDamageable
{
	private Rigidbody2D p_rigidBody;
	private float horizontalAxis;
	[SerializeField]
	private float jumpforce;
	[SerializeField]
	private bool isGrounded;
	[SerializeField]
	private LayerMask _groundLayer;
	private bool resetJumpNeeded = false;
	[SerializeField]
	private float _playerSpeed;
	private PlayerAnimation _playerAnim;
	public int _gemCount;
	protected int lifeUnitID;
	protected bool IsDead;
    // Start is called before the first frame update
	
	public int Health{get;set;}

    void Start()
    {
		Health = 4;
        p_rigidBody = GetComponent<Rigidbody2D>();
		isGrounded = false;
		_playerAnim = GetComponentInChildren<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
		if(IsDead != true)
		{
		playerMovement();
		groundRayCast();
		pAttack();
		}
		
    }
	
	void playerMovement(){
		horizontalAxis =  CrossPlatformInputManager.GetAxisRaw("Horizontal");
		
		if((Input.GetKeyDown(KeyCode.Space)||CrossPlatformInputManager.GetButtonDown("B_Button"))&& (isGrounded)){
			p_rigidBody.velocity = new Vector2(p_rigidBody.velocity.x,jumpforce);			
			isGrounded = false;
			resetJumpNeeded = true;
			StartCoroutine(ResetJumpNeededRoutine());
			//tell anim to jump 
			_playerAnim.Jump(true);
		}
		
		
		p_rigidBody.velocity = new Vector2(horizontalAxis * _playerSpeed,p_rigidBody.velocity.y);
		_playerAnim.Move(CrossPlatformInputManager.GetAxisRaw("Horizontal"));
		_playerAnim.Flip(CrossPlatformInputManager.GetAxisRaw("Horizontal"));
	}
	
	void pAttack(){
		if(CrossPlatformInputManager.GetButtonDown("A_Button") && isGrounded == true){
			
			_playerAnim.Attack();
		}
			
	}
	void groundRayCast(){	
		//
		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,-Vector2.up * 0.7f,1.0f,_groundLayer.value);
		Debug.DrawRay(transform.position,-Vector2.up * 0.7f,Color.green);
		if(hitInfo.collider != null){
			if(resetJumpNeeded == false){
			isGrounded = true;
			_playerAnim.Jump(false);
			}
		}
		//
	}
	
	IEnumerator ResetJumpNeededRoutine(){
		yield return new WaitForSeconds(0.1f);
		resetJumpNeeded = false;
	}
	
	public void Damage()
	{
		if(IsDead != true)
		{
			Debug.Log("Player took damage");
			UI_Manager.Instance.UpdateHealth(lifeUnitID);
			Health --;
			if(lifeUnitID < 4)
			{
				lifeUnitID += 1;
			}
			if(Health <= 0)
			{
				IsDead = true;
				_playerAnim.Death();
			}
		}
		
		
	}
	
	public void AddGems(int amount)
	{
		_gemCount += amount;
		UI_Manager.Instance.UpdateGemCount(_gemCount);
	}
}
