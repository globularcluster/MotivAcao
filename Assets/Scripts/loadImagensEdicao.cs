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

		string bgPath = @"file://" + System.IO.Directory.GetCurrentDirectory () + @""+ Path.DirectorySeparatorChar +"Imagens"+Path.DirectorySeparatorChar+"ComEdicao"+Path.DirectorySeparatorChar + loadMenuButtons.imagemEDITAR + @"EDITADA.jpg";
		string imgEditPath = @"file://" + System.IO.Directory.GetCurrentDirectory () + @""+Path.DirectorySeparatorChar+"Imagens"+Path.DirectorySeparatorChar+"SemEdicao"+Path.DirectorySeparatorChar + loadMenuButtons.imagemEDITAR + @".jpg";

		background.overrideSprite = CarregarImagem (bgPath);
		imagem_a_editar.overrideSprite = CarregarImagem (imgEditPath);


	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	Sprite CarregarImagem (string path)
	{
		WWW www = new WWW (path);
		Texture2D texTmp = new Texture2D (1366, 768, TextureFormat.DXT1, false);
		www.LoadImageIntoTexture (texTmp);
		Sprite sprite = Sprite.Create (texTmp, new Rect (0, 0, texTmp.width, texTmp.height), new Vector2 (.5f, .5f));

		return sprite;
	}
	
}

