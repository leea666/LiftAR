using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animScript2 : MonoBehaviour {

	public GameObject fourth;


	Animator anim;


	// Use this for initialization
	void Start () {
		anim = fourth.GetComponent<Animator> ();

	}


	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "trigger") {
			anim.SetTrigger ("TriggerMoon");

		
		}


	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "trigger") {
			anim.SetTrigger ("TriggerMoon");


	}
}
}
