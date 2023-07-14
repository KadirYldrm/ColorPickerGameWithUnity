using UnityEngine;
using System.Collections;

public class ColorSquare : MonoBehaviour 
{
	public Game game;	

	void OnMouseDown ()					
	{
		game.CheckSquare(gameObject);
	}
}
