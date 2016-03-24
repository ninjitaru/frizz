using UnityEngine;
using System.Collections;

public class Text3DTo2D : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		GetComponent<MeshRenderer> ().sortingLayerName = "Character";
		GetComponent<MeshRenderer> ().sortingOrder = 2;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
