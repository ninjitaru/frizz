using UnityEngine;
using System.Collections;

public class TouchControl : MonoBehaviour
{
	public LayerMask mask = -1;
	// Use this for initialization
	void Start ()
	{
		mask = LayerMask.NameToLayer ("UI");
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetMouseButtonUp (0)) {
			Vector2 pos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			RaycastHit2D hitInfo = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (pos), Vector2.zero);
			if (hitInfo) {
				Debug.Log (hitInfo.transform.gameObject.name);
				// Here you can check hitInfo to see which collider has been hit, and act appropriately.
			}
		} else {
			if (Input.touchCount >= 1 && Input.GetTouch (0).phase == TouchPhase.Ended) {
				Vector2 pos = new Vector2 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y);
				RaycastHit2D hitInfo = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (pos), Vector2.zero);
				if (hitInfo) {
					Debug.Log (hitInfo.transform.gameObject.name);
					// Here you can check hitInfo to see which collider has been hit, and act appropriately.
				}

			}
		}

	}
}
