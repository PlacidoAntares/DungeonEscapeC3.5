using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
	
    private static UI_Manager _instance;
	public static UI_Manager Instance
	
	{
		get
		{
			if(_instance == null)
			{
				//Debug.LogError("UI Manager is null");
			}
			return _instance;
		}
	}
	
	public Text player_GemCount_Text;
	public Text gemCountText;
	public Image selection_Img;
	public GameObject[] _healthBars;
	//open shop
	
	private void Awake()
	{
		_instance = this;
	}
	
	public void Open_Shop(int gemCount)
	{
		player_GemCount_Text.text = "Gems:" + gemCount + "G";
	}
	
	public void UpdateGemCount(int count)
	{
		gemCountText.text = "" + count;
	}
	
	public void UpdateHealth(int lifeUnitID)
	{
		_healthBars[lifeUnitID].SetActive(false);
	}
	public void UpdateSelection(int yPos)
	{
		selection_Img.rectTransform.anchoredPosition = new Vector2 (selection_Img.rectTransform.anchoredPosition.x,yPos);
	}
}
