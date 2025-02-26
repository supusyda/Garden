using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInfo
{
    // Start is called before the first frame update
    public ContactInfo GetContactInfo(int layerMask)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, 1 << layerMask);
        Debug.Log(mousePos);
        Debug.Log(hit.collider?.name);
        return new ContactInfo
        {
            name = hit.collider?.name,
            ContactTransform = hit.transform,
            isContact = hit,
            point = hit.point
        };

    }

}
public struct ContactInfo
{
    public string name;
    public Transform ContactTransform;
    public bool isContact;
    public Vector3 point;
}