using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlphaChanger : MonoBehaviour
{
	
	private Image image;
	
	void Start ()
	{
		image = GetComponent<Image> ();
	}
	
	void Update ()
	{
		
	}
	
	public void ButtonClicked ()
	{
		for (int i = 0; i < 1000; i++) {
			for (int j = 0; j < 500; j++) {
				image.sprite.texture.SetPixel (i, j, new Color (255f, 255f, 255f, 0f));
			}
		}

//		for (int i = (int) vec.x; i < (int)rt.rect.width; i++) {
//			for (int j = (int) vec.y; j <(int)rt.rect.height; j++) {
//				image.sprite.texture.SetPixel (i, j, new Color (0, 0, 0, 0));
//			}
//		}
		image.sprite.texture.Apply ();
	}
	
	public void ApagarArea (Transform tr, RectTransform rt)
	{
		Camera camera = GameObject.Find ("Camera").GetComponent<Camera> ();
		Vector3 screenPos = camera.WorldToScreenPoint (tr.position);

		Debug.Log (rt.anchoredPosition.ToString ());
		Debug.Log ("width: " + rt.rect.width);
		Debug.Log ("height: " + rt.rect.height);

//		for (int i = (int) vec.x; i < (int)rt.rect.width; i++) {
//			for (int j = (int) vec.y; j <(int)rt.rect.height; j++) {
//				image.sprite.texture.SetPixel (i, j, new Color (0, 0, 0, 0));
//			}
//		}
		int x = (int)rt.anchoredPosition.x;
		int y = (int)rt.anchoredPosition.y;

		for (int i = x; i < x + rt.rect.width; i++) {
			for (int j = y; j < y+ rt.rect.height; j++) {
				image.sprite.texture.SetPixel (i, j, new Color (255f, 255f, 255f, 0f));
			}
		}
		image.sprite.texture.Apply ();
	}
}
