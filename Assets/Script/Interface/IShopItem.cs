using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopItem
{
    int Cost { get; }
    void Buy();
}
