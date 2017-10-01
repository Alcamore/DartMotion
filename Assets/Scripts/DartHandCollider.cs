using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class DartHandCollider : MonoBehaviour {

	public bool touched;
	public float pinch;

	Hand hand;
	bool pinched;

	void Start()
	{	
		pinch = 0.0f;
		Physics.gravity = new Vector3(0, -3.0f, 0);
		touched = false;
	}

	void OnTriggerEnter (Collider other) 
	{
		if(other.gameObject.tag == "Dart") {
			touched = true;
		}
	}

	void FixedUpdate()
	{
		Controller controller = new Controller();
		Frame frame = controller.Frame();

		if (frame.Hands.Count > 0) {
			hand = frame.Hands[0];
		}

		pinch = hand.PinchStrength;

		if (touched && pinch > 0.6f) {	
			GameObject.FindGameObjectWithTag ("Dart").GetComponent<Collider>().attachedRigidbody.useGravity = false;
			GameObject.FindGameObjectWithTag ("Dart").transform.position = this.transform.position;
			GameObject.FindGameObjectWithTag ("Dart").transform.rotation = this.transform.rotation;
			pinched = true;

			if(GameObject.Find("UI").GetComponent<UIScript>().gameIsOver){
				GameObject.Find("UI").GetComponent<UIScript>().Reset();
			}

			Vector3 velocity = new Vector3 ();
			velocity = this.GetComponent<Rigidbody> ().velocity * 1.5f;
			GameObject.FindGameObjectWithTag ("Dart").GetComponent<Rigidbody> ().velocity = velocity;

		} else if (touched && pinch <= 0.6f && pinched) {
			GameObject.FindGameObjectWithTag ("Dart").GetComponent<Collider>().attachedRigidbody.useGravity = true;
			touched = false;
			pinched = false;
		}
	}
}
