using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBtn : BtnBase
{
    protected override void OnClick()
    {
        Debug.Log("Buy button clicked: " + gameObject.name);
    }
}

