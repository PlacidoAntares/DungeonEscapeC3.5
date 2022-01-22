using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnStart : MonoBehaviour
{
	public GameObject[] enableObjs;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < enableObjs.Length;i++)
		{
			enableObjs[i].SetActive(true);
			Debug.Log(enableObjs[i]);
		}
    }
}
