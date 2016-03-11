using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour
{

	void Awake ()
	{
		if (GameManager.Instance.currentScene == null) {
			GameManager.Instance.setScene (GameManager.kSceneLanguageSelect);
		}
	}
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
