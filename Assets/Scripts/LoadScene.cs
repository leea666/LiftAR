﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void LoadMainScene () {
		SceneManager.LoadScene("Liftar_Main",LoadSceneMode.Single);
	}
	public void LoadPlayScene () {
		SceneManager.LoadScene("LiftAR",LoadSceneMode.Single);
	}
}