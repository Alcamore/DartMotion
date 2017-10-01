using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCollisionHandler : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Dart") {
			GameObject.FindGameObjectWithTag ("Dart").GetComponent<DartBehaviour>().hitBoard = true;
			other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			other.gameObject.GetComponent<Collider>().attachedRigidbody.useGravity = false;
		}
	}
}
