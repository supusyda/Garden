using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    [Header("Reference")]
    public TMP_Text popUpText;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void OnEnable()
    {
        popUpText.DOFade(1, 0);
        sprite.DOFade(1, 0);
        PopAnim();
    }
    public void SetPopUp(string text, Sprite sprite = null)
    {
        popUpText.text = text;
        this.sprite.sprite = sprite ? sprite : null;
    }
    private void PopAnim()
    {



        // Move up
        transform.DOMoveY(transform.position.y + 1f, 0.5f).SetEase(Ease.OutQuad);

        // Scale effect (punch effect)
        transform.DOScale(transform.localScale * 1.2f, 0.2f).SetLoops(2, LoopType.Yoyo);

        // Fade out both text and icon
        popUpText.DOFade(0, 0.5f).SetDelay(0.3f);
        sprite.DOFade(0, 0.5f).SetDelay(0.3f).onComplete += () => PopUpSpawnerManager.Instance.DespawnOjb(gameObject.transform);

    }

}
