using UnityEngine;
using System.Collections;

public class GameBackground : MonoBehaviour
{
	public Sprite[] sprites;

	void Start ()
	{
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer> ();

		int level = Setting.Instance.gameLevel;
		if (level == 0) {
			level = 1;
		} else if (level > 11) {
			level = 11;
		}
		print ("game level " + level);
		sRenderer.sprite = sprites [level - 1];
	}
}
