using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{

	// Use this for initialization
	public SpriteRenderer targetSprite;

	void Awake ()
	{
		if (targetSprite) {
			float worldScreenHeight = Camera.main.orthographicSize * 2;
			float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

			if (worldScreenHeight != targetSprite.sprite.bounds.size.y) {
				float scale = worldScreenHeight / targetSprite.sprite.bounds.size.y;
				Setting.Instance.backgroundScale = scale;
				print ("global scale is" + scale);
				transform.localScale = new Vector3 (
					scale,
					scale, 1);
			}
		}
	}
}
