using UnityEngine;
using System.Collections;

public class RelativeScale : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		float scale = Setting.Instance.backgroundScale;
		Vector3 currentScale = transform.localScale;

		transform.localScale = new Vector3 (
			currentScale.x * scale,
			currentScale.y * scale, 1);
	}

	// Update is called once per frame
	void Update ()
	{

	}
}