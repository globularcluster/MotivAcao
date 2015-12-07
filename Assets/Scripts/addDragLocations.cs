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
		panel.GetComponent<Image> ().rectTransform.sizeDelta = new Vector2 (150, 150);
		panel.GetComponent<Image> ().transform.localPosition = new Vector3 (150, 150);

		GameObject imageGO = (GameObject)Instantiate (imagePrefab);

		Image image = imageGO.GetComponent<Image> ();
		image.rectTransform.sizeDelta = new Vector2 (150, 150);

		image.transform.localPosition = new Vector3 (0, 0, 0);
		image.rectTransform.anchorMin = new Vector2 (0, 0);
		image.rectTransform.anchorMax = new Vector2 (1, 1);

		imageGO.transform.SetParent (panel.transform);
		panel.transform.SetParent (imagemBG);

		// deixando a imagem transparente
		Color c = imageGO.GetComponent<Image> ().color;
		c.a = 0;
		imageGO.GetComponent<Image> ().color = c;

		DropMe dm = imageGO.AddComponent<DropMe> ();
		dm.containerImage = panel.GetComponent<Image> ();
		dm.receivingImage = imageGO.GetComponent<Image> ();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
