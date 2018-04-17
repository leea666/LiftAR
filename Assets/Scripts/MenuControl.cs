using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MenuControl : MonoBehaviour {
	public bool isClient = false;

	public void StartLocalGame()
	{
		NetworkManager.singleton.StartHost();
	}
	
	public void JoinLocalGame()
	{
		if (hostNameInput.text != "Hostname")
		{
			NetworkManager.singleton.networkAddress = hostNameInput.text;
		}	
		isClient = true; 
		NetworkManager.singleton.StartClient();

	}

	
	public void StartMatchMaker()
	{
		NetworkManager.singleton.StartMatchMaker();
	}

	public void ExitGame()
	{
		if (NetworkServer.active)
		{
			NetworkManager.singleton.StopServer();
		}
		if (NetworkClient.active)
		{
			NetworkManager.singleton.StopClient();
		}
	}

	public void CloseHost()
	{
		NetworkManager.singleton.StopHost();
	}

	public void CloseClient()
	{
		NetworkManager.singleton.StopClient();
	}

	public UnityEngine.UI.Text hostNameInput;


	void Start()
	{
		hostNameInput.text = NetworkManager.singleton.networkAddress;
	}
	
}
