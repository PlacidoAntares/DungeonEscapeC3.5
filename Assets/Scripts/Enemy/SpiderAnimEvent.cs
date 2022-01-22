using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimEvent : MonoBehaviour
{
	private Spider _spider;
	
	public void Start()
	{
		_spider = transform.parent.GetComponent<Spider>();
	}
	
    public void spider_attack()
	{
		_spider.Attack();
	}
}
