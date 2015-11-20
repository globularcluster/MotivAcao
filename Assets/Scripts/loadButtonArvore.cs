using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class loadButtonArvore : MonoBehaviour
{

	private Button b;
	private bool openMenu;
	public GameObject menu;
	public Transform menuContent;
	string[] elementsPath;

	public GameObject imagePrefabs;

	// Use this for initialization
	void Start ()
	{
		openMenu = false;

		b = this.GetComponent<Button> ();

		b.onClick.AddListener (
			() => {
			openMenu = !openMenu;
			Debug.Log (openMenu); }
		);

		// Carrega elementos para o menu do botao

		string path = System.IO.Directory.GetCurrentDirectory () + @"\Imagens\ComEdicao\" + loadMenuButtons.imagemEDITAR + @"EDITADA\";

		elementsPath = Directory.GetFiles (path, "*");
		Texture2D[] elementsVector = new Texture2D[elementsPath.Length];

		for (int i=0; i<elementsPath.Length; i++) {

//			GameObject button = (GameObject)Instantiate (buttonPrefabs);
			GameObject button = (GameObject)Instantiate (imagePrefabs);
			button.transform.SetParent (menuContent, false);
			button.AddComponent<DragMe> ();

			Image img = button.GetComponent<Image> ();

			// carrega a imagem em uma textura2d e adiciona no botao
			string pathTemp = @"file://" + elementsPath [i];
			WWW www = new WWW (pathTemp);
			Texture2D texTmp = new Texture2D (1366, 768, TextureFormat.DXT1, false);
			www.LoadImageIntoTexture (texTmp);
			Sprite sprite = Sprite.Create (texTmp, new Rect (0, 0, texTmp.width, texTmp.height), new Vector2 (.5f, .5f));
			elementsVector [i] = texTmp;
			
			img.overrideSprite = sprite;
			
//			but.onClick.AddListener ();

		}

	}

	// Update is called once per frame
	void Update ()
	{
		menu.SetActive (openMenu);

	}
}
