using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
	public static string kSceneLanguageSelect = "SceneLanguageSelect";
	public static string kSceneDifficultySelect = "SceneDifficultySelect";
	public static string kSceneLevelSelect = "SceneLevelSelect";

	public GameObject[] controlNodes;

	public string currentScene = kSceneLanguageSelect;

	protected GameManager ()
	{
	}

	public void setScene (string name)
	{
		print ("to scene " + name);
		if (name == kSceneLanguageSelect) {
			GameObject node = controlNodes [0];
			node.SetActive (true);
			node = controlNodes [1];
			node.SetActive (false);
			node = controlNodes [2];
			node.SetActive (false);
		} else if (name == kSceneDifficultySelect) {
			GameObject node = controlNodes [0];
			node.SetActive (false);
			node = controlNodes [1];
			node.SetActive (true);
			node = controlNodes [2];
			node.SetActive (true);
		} else if (name == kSceneLevelSelect) {
			
		}
		currentScene = name;

	}

	public void toPreviousScene ()
	{
		if (currentScene == kSceneDifficultySelect) {
			setScene (kSceneLanguageSelect);
		} else if (currentScene == kSceneLevelSelect) {
			setScene (kSceneDifficultySelect);
		}
	}
}