using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{

	// Use this for initialization

	void Awake ()
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();

		float worldScreenHeight = Camera.main.orthographicSize * 2;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		if (worldScreenHeight != sr.sprite.bounds.size.y) {
			float scale = worldScreenHeight / sr.sprite.bounds.size.y;
			Setting.Instance.backgroundScale = scale;
			print ("global scale is" + scale);
			transform.localScale = new Vector3 (
				scale,
				scale, 1);
		}
	}

	void Start ()
	{
		

	}

	// Update is called once per frame
	void Update ()
	{
	
	}
}
