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
		GameObject panel = (GameObject)Instantiate (panelPrefab, new Vector3 (150, 150), Quaternion.Euler (0, 0, 0));
		GameObject image = (GameObject)Instantiate (imagePrefab);
		image.GetComponent<Image> ().rectTransform.sizeDelta = new Vector2 (150, 150);

		// deixando a imagem transparente
		Color c = image.GetComponent<Image> ().color;
		c.a = 0;
		image.GetComponent<Image> ().color = c;

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
