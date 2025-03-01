using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBtn : BtnBase
{
    [SerializeField] Transform closeedPanel;
    protected override void OnClick()
    {
        base.OnClick();
        closeedPanel.GetComponent<IUITransis>().Hide();
    }
}

