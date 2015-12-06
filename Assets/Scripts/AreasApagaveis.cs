using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AreasApagaveis : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{

	private Color normalColor;
	private Color highlightColor;
	private Image image;
	public GameObject imagem_a_editar;
	public Toggle btn_apagar;

	void Start ()
	{
		image = GetComponent<Image> ();
		normalColor = image.color;
		highlightColor = new Color (1, 0, 0, 0.3f);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		if (btn_apagar.isOn)
			image.color = highlightColor;
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		if (btn_apagar.isOn)
			image.color = normalColor;
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		Vector3 position = this.transform.position;
		RectTransform retr = GetComponent<RectTransform> ();
		imagem_a_editar.GetComponent<AlphaChanger> ().ApagarArea (position, retr);
	}
}
