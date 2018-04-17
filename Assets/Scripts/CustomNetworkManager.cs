using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class CustomNetworkManager : NetworkManager
{
	private float nextRefreshTime;
	public Text networkAdd;
	public bool isClient = false ;

	public void StartHosting()
	{
		base.StartHost();

//		StartMatchMaker();
//		matchMaker.CreateMatch("Jasons Match", 4, true, "", "", "", 0, 0, OnMatchCreated);
	}
	public void StartClient()
	{
		base.StartClient();
		isClient = true;
		base.networkAddress =  networkAdd.text;
		Debug.Log("lets Try");
		Debug.Log(networkAdd.text);
		//		StartMatchMaker();
		//		matchMaker.CreateMatch("Jasons Match", 4, true, "", "", "", 0, 0, OnMatchCreated);
	}

	//if click I'm Parent (isClient = true;)
//	private void OnMatchCreated(bool success, string extendedinfo, MatchInfo responsedata)
//	{
//		base.StartHost(responsedata);
//		RefreshMatches();
//	}
//
//	private void Update()
//	{
//		if (Time.time >= nextRefreshTime)
//		{
//			RefreshMatches();
//		}
//	}
//
//	private void RefreshMatches()
//	{
//		nextRefreshTime = Time.time + 5f;
//
//		if (matchMaker == null)
//			StartMatchMaker();
//
//		matchMaker.ListMatches(0, 10, "", true, 0, 0, HandleListMatchesComplete);
//	}
//
//	private void HandleListMatchesComplete(bool success, 
//		string extendedinfo, 
//		List<MatchInfoSnapshot> responsedata)
//	{
//		AvailableMatchesList.HandleNewMatchList(responsedata);
//	}
//
//	public void JoinMatch(MatchInfoSnapshot match)
//	{
//		if (matchMaker == null)
//			StartMatchMaker();
//
//		matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, HandleJoinedMatch);
//	}
//
//	private void HandleJoinedMatch(bool success, string extendedinfo, MatchInfo responsedata)
//	{
//		StartClient(responsedata);
//	}
}