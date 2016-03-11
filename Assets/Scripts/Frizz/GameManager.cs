using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
	public static string kSceneLanguageSelect = "SceneLanguageSelect";
	public static string kSceneDifficultySelect = "SceneDifficultySelect";
	public static string kSceneLevelSelect = "SceneLevelSelect";
	public static string kSceneGameLevel = "SceneGameLevel";

	public GameObject[] controlNodes;
	int controlValue;

	public string currentScene = null;

	protected GameManager ()
	{
		
	}

	public void performUIAction (Touchable touchedControl)
	{
		if (touchedControl.isLanguageSelector) {
			Setting.Instance.language = touchedControl.targetValue;
		} else if (touchedControl.isDifficutlySelector) {
			Setting.Instance.difficulty = touchedControl.targetValue;
		}
		print ("set touch targetValue" + touchedControl.targetValue);
		controlValue = touchedControl.targetValue;
		if (touchedControl.requireSceneTransition) {
			setScene (touchedControl.sceneName);
		}
		if (touchedControl.isBackButton) {
			toPreviousScene ();
		}
	}

	public void setupControls ()
	{
		if (controlNodes == null || controlNodes [0] == null) {
			print ("getting control nodes");
			controlNodes = new GameObject[3];
			UIGroupNode[] groups = Object.FindObjectsOfType<UIGroupNode> ();
			for (int i = 0; i < groups.Length; i++) {
				UIGroupNode node = groups [i];
				if (node.name == "languageSelect") {
					controlNodes [0] = node.gameObject;
				} else if (node.name == "difficultySelect") {
					controlNodes [1] = node.gameObject;
				} else {
					controlNodes [2] = node.gameObject;
				}
			}
			//			controlNodes [0] = Object.FindObjectOfType ("");
		}
	}

	//	public void startScene ()
	//	{
	//		setupControls ();
	//		GameObject node = controlNodes [0];
	//		node.SetActive (true);
	//		node = controlNodes [1];
	//		node.SetActive (false);
	//		node = controlNodes [2];
	//		node.SetActive (false);
	//		currentScene = kSceneLanguageSelect;
	//	}

	public void setScene (string name)
	{
		
		print ("to scene " + name);
		if (name == kSceneLanguageSelect) {
			if (SceneManager.GetActiveScene ().name != "OpeningScene") {
				SceneManager.UnloadScene (SceneManager.GetActiveScene ().name);
				SceneManager.LoadScene ("OpeningScene");
			} else {
				setSceneState (name);
			}
		} else if (name == kSceneDifficultySelect) {
			if (SceneManager.GetActiveScene ().name != "OpeningScene") {
				SceneManager.UnloadScene (SceneManager.GetActiveScene ().name);
				SceneManager.LoadScene ("OpeningScene");
			} else {
				setSceneState (name);
			}
		} else if (name == kSceneLevelSelect) {
			controlNodes = null;
			if (SceneManager.GetActiveScene ().name != "LevelSelect") {
				SceneManager.UnloadScene (SceneManager.GetActiveScene ().name);
				SceneManager.LoadScene ("LevelSelect");
			}
		} else if (name == kSceneGameLevel) {
			Setting.Instance.gameLevel = controlValue;
			if (SceneManager.GetActiveScene ().name != "GameLevel") {
				SceneManager.UnloadScene (SceneManager.GetActiveScene ().name);
				SceneManager.LoadScene ("GameLevel");
			}
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

	public void setSceneState (string name)
	{
		if (name == kSceneLanguageSelect) {
			setupControls ();
			GameObject node = controlNodes [0];
			node.SetActive (true);
			node = controlNodes [1];
			node.SetActive (false);
			node = controlNodes [2];
			node.SetActive (false);
		} else if (name == kSceneDifficultySelect) {
			setupControls ();
			GameObject node = controlNodes [0];
			node.SetActive (false);
			node = controlNodes [1];
			node.SetActive (true);
			node = controlNodes [2];
			node.SetActive (true);
		} else if (name == kSceneGameLevel) {
			Background background = Object.FindObjectOfType<Background> ();
			if (background != null) {
				print ("game level to load " + Setting.Instance.gameLevel);
				SpriteRenderer sRenderer = background.GetComponent<SpriteRenderer> ();
				sRenderer.sprite = background.GetComponent<GameBackground> ().sprites [Setting.Instance.gameLevel - 1];
			}
		}
	}

	public void OnLevelWasLoaded (int level)
	{
		setSceneState (currentScene);
	}
}