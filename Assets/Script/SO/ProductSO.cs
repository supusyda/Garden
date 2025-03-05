using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Product", menuName = "Product")]
public class ProductSO : ScriptableObject
{
    public string productName;
    public Sprite productSprite;
    public int productPrice;
}
