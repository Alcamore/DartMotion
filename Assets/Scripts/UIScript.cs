using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

	public Text shotCounter;
	public Text scoreText;
	public Text gameOver;
	public Text highScore;

	public int maxShots;
	public int countShots;
	public float score;
	public bool gameIsOver;

	List<float> highScores = new List<float>();

	void Start () 
	{
		shotCounter.text = "";
		scoreText.text   = "";
		gameOver.text    = "";
		highScore.text   = "";
		maxShots = 10;
		countShots = 0;
		score = 0.0f;
		gameIsOver = false;
		SetShotText();
		SetScoreText();
	}

	void Update()
	{
		if (Input.GetKey("escape"))
			Application.Quit();
	}

	public void SetShotText () 
	{
		shotCounter.text = "Shots: " + countShots.ToString() + "/" + maxShots.ToString();
		if(countShots >= maxShots){
			gameIsOver = true;
			gameOver.text = "GAME OVER";
		} 
	}

	public void SetScoreText ()
	{
		int intScore = (int)score;
		scoreText.text = "Score: " + intScore.ToString();
	}

	public void SetHighScoreText()
	{
		highScore.text = "High Scores: " + "\n";

		for(int i = highScores.Count - 1; i >= 0; i--){
			int temp = (int) highScores[i];
			highScore.text += temp.ToString() + "\n";
		}
	}

	public void Reset()
	{
		evaluateScore();
		SetHighScoreText();
		countShots = 0;
		score = 0.0f;
		gameIsOver = false;
		gameOver.text    = "";
		SetShotText();
		SetScoreText();	
	}

	void  evaluateScore()
	{
		highScores.Add(score);
		highScores.Sort();
		if(highScores.Count > 3){
			highScores.RemoveAt(0);
		}
	}
}
