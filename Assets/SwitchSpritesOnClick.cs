using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class SwitchSpritesOnClick : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] Sprite normalSprite = null;
    [SerializeField] Sprite clickedSprite = null;

    private bool clicked = false;
    private Image image = null;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (!clicked)
        {
            image.sprite = clickedSprite;
            clicked = true;
        }
        else
        {
            image.sprite = normalSprite;
            clicked = false;
        }
    }
}
