using UnityEngine;
using System.Collections;

public class BonePickup : MonoBehaviour
{
	public string letter = "A";
	public float stayTime;
	// Use this for initialization

	public void setLetter (string newLetter)
	{
		letter = newLetter;
		TextMesh textMesh = GetComponentInChildren<TextMesh> ();
		textMesh.text = letter;
	}

	void Start ()
	{
		stayTime = 0;
		TextMesh textMesh = GetComponentInChildren<TextMesh> ();
		textMesh.text = letter;
	}
	
	// Update is called once per frame
	void Update ()
	{
		stayTime += Time.deltaTime;
		if (stayTime >= 9) {
			float alpha = (10 - stayTime) / 1.0f;
			alpha = (alpha < 0) ? 0 : alpha;
			fadeColorAlpha (alpha);
		}
	}

	void fadeColorAlpha (float alpha)
	{
		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
		TextMesh mesh = GetComponentInChildren<TextMesh> ();
		Color c = renderer.color;
		c.a = alpha;
		renderer.color = c;
		c = mesh.color;
		c.a = alpha;
		mesh.color = c;
	}

}
