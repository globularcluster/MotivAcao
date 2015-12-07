using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloseMenu : MonoBehaviour
{

	public void CloseMenuView ()
	{
		Toggle toggle = GameObject.Find ("btn_arvore").GetComponent<Toggle> ();
		gameObject.SetActive (toggle.isOn);
	}

}
