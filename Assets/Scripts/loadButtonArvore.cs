using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class loadButtonArvore : MonoBehaviour
{

	private Button b;
	public bool openMenu;
	public GameObject menu;
	public Transform menuContent;
	private string[] elementsPath;
	private Texture2D[] elementsVector;

	public GameObject imagePrefabs;
	public GameObject panelPrefabs;

	// Use this for initialization
	void Start ()
	{
		// Carrega elementos para o menu do botao
		string path = System.IO.Directory.GetCurrentDirectory () + @"" + Path.DirectorySeparatorChar + "Imagens" + Path.DirectorySeparatorChar + "ComEdicao" + Path.DirectorySeparatorChar + loadMenuButtons.imagemEDITAR + @"EDITADA" + Path.DirectorySeparatorChar;

		try {
			elementsPath = Directory.GetFiles (path, "*");
		} catch (DirectoryNotFoundException d) {
			// carregas imagens testes, para debug
			Debug.Log (d.Message);
			path = System.IO.Directory.GetCurrentDirectory () + @"" + Path.DirectorySeparatorChar + "Imagens" + Path.DirectorySeparatorChar 
				+ "ComEdicao" + Path.DirectorySeparatorChar + @"testeEDITADA" + Path.DirectorySeparatorChar;
			elementsPath = Directory.GetFiles (path, "*");
		}
		elementsVector = new Texture2D[elementsPath.Length];

		for (int i=0; i<elementsPath.Length; i++) {

			GameObject panel = (GameObject)Instantiate (panelPrefabs, new Vector3 (120, 120), new Quaternion (0, 0, 0, 0));
			GameObject button = (GameObject)Instantiate (imagePrefabs);
			button.AddComponent<DragMe> ();

			// carrega a imagem em uma textura2d e adiciona no botao
			string pathTemp = @"file://" + elementsPath [i];
			WWW www = new WWW (pathTemp);
			Texture2D texTmp = new Texture2D (1366, 768, TextureFormat.DXT1, false);
			www.LoadImageIntoTexture (texTmp);
			Sprite sprite = Sprite.Create (texTmp, new Rect (0, 0, texTmp.width, texTmp.height), new Vector2 (.5f, .5f));
			elementsVector [i] = texTmp;

			Image img = button.GetComponent<Image> ();
			img.sprite = sprite;

			button.transform.SetParent (panel.transform, false);
			//img.rectTransform.sizeDelta = new Vector2 (100, 100);
			img.transform.localPosition = new Vector3 (0, 0, 0);
			img.rectTransform.anchorMin = new Vector2 (0, 0);
			img.rectTransform.anchorMax = new Vector2 (1, 1);

			panel.transform.SetParent (menuContent, false);


		}

	}

	// Update is called once per frame
	void Update ()
	{

	}
}
