using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour 
{
	public Game game;	

	public Text score;	
	public Text timer; 
	void Start ()
	{
		if(game.gameMode == GameMode.TIME_RUSH){ 
			timer.gameObject.active = true;
		}else{
			timer.gameObject.active = false;
		}
	}

	void Update ()
	{
		score.text = game.score.ToString();	

		if(game.gameMode == GameMode.TIME_RUSH){ 
			timer.text = "Time Left: " + (game.eliminationTime - (int)game.timer).ToString();
		}
	}
}
