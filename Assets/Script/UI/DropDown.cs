using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform dropdownPanel; // Assign in Inspector
    public Button toggleButton; // Assign the button that toggles the dropdown
    private bool isOpen = false;
    private Vector3 closedScale = new Vector3(1, 0, 1);
    private Vector3 openScale = Vector3.one;

    void Start()
    {
        dropdownPanel.localScale = closedScale; // Start hidden
        toggleButton.onClick.AddListener(ToggleDropdown);
    }

    void ToggleDropdown()
    {
        isOpen = !isOpen;
        dropdownPanel.DOScale(isOpen ? openScale : closedScale, 0.3f).SetEase(Ease.OutQuad);
    }
}
