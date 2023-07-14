using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour 
{
	public GameObject mainMenuPage;
	public GameObject playPage;
	public GameObject optionsPage;
	public GameObject LeaderboardPage;
	private LeaderboardManager leaderboardManager;
	public Text highscoreText;

	void Start ()
	{
		leaderboardManager = GetComponent<LeaderboardManager>();
		highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
		SetPage("Menu");
	}

	public void SetPage (string page)
	{
		switch(page){
			case "Menu":{
				mainMenuPage.active = true;
				playPage.active = false;
				optionsPage.active = false;
				LeaderboardPage.active=false;
				break;
			}
			case "Play":{
				mainMenuPage.active = false;
				playPage.active = true;
				optionsPage.active = false;
				LeaderboardPage.active=false;
				break;
			}
			case "Options":{
				mainMenuPage.active = false;
				playPage.active = false;
				optionsPage.active = true;
				LeaderboardPage.active=false;
				break;
			}
			case "Leaderboard":{
				mainMenuPage.active = false;
				playPage.active = false;
				optionsPage.active = false;
				LeaderboardPage.active=true;
				break;
			}
		}
	}


	public int highscore{
        get { return PlayerPrefs.GetInt("Highscore"); }
    }

    public void AddScore() 
    {
        leaderboardManager.AddScore();
    }

	public void PlayGame (int gameMode)
	{
		PlayerPrefs.SetInt("GameMode", gameMode);
		Application.LoadLevel("Game");
	}

	public void ResetHighscore ()
	{
		PlayerPrefs.SetInt("Highscore", 0);
		highscoreText.text = "Highscore: 0";
	}

	public void QuitGame ()
	{
		Application.Quit();
	}
}
