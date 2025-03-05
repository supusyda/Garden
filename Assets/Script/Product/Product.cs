using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Product : MonoBehaviour, IInteract
{
    // Start is called before the first frame update
    [Header("References")]
    [SerializeField] private Transform model;
    [SerializeField] private Transform productCollider;
    private HarvestThing _plantDropOff;

    [Header("Events")]
    [SerializeField] protected Event onHarvest;
    [SerializeField] protected Event onDecompose;

    [Header("Parameters")]
    [SerializeField] private ProductSO _productSO;
    public void Interact()
    {
        HarvestProduct();
    }
    public void SetProduct(ProductSO productSO)
    {
        this._productSO = productSO;
        model.GetComponent<SpriteRenderer>().sprite = productSO.productSprite;
        onDecompose.Register(DecomposeProduct);
    }
    private void FadeUp()
    {
        onDecompose.Unregister(DecomposeProduct);
        model.GetComponent<SpriteRenderer>().DOFade(0, .5f).OnComplete(() =>
        {
            transform.gameObject.SetActive(false);
        });
    }
    public void HarvestProduct()
    {
        onHarvest?.Raise(this, this._productSO);
        productCollider.gameObject.SetActive(false);


        FadeUp();
    }
    private void DecomposeProduct(Component sender, object data)
    {
        if (sender != _plantDropOff) return;
        FadeUp();
    }
    public void SetPlantDropOff(HarvestThing plantDropOff)
    {
        this._plantDropOff = plantDropOff;
    }

}
