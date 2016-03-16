using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
	public GameObject backgroundSprite;
	public Transform targetTransform;
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	// Use this for initialization
	public float minX = 0;
	public float maxX = 0;

	void Start ()
	{
		if (targetTransform) {
			Camera camera = this.GetComponent<Camera> ();
			Vector3 position = this.transform.position;
			position.x = targetTransform.position.x;
			Bounds cameraBounds = CameraExtensions.OrthographicBounds (camera);
			Bounds spriteBounds = backgroundSprite.GetComponent<SpriteRenderer> ().sprite.bounds;
			spriteBounds.extents = spriteBounds.extents * 0.8f;
			minX = spriteBounds.min.x + cameraBounds.extents.x;
			maxX = spriteBounds.max.x - cameraBounds.extents.x;
		}
	}

	void LateUpdate ()
	{
		fixedMove ();
	}

	void fixedMove ()
	{
		if (targetTransform) {
			Camera camera = this.GetComponent<Camera> ();
			Vector3 position = this.transform.position;
			position.x = targetTransform.position.x;
			Bounds cameraBounds = CameraExtensions.OrthographicBounds (camera);
			print (cameraBounds.min + " " + cameraBounds.max);
			if (position.x <= minX) {
				position.x = minX;
			} else if (position.x >= maxX) {
				position.x = maxX;
			}

			this.transform.position = position;
		}
	}

	void dampingMove ()
	{
		if (targetTransform) {
			Camera camera = this.GetComponent<Camera> ();
			Vector3 point = camera.WorldToViewportPoint (targetTransform.position);
			Vector3 delta = targetTransform.position - camera.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			Vector3 position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
//			if (position.y < 0) {
//				position.y = 0;
//			}
			position.y = 0;
			transform.position = position;
		}

	}
}
