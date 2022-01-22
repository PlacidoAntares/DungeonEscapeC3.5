using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	[SerializeField]
	private Animator _spriteAnim;
	[SerializeField]
	private Animator _swordAnim;
	[SerializeField]
	private SpriteRenderer _swordArcRender;
	[SerializeField]
	private SpriteRenderer _spriteRender;
    
	public void Move(float move){
		
		
		_spriteAnim.SetFloat("Move",Mathf.Abs(move));
	}
	
	public void Jump(bool Jumping){
		
		if(Jumping == true){
			_spriteAnim.SetBool("Jump",true);
		}
		else{
			_spriteAnim.SetBool("Jump",false);
		}
	}
	
	public void Attack(){
		
		_spriteAnim.SetTrigger("Attack");
		_swordAnim.SetTrigger("Sword_Animation");
		
	}
	
	public void Death()
	{
		_spriteAnim.SetTrigger("Death");
	}
	public void Flip(float move){
		
		if(move < 0){
			_spriteRender.flipX = true;
			
			_swordArcRender.flipY = true;
			
			Vector3 newPos = _swordArcRender.transform.localPosition;
			newPos.x = -1.01f;
			_swordArcRender.transform.localPosition = newPos;
		}
		else if(move > 0){
			_spriteRender.flipX = false;
			
			_swordArcRender.flipY = false;
			
			Vector3 newPos = _swordArcRender.transform.localPosition;
			newPos.x = 1.01f;
			_swordArcRender.transform.localPosition = newPos;
		}
	}
}
