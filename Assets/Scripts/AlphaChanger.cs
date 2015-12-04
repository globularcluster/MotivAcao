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
	
//	public void ButtonClicked ()
//	{
//		
//		for (int i = 0; i < 200; i++) {
//			for (int j = 0; j < 200; j++) {
//				image.sprite.texture.SetPixel (i, j, new Color (0, 0, 0, 0));
//			}
//		}
//		image.sprite.texture.Apply ();
//	}
	
	public void ApagarArea (Vector3 vec, RectTransform rt)
	{
		Debug.Log ("ok");
		Debug.Log (vec.x);
		Debug.Log (rt.rect.width);

		for (int i = 0; i < 200; i++) {
			for (int j = 0; j < 200; j++) {
				image.sprite.texture.SetPixel (i, j, new Color (0, 0, 0, 0));
			}
		}
		image.sprite.texture.Apply ();
	

//		for (int i = (int) vec.x; i < (int)rt.rect.width; i++) {
//			for (int j = (int) vec.y; j <(int)rt.rect.height; j++) {
//				image.sprite.texture.SetPixel (i, j, new Color (0, 0, 0, 0));
//			}
//		}
	}
}
