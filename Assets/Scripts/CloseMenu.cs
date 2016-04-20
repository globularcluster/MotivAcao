using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloseMenu : MonoBehaviour
{
	public GameObject menu;
	public Toggle anotherBtn;
	public GameObject drops;

	private Toggle toggle;

	void Start ()
	{
		toggle = gameObject.GetComponent<Toggle> ();
	}

	// Função utilizada no event OnValueChanged de botões que abrem um menu
	public void CloseMenuView ()
	{
		
		if (toggle.isOn) {
			menu.SetActive (toggle.isOn);
			drops.transform.SetAsLastSibling ();

			if (anotherBtn.isOn)
				anotherBtn.isOn = false;
		} else
			menu.SetActive (toggle.isOn);
		
	}

	public void ClickInBackGround ()
	{
		toggle.isOn = false;
	}

}
