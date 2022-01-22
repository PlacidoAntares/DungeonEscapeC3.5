using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Script : MonoBehaviour
{
    public GameObject _shopPanel;
	public GameObject _selector;
	public int [] _shopPrices;
	public int _shopPricesID;
	protected int currentSelectedItem;
	protected int  currentItemCost;
	[SerializeField]
	protected Player _player;
	void OnTriggerEnter2D(Collider2D other)
	{
		//_player = other.GetComponent<Player>();
		
		if(other.tag == "Player")
		{
			if(_player != null)
			{
				UI_Manager.Instance.Open_Shop(_player._gemCount);
			}
			_shopPanel.SetActive(true);
			_selector.SetActive(false);
		
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			_shopPanel.SetActive(false);
			_selector.SetActive(false);
		}
	}
	
	public void Select_Item(int item)
	{
		//0 = flame sword
		//1 = boots
		//2 = key 
		Debug.Log("Item selected:" + item);
		switch(item)
		{
			case 0:
			_selector.SetActive(true);
			UI_Manager.Instance.UpdateSelection(78);
			currentSelectedItem = 0;
			currentItemCost = _shopPrices[0];
			Debug.Log("Item 0 costs:" + currentItemCost);
			_shopPricesID = 0;
			break;
			
			case 1:
			_selector.SetActive(true);
			currentSelectedItem = 1;
			UI_Manager.Instance.UpdateSelection(-19);
			currentItemCost = _shopPrices[1];
			Debug.Log("Item 1 costs:" + currentItemCost);
			_shopPricesID = 1;
			break;
			
			case 2:
			_selector.SetActive(true);
			currentSelectedItem = 2;
			currentItemCost = _shopPrices[2];
			UI_Manager.Instance.UpdateSelection(-127);
			Debug.Log("Item 2 costs:" + currentItemCost);
			_shopPricesID = 2;
			break;
			
			default:
			_selector.SetActive(true);
			UI_Manager.Instance.UpdateSelection(78);
			currentSelectedItem = 0;
			currentItemCost = _shopPrices[0];
			Debug.Log("Item 0 costs:" + currentItemCost);
			_shopPricesID = 0;
			break;
		}
	}
	
	public void Buy_Item()
	{
		
		
			if(_player._gemCount >= currentItemCost)
			{
				Debug.Log("Purchased item:" + _shopPricesID);
				switch(_shopPricesID)
				{
					case 0:
					//award sword
					break;
					
					case 1:
					//award boots
					break;
					
					case 2:
					GameManager.Instance.HasKeyToCastle = true;
					
					break;
					
					
				}
				_player.AddGems(-currentItemCost);
				_shopPanel.SetActive(false);
			}
			else if(_player._gemCount < currentItemCost)
			{
				Debug.Log("Not enough Gems");
				_shopPanel.SetActive(false);
			}
		if(_player != null)
			{
				UI_Manager.Instance.Open_Shop(_player._gemCount);
			}
		
	}
}
