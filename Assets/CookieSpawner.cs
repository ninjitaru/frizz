using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CookieSpawner : MonoBehaviour
{
	public List<GameObject> cookies;
	public GameObject cookiePrefeb;
	private float fixedTime;

	void Awake ()
	{
		cookies = new List<GameObject> ();
	}

	void Start ()
	{
	
	}

	void FixedUpdate ()
	{
		// remove dead bones 
		// when it stays longer than 12 second
		foreach (GameObject obj in cookies) {
			if (obj.GetComponent<BonePickup> ().stayTime >= 10) {
				cookies.Remove (obj);
				Object.Destroy (obj);
				break;
			}
		}
		// -6.2,6.2
		// 4
		fixedTime += Time.fixedDeltaTime;
		if (fixedTime >= 2) {
			float x = -6.2f + Random.value * 12.4f;
			GameObject newCookie = Instantiate (cookiePrefeb, new Vector3 (x, 4f, 0), Quaternion.identity) as GameObject;
			newCookie.transform.parent = this.transform;
			randomLetterOnBone (newCookie.GetComponent<BonePickup> ());
			cookies.Add (newCookie);
			fixedTime = 0;
		}



	}

	void randomLetterOnBone (BonePickup pickup)
	{
		if (pickup != null) {
			int value = Random.Range (1, 4);
			switch (value) {
			case 1:
				pickup.setLetter ("A");
				break;
			case 2:
				pickup.setLetter ("B");
				break;
			case 3:
				pickup.setLetter ("C");
				break;
			case 4:
				pickup.setLetter ("D");
				break;
			}
		}
	}

	void Update ()
	{
		
	}
}
