﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public FrizzPlayerControl player;
	public CookieSpawner spawner;

	public Button walkLeftButton;
	public Button walkRightButton;
	public Button jumpButton;
	public Button barkButton;
	public Button pickButton;
	public Text scoreBoard;
	// Use this for initialization
	void Start ()
	{
		scoreBoard.text = "0";
//		walkLeftButton.OnPointerUp = () => {
//			player.walkLeft = false;
//		};
//		walkLeftButton.OnPointerDown (() => {
//			player.walkLeft = true;
//		});
	}
	
	// Update is called once per frame
	//	void Update ()
	//	{
	//		if(walkLeftButton.OnPointerDown)
	//	}

	public void onTouchDown (PressedStateHandler handler, Button button)
	{
		if (button == walkLeftButton) {
			player.walkLeft = true;
		}
		if (button == walkRightButton) {
			player.walkRight = true;
		}
		if (button == jumpButton) {
			player.Jump ();
		}
	}

	public void onTouchUp (PressedStateHandler handler, Button button)
	{
		if (button == walkLeftButton) {
			player.walkLeft = false;
		}
		if (button == walkRightButton) {
			player.walkRight = false;
		}
	}

	public void onPauseClicked ()
	{
		MenuController.instance.onBackClicked ();
		print ("pause game");
	}

	//	// -1 left , 1 right
	//	public void onWalkTowardDirationClicked (int direction)
	//	{
	////		print ("walk toward int received " + direction);
	//		if (direction >= 1) {
	//			player.MoveRight ();
	////			print ("walk right");
	//		} else if (direction <= -1) {
	//			player.MoveLeft ();
	////			print ("walk left");
	//		}
	//	}

	// 1 - jump
	// 2 - bark
	// 3 - eat
	public void onActionClicked (int action)
	{
		print ("action int received " + action);
		switch (action) {
		case 1:
//			player.Jump ();
			break;
		case 2:
			print ("bark");
			break;
		case 3:
			{
				GameObject cookieEaten = player.EatCookie (spawner.cookies.ToArray ());
				if (cookieEaten != null) {
					BonePickup pickerup = cookieEaten.GetComponent<BonePickup> ();
					if (pickerup.letter == "A") {
						Setting.Instance.gameScore += 1;
						scoreBoard.text = "" + Setting.Instance.gameScore;
					}
					spawner.cookies.Remove (cookieEaten);
					Object.Destroy (pickerup.gameObject);
				}
				break;
			}
		}
	}
}
