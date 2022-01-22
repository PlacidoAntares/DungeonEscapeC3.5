using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AD_Manager : MonoBehaviour
{
	private string gameId;
	public bool is_IOS;
	/* #if Unity_IOS
	gameId = "4152821";
	#elif Unity_ANDROID
	gameId = "4152820";
	#endif */
	//rewardedVideo//
	
	bool testMode = true;
	void Start()
	{
		if(is_IOS == true)
		{
			gameId = "4152821";
		}
		else
		{
			gameId = "4152820";
		}
		

		Advertisement.Initialize(gameId,testMode);
	}
	
	public void ShowInterstitialAd()
	{
		if(Advertisement.IsReady())
		{
			Advertisement.Show();
		}
		
		else
		{
			Debug.Log("Interstitial Ad not ready");
		}
	}
	
	
    public void ShowRewardedAd()
	{
		Debug.Log("Showing AD");
		//check if ad is ready
		
		if(Advertisement.IsReady("rewardedVideo"))
		{
			
			var options = new ShowOptions
			{
				resultCallback = HandleShowResult 
			};
			
			Advertisement.Show("rewardedVideo",options);
		}
		else
		{
			Debug.Log("Ad is not ready");
		}
	}
	
	void HandleShowResult(ShowResult result)
	{
		switch(result)
		{
			case ShowResult.Finished:
			//award gems
			GameManager.Instance.Player.AddGems(100);
			UI_Manager.Instance.Open_Shop(GameManager.Instance.Player._gemCount);
			//award gems end
			Debug.Log("Gems awarded");
			break;
			case ShowResult.Skipped:
			Debug.Log("No gems for you");
			break;
			case ShowResult.Failed:
			Debug.Log("Video failed to load");
			break;
		}
	}
}
