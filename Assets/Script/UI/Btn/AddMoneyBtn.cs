using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoneyBtn : BtnBase
{
    // Start is called before the first frame update
    override protected void OnClick()
    {
        base.OnClick();
        ResourceManager.instance.AddCoin(100000);
    }
}
