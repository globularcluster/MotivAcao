using UnityEngine;

public class CarregarCena : MonoBehaviour
{
	public void loadScene (string nomeDaCena)
	{
		Application.LoadLevel (nomeDaCena);
	}
}
