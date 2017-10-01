using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartBehaviour : MonoBehaviour {

	public bool hitBoard;
	public bool hitWall;

	int countFrames;

	void Start()
	{
		hitWall = false;
		hitBoard = false;
		countFrames = 0;
	}

	void Update () 
	{

		if(hitWall || hitBoard || countFrames > 300){
			GameObject.FindGameObjectWithTag("UI").GetComponent<UIScript>().countShots++;
			GameObject.FindGameObjectWithTag("UI").GetComponent<UIScript>().SetShotText();
			getScore();
			this.tag = "Untagged";
			Destroy(this);
			GameObject newDart = Instantiate(Resources.Load("Dart")) as GameObject;
		}

		if(this.GetComponent<Collider>().attachedRigidbody.useGravity){
				Vector3 velocity = new Vector3();
				velocity = this.GetComponent<Rigidbody>().velocity;
				this.transform.rotation = Quaternion.LookRotation(velocity, Vector3.up);
				countFrames++;
		}
	}

	void getScore()
	{
		if(hitBoard)
		{	
			Vector3 a = new Vector3(GameObject.Find("Board").transform.position.x, GameObject.Find("Board").transform.position.y, GameObject.Find("Board").transform.position.z);
			Vector3 b = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
			float newScore = 60 - Vector3.Distance(a, b) * 100;

			GameObject.FindGameObjectWithTag("UI").GetComponent<UIScript>().score += newScore;
			GameObject.FindGameObjectWithTag("UI").GetComponent<UIScript>().SetScoreText();
		}
	}
}
