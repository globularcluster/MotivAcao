using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloseMenu : MonoBehaviour
{
    public GameObject menu;
    private Toggle toggle;

    void Start()
    {
        toggle = gameObject.GetComponent<Toggle>();

    }

    public void CloseMenuView()
    {
        menu.SetActive(toggle.isOn);
    }

}
