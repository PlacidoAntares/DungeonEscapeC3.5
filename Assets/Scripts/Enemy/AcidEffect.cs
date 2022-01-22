using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
	public Vector3 dir;
	public float speed;
	public float duration;

	void Start()
	{
		Destroy(this.gameObject,duration);
	}
    // Update is called once per frame
    void Update()
    {
        Moveproj();
		
    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			IDamageable hit = other.GetComponent<IDamageable>();
			if(hit != null)
			{	
				hit.Damage();
				Destroy(this.gameObject);
				
			}
		}
		
	}
	void Moveproj()
	{
		transform.position += dir * (speed * Time.deltaTime);
	}
	
	
}
