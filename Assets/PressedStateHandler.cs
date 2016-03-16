using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PressedStateHandler : MonoBehaviour, IPointerUpHandler,IPointerDownHandler
{
	public GameController controller;

	public void OnPointerUp (PointerEventData eventData)
	{
		controller.onTouchUp (this, this.GetComponent<Button> ());
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		controller.onTouchDown (this, this.GetComponent<Button> ());
	}
}
