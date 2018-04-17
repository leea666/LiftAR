using UnityEngine;
using UnityEngine.Networking;


public class PlayerScript : NetworkBehaviour {

	public bool isthistheserver = false ;
	[SyncVar]
	public int moon;
	[SyncVar]
	public int rocket;
	[SyncVar]
	public int helmet ;
	[SyncVar]
	public bool setMoon ;
	[SyncVar]
	public bool setRocket ;
	[SyncVar]
	public bool setHelmet ;

	bool isServer ;
	bool isClient ;

	// Use this for initialization
	void Start () {

	}

	[Server]
	void Cmdcheckifserver() {
//		if(NetworkServer.active) {
			isthistheserver = true;
//		}
	}

	// Update is called once per frame
	void Update () {
//		Debug.Log ("running in update log");
		Cmdcheckifserver ();
		if (Network.isServer) {
//			Debug.Log ("This is running");
			RpcMoonAnswer ();
			RpcRocketAnswer ();
			RpcHelmetAnswer ();
		} else {
			if (!isLocalPlayer) {
				return;
			} else {
				CmdMoonAnswer ();
				CmdRocketAnswer ();
				CmdHelmetAnswer ();
			}
		}
	}

	[Command]
	void CmdMoonAnswer() {
		RpcMoonAnswer();
	}

	[Command]
	void CmdRocketAnswer () {
		RpcRocketAnswer();
	}

	[Command]
	void CmdHelmetAnswer () {
		RpcHelmetAnswer();
	}

	[ClientRpc]
	void RpcMoonAnswer() {
		if (!isLocalPlayer) {
			return;
		} 
		if (GameObject.Find ("ARCamera")) {
			GameObject moonStatus = GameObject.Find ("ARCamera");
			Raycast getMoonAnswer = moonStatus.GetComponent<Raycast> ();
			isServer = getMoonAnswer.checkServer;
			if (isServer == true) {
				moon = getMoonAnswer.moonAnswer;
				setMoon = getMoonAnswer.selectMoonAnswer;
			}
//			Debug.Log ("changing moon answer" + moon);
		}
		if (GameObject.Find ("PlayerObject(Clone)")) {
			GameObject player1 = GameObject.Find ("PlayerObject(Clone)");
			PlayerScript getMoonAnswer = player1.GetComponent<PlayerScript>() ;
			if (getMoonAnswer.moon != 0) {
				moon = getMoonAnswer.moon;
				setMoon = getMoonAnswer.setMoon;
			}
//			Debug.Log ("changing moon answer " + moon);
		}
	}

	[ClientRpc]
	void RpcRocketAnswer() {
		if (!isLocalPlayer) {
			return;
		} 
		if (GameObject.Find ("ARCamera")) {
			GameObject rocketStatus = GameObject.Find ("ARCamera");
			Raycast getRocketAnswer = rocketStatus.GetComponent<Raycast> ();
			isServer = getRocketAnswer.checkServer;
			if (isServer == true) {
				rocket = getRocketAnswer.rocketAnswer;
				setRocket = getRocketAnswer.selectRocketAnswer;
			}
		}
		if (GameObject.Find ("PlayerObject(Clone)")) {
			GameObject player1 = GameObject.Find ("PlayerObject(Clone)");
			PlayerScript getRocketAnswer = player1.GetComponent<PlayerScript>() ;
			if (getRocketAnswer.rocket != 0) {
				rocket = getRocketAnswer.rocket;
				setRocket = getRocketAnswer.setRocket;
			}
//			Debug.Log ("changing rocket answer " + rocket);
		}
	}

	[ClientRpc]
	void RpcHelmetAnswer() {
		if (!isLocalPlayer) {
			return;
		} 
		if (GameObject.Find ("ARCamera")) {
			GameObject helmetStatus = GameObject.Find ("ARCamera");
			Raycast getHelmetAnswer = helmetStatus.GetComponent<Raycast> ();
			isServer = getHelmetAnswer.checkServer;
			if (isServer == true) {
				helmet = getHelmetAnswer.helmetAnswer;
				setHelmet = getHelmetAnswer.selectHelmetAnswer;
			}
//			Debug.Log ("changing helmet answer" + helmet);
		}
		if (GameObject.Find ("PlayerObject(Clone)")) {
			GameObject player1 = GameObject.Find ("PlayerObject(Clone)");
			PlayerScript getHelmetAnswer = player1.GetComponent<PlayerScript>() ;
			if (getHelmetAnswer.helmet != 0) {
				helmet = getHelmetAnswer.helmet;
				setHelmet = getHelmetAnswer.setHelmet;
			}
//			Debug.Log ("changing helmet answer " + helmet);
		}
	}
}

//149.31.225.116
