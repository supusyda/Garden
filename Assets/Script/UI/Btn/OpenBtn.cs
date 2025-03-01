using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBtn : BtnBase
{
    [SerializeField] Transform openedPanel;
    protected override void OnClick()
    {
        base.OnClick();
        openedPanel.GetComponent<IUITransis>().Show();
    }
}

