using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class loadMenuButtons : MonoBehaviour
{
	
	// caminho de todas as imagens SEM EDICAO
	public string[] imagesPath;

	// vetor com todas as imagens SEM EDICAO
	public static Texture2D[] imagesVector;

	string pathPrefix;

	// oarametros para o Unity
	public GameObject buttonPrefabs;
	public Transform scrollViewContent;

	// hash de cada botao com o caminho de sua imagem, para abrir na proxima cena
	private Dictionary<int,string> buttonImageHash;
	public static string imagemEDITAR;

	void Start ()
	{
		
		string path = System.IO.Directory.GetCurrentDirectory ();

		path += @""+Path.DirectorySeparatorChar+"Imagens"+Path.DirectorySeparatorChar+"SemEdicao";
		pathPrefix = @"file://";

		imagesPath = Directory.GetFiles (path, "*.jpg");
		imagesVector = new Texture2D[imagesPath.Length];

		Debug.Log (path);

		buttonImageHash = new Dictionary<int, string> ();

		// instancia um botao para cada imagem
		for (int i=0; i<imagesPath.Length; i++) {	
		
			GameObject button = (GameObject)Instantiate (buttonPrefabs);
			button.transform.SetParent (scrollViewContent, false);

			Button b = button.GetComponent<Button> ();

			// carrega a imagem em uma textura2d e adiciona no botao
			string pathTemp = pathPrefix + imagesPath [i];
			WWW www = new WWW (pathTemp);
			Texture2D texTmp = new Texture2D (1366, 768, TextureFormat.DXT1, false);
			www.LoadImageIntoTexture (texTmp);
			Sprite sprite = Sprite.Create (texTmp, new Rect (0, 0, texTmp.width, texTmp.height), new Vector2 (.5f, .5f));
			imagesVector [i] = texTmp;
	
			b.image.overrideSprite = sprite;

			b.onClick.AddListener (
				() => {
				imagemEDITAR = Path.GetFileNameWithoutExtension (buttonImageHash [b.GetInstanceID ()]);
				Debug.Log (imagemEDITAR); 
				Application.LoadLevel ("Edicao");
			}
			);

			// 
			int buttonID = b.GetInstanceID ();
			buttonImageHash.Add (buttonID, imagesPath [i]);
		}
	}
	
}