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
		GameManager.Instance.performUIAction (this);
	}
}

