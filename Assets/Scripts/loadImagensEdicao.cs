using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class loadImagensEdicao : MonoBehaviour
{

	// MODO DE USAR:
	// Imagem sem ediçao em: /SemEdicao/<nomedaimagem>.jpg
	// Imagem com ediçao em: /ComEdicao/<nomedaimagem>EDITADA.jpg
	// Elementos que podem ser adicionado a imagem: /ComEdicao/<nomedaimagem>/

	void Start ()
	{
		Image background = GameObject.Find ("background").GetComponent<Image> ();
		Image imagem_a_editar = GameObject.Find ("imagem_a_editar").GetComponent<Image> ();

		string bgPath = System.IO.Directory.GetCurrentDirectory () + @"" + Path.DirectorySeparatorChar + "Imagens" + Path.DirectorySeparatorChar + "ComEdicao" + Path.DirectorySeparatorChar + loadMenuButtons.imagemEDITAR + @"EDITADA.jpg";
		string imgEditPath = System.IO.Directory.GetCurrentDirectory () + @"" + Path.DirectorySeparatorChar + "Imagens" + Path.DirectorySeparatorChar + "SemEdicao" + Path.DirectorySeparatorChar + loadMenuButtons.imagemEDITAR + @".jpg";

		background.overrideSprite = CarregarImagem (bgPath);
		imagem_a_editar.overrideSprite = CarregarImagem (imgEditPath);
//		imagem_a_editar.sprite.texture.Apply ();

	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	Sprite CarregarImagem (string path)
	{
		Texture2D texTmp = null;
		byte[] fileData;
		
		if (File.Exists (path)) {
			Debug.Log ("file exists");
			fileData = File.ReadAllBytes (path);
			texTmp = new Texture2D (1366, 768);
			texTmp.LoadImage (fileData); //..this will auto-resize the texture dimensions.
		}

//		WWW www = new WWW (path);
//		Texture2D texTmp = new Texture2D (1366, 768, TextureFormat.ARGB32, false);
//		www.LoadImageIntoTexture (texTmp);
		Sprite sprite = Sprite.Create (texTmp, new Rect (0, 0, texTmp.width, texTmp.height), new Vector2 (.5f, .5f));

		return sprite;
	}
	
}

