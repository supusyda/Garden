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

    [Header("Events")]
    [SerializeField] protected Event onHarvest;
    [Header("Parameters")]
    [SerializeField] private ProductSO _productSO;
    public void Interact()
    {

        onHarvest?.Raise(this, this._productSO);
        productCollider.gameObject.SetActive(false);
        FadeUp();

    }
    public void SetProduct(ProductSO productSO)
    {
        this._productSO = productSO;
        model.GetComponent<SpriteRenderer>().sprite = productSO.productSprite;
    }
    private void FadeUp()
    {

        model.GetComponent<SpriteRenderer>().DOFade(0, .5f).OnComplete(() =>
        {
            transform.gameObject.SetActive(false);
        });
    }

}
