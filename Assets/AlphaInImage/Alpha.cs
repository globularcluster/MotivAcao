﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Alpha : MonoBehaviour {

	public Image image;

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void ButtonClicked(){

		for (int i = 0; i < 200; i++) {
			for (int j = 0; j < 200; j++) {
				image.sprite.texture.SetPixel (i, j, new Color(0,0,0,0));
			}
		}
		image.sprite.texture.Apply ();
	}
}