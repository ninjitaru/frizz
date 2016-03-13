using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void onPauseClicked ()
	{
		print ("pause game");
	}

	// -1 left , 1 right
	public void onWalkTowardDirationClicked (int direction)
	{
		print ("walk toward int received " + direction);
		if (direction >= 1) {
			print ("walk right");
		} else if (direction <= -1) {
			print ("walk left");
		}
	}

	// 1 - jump
	// 2 - bark
	// 3 - eat
	public void onActionClicked (int action)
	{
		print ("action int received " + action);
		switch (action) {
		case 1:
			print ("jump");
			break;
		case 2:
			print ("bark");
			break;
		case 3:
			print ("eat");
			break;
		}
	}
}
