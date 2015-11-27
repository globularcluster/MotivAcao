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
	public GameObject panelPregabs;

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
		elementsVector = new Texture2D[elementsPath.Length];

		for (int i=0; i<elementsPath.Length; i++) {

			GameObject panel = (GameObject)Instantiate (panelPregabs);
			GameObject button = (GameObject)Instantiate (imagePrefabs);
			button.transform.SetParent (panel.transform, false);
			panel.transform.SetParent (menuContent, false);
		
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
			
//			but.onClick.AddListener ();

		}

	}

	// Update is called once per frame
	void Update ()
	{
		menu.SetActive (openMenu);

	}

	public void CloseMenu ()
	{
		menu.SetActive (false);
	}
}
