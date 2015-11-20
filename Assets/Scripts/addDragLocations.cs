using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class addDragLocations : MonoBehaviour
{
	public GameObject panelPrefab;
	public GameObject imagePrefab;
	public Transform imagemBG;

	void Start ()
	{
		GameObject panel = (GameObject)Instantiate (panelPrefab);
		GameObject image = (GameObject)Instantiate (imagePrefab);
		image.GetComponent<Image> ().rectTransform.sizeDelta = new Vector2 (150, 100);

		image.transform.SetParent (panel.transform);
		panel.transform.SetParent (imagemBG);

		DropMe dm = image.AddComponent<DropMe> ();
		dm.containerImage = panel.GetComponent<Image> ();
		dm.receivingImage = image.GetComponent<Image> ();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
