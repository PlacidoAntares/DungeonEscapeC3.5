using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
	protected Player _playerScript;
	public int _gems = 1;
	
    void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			_playerScript = other.GetComponent<Player>();
			_playerScript.AddGems(_gems);
			Destroy(this.gameObject);
		}
	}
}
