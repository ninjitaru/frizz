using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
	// 0 select language
	// 1 select difficulty
	// 2 select level
	// 3 game level (hand off)
	public int menuState = 0;

	private GameObject languageMenu;
	private GameObject difficultyMenu;
	private GameObject backButton;

	public static MenuController instance = null;

	void Awake ()
	{
		if (instance == null) {
			Object.DontDestroyOnLoad (this);
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	void Start ()
	{
		if (instance == this) {
			transitionToMenuState (menuState);
		}
	}

	public void onBackClicked ()
	{
		switch (menuState) {
		case 0:
			// noop
			break;
		default:
			transitionToMenuState (menuState - 1);
			break;
		}
	}

	private void transitionToMenuState (int menuState)
	{
		print ("target menu state " + menuState);
		this.menuState = menuState;
		if (loadSceneForMenuState (menuState)) {
			print ("skip from loading scene");
			return;
		}

		switch (menuState) {
		case 0:
			getOpeningMenuComponents ();
			languageMenu.SetActive (true);
			difficultyMenu.SetActive (false);
			backButton.SetActive (false);
			break;
		case 1:
			getOpeningMenuComponents ();
			languageMenu.SetActive (false);
			difficultyMenu.SetActive (true);
			backButton.SetActive (true);
			break;
		case 2:
			setLevelSelectionComponents ();
			break;
		}
	}

	private bool loadSceneForMenuState (int menuState)
	{
		string scenename = "OpeningScene";
		switch (menuState) {
		case 0:
		case 1:
			scenename = "OpeningScene";
			break;
		case 2:
			scenename = "LevelSelect";
			break;
		case 3:
			Setting.Instance.gameScore = 0;
			scenename = "GameLevel";
			break;
		}
		if (SceneManager.GetActiveScene ().name != scenename) {
			SceneManager.LoadSceneAsync (scenename, LoadSceneMode.Single); // single unload the current scene
			return true;
		}
		return false;
	}

	public void OnLevelWasLoaded (int level)
	{
		if (instance == this) {
			transitionToMenuState (menuState);
		}
	}

	public static int FastParseInt (string value)
	{
		int result = 0;
		for (int i = 0; i < value.Length; i++) {
			char letter = value [i];
			result = 10 * result + (letter - 48);
		}
		return result;
	}

	private void setLevelSelectionComponents ()
	{
		if (backButton != null) {
			return;
		}
		RectTransform[] rects = Object.FindObjectOfType<Canvas> ().GetComponentsInChildren<RectTransform> ();
		foreach (RectTransform rect in rects) {
			if (rect.name == "levels") {
				foreach (Button button in rect.GetComponentsInChildren<Button>()) {
//					print ("substring is " + button.name.Substring (6));
					int levelValue = FastParseInt (button.name.Substring (6));
//					print ("level is " + levelValue);
					button.GetComponent<Button> ().onClick.AddListener (() => {
						print ("button level value " + levelValue);
						Setting.Instance.gameLevel = levelValue;
						transitionToMenuState (3);
					});
				}
			} else if (rect.name == "backBtn") {
				backButton = rect.gameObject;
				backButton.GetComponent<Button> ().onClick.AddListener (() => {
					onBackClicked ();
				});
			}
		}
	}

	private void getOpeningMenuComponents ()
	{
		if (languageMenu == null) {
			RectTransform[] rects = Object.FindObjectOfType<Canvas> ().GetComponentsInChildren<RectTransform> ();
			foreach (RectTransform rect in rects) {
				if (rect.name == "languageSelect") {
					languageMenu = rect.gameObject;
					foreach (Button button in languageMenu.GetComponentsInChildren<Button>()) {
						int lanaugeValue = 0;
						if (button.name == "usBtn") {
							lanaugeValue = 1;
						}
						button.GetComponent<Button> ().onClick.AddListener (() => {
							onLanguagedClicked (lanaugeValue);
						});
					}
				} else if (rect.name == "difficultySelect") {
					difficultyMenu = rect.gameObject;
					foreach (Button button in difficultyMenu.GetComponentsInChildren<Button>()) {
						int difficultySetting = 0;
						if (button.name == "midBtn") {
							difficultySetting = 1;
						} else if (button.name == "hardBtn") {
							difficultySetting = 2;
						}
						button.GetComponent<Button> ().onClick.AddListener (() => {
							onDifficultyClicked (difficultySetting);
						});
					}
				} else if (rect.name == "backBtn") {
					backButton = rect.gameObject;
					backButton.GetComponent<Button> ().onClick.AddListener (() => {
						onBackClicked ();
					});
				}
			}
		}
	}

	public void onLanguagedClicked (int language)
	{
		print ("lanauge " + language);
		Setting.Instance.language = language;
		transitionToMenuState (1);
	}

	public void onDifficultyClicked (int difficulty)
	{
		print ("difficulty " + difficulty);
		Setting.Instance.difficulty = difficulty;
		transitionToMenuState (2);
	}
}
