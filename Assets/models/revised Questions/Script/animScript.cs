using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animScript : MonoBehaviour {

	public GameObject rocket;

	public GameObject window;

	Animator anim;
	Animator anim2;

	// Use this for initialization
	void Start () {
		anim = rocket.GetComponent<Animator> ();
		anim2 = window.GetComponent<Animator> ();
	}


	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "trigger") {
			anim.SetTrigger ("disappear");
			anim2.SetTrigger ("popWindow");
		
		}


	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "trigger") {
			anim.SetTrigger ("disappear");
			anim2.SetTrigger ("popWindow");

	}
}
}
