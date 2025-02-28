using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DetectInfo
{
    // Start is called before the first frame update
    public ContactInfo GetContactInfo(int layerMask)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, 1 << layerMask);


        if (hit)
        {
            return new ContactInfo
            {
                name = hit.collider?.transform.parent.name,
                ContactTransform = hit.transform.parent,
                isContact = hit.collider,
                interactable = hit.collider.transform.parent.GetComponent<IInteract>(),
                point = hit.point
            };

        }
        else
        {
            return new ContactInfo
            {
                name = "",
                ContactTransform = null,
                isContact = false,
                point = Vector3.zero
            };
        }

    }

}
public struct ContactInfo
{
    public string name;
    public Transform ContactTransform;
    public bool isContact;
    public Vector3 point;
    public IInteract interactable;
}