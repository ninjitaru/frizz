using UnityEngine;
using System.Collections;

public class Touchable : MonoBehaviour
{
	public bool isLanguageSelector;
	public bool isDifficutlySelector;
	public bool requireSceneTransition;
	public int targetValue = -1;
	public string sceneName;

	public bool isBackButton;

	public void performAction ()
	{
		if (isLanguageSelector) {
			Setting.Instance.language = targetValue;
		} else if (isDifficutlySelector) {
			Setting.Instance.difficulty = targetValue;
		}
		if (requireSceneTransition) {
			GameManager.Instance.setScene (sceneName);
		}
		if (isBackButton) {
			GameManager.Instance.toPreviousScene ();
		}

	}
}

