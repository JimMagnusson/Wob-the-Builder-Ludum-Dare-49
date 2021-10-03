using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]

public class BiggerWhenHighlighted : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    [SerializeField] float highlightedScale = 1.2f;
    [SerializeField] float clickScale = 1.2f;

    private RectTransform rectTransform;
    private float normalScale;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        normalScale = rectTransform.localScale.x;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.localScale = highlightedScale * Vector3.one;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.localScale = normalScale * Vector3.one;
    }

    public void OnSelect(BaseEventData eventData)
    {
        rectTransform.localScale = clickScale * Vector3.one;
    }
}
