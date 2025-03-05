using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    DetectInfo detectInfo = new DetectInfo();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseDown();

        }
    }
    private void HandleMouseDown()
    {
        int layerIndex = LayerMask.NameToLayer("Intractable");
        ContactInfo contactInfo = detectInfo.GetContactInfo(layerIndex);
        // Debug.Log(contactInfo.name);
        if (contactInfo.interactable != null)
        {
            contactInfo.interactable.Interact();
        }
    }
    public void OnGameOver(Component sender, object data)
    {
        this.enabled = false;
    }
}
