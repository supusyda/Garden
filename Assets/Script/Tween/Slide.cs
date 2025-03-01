using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Slide : MonoBehaviour, IUITransis
{
    // Start is called before the first frame update
    private RectTransform uiElement; // Assign your UI panel in the inspector
    public float duration = 0.5f; // Slide duration
    public Vector2 slideDirection = new Vector2(1, 0); // 1,0 for right, -1,0 for left

    private Vector2 offScreenPosition;
    private Vector2 originalPosition;

    void Start()
    {
        uiElement = GetComponent<RectTransform>();
        offScreenPosition = uiElement.anchoredPosition;
        originalPosition = originalPosition + new Vector2(0 * slideDirection.x, 0 * slideDirection.y);
    }

    public void Show()
    {
        Debug.Log("Show");
        uiElement.DOAnchorPos(originalPosition, duration).SetEase(Ease.InOutQuad);
    }

    public void Hide()
    {
        Debug.Log("Hide");

        uiElement.DOAnchorPos(offScreenPosition, duration).SetEase(Ease.InOutQuad);
    }
}
