using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour 
{
	public Color[] colorPalette;		
	public Color curColor;				
	public Color curOddColor; 			

	public GameObject[] colorSquares;	
	public int oddColorSquare;		

	public float difficultyModifier;   
	public int round;					
	public int score;					

	public GameMode gameMode;			

	public float timer;					
	public float eliminationTime; 	
	

	void Awake ()
	{
		round = 0;	
		score = 0;	

		gameMode = (GameMode)PlayerPrefs.GetInt("GameMode"); 

		NewRound();		
	}

	void Update ()
	{
		if(gameMode == GameMode.TIME_RUSH){	
			timer += 1.0f * Time.deltaTime;

			if(timer >= eliminationTime){ 
				FailGame();
			}
		}
	}

	void NewRound ()
	{
		difficultyModifier /= 1.08f; 	
		round++;						
		timer = 0.0f;					

		curColor = colorPalette[Random.Range(0, colorPalette.Length - 1)];	
		float diff = ((1.0f / 255.0f) * difficultyModifier);
		curOddColor = new Color(curColor.r - diff, curColor.g - diff, curColor.b - diff);

		oddColorSquare = Random.Range(0, colorSquares.Length - 1);	

		for(int x = 0; x < colorSquares.Length; x++){	
			if(x == oddColorSquare){								
				colorSquares[x].GetComponent<Image>().color = curOddColor;
			}else{																			
				colorSquares[x].GetComponent<Image>().color = curColor;
			}
		}
	}

	void FailGame ()
	{
		if(score > PlayerPrefs.GetInt("Highscore")){	
			PlayerPrefs.SetInt("Highscore", score);
		}
		LoadMenu();	
	}

	public void CheckSquare (GameObject square)	 
	{
		if(colorSquares[oddColorSquare] == square){	
			NewRound();
			score += 10;
		}else{				
			FailGame();													
		}
	}	

	public void LoadMenu ()		
	{	
		Application.LoadLevel("Menu");			
	}
}

public enum GameMode {NORMAL = 0, TIME_RUSH = 1}
