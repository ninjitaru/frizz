using UnityEngine;
using System.Collections;

public class LevelLayoutManager : MonoBehaviour
{

	public GameObject[] levelButtons;
	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < levelButtons.Length; i++) {
			levelButtons [i].GetComponent<Touchable> ().targetValue = i + 1;
		}
//		Transform[] transforms = GetComponentsInChildren<Transform> ();
//		levelButtons = new GameObject[transforms.Length];
//		for (int i = 0; i < transforms.Length; i++) {
//			GameObject theObject = transforms [i].gameObject;
//			levelButtons [i] = theObject;
//		}
//		float screenWidth = Screen.width;
//		float screenHeight = Screen.height;
//		print ("width " + Camera.main.ScreenToWorldPoint (new Vector3 (0, screenHeight / 2, 0)));
//		print ("height " + Camera.main.ScreenToWorldPoint (new Vector3 (screenWidth, -screenHeight / 2, 0)));
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
