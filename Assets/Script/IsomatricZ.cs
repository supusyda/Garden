using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsomatricZ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y, pos.y * 0.01f);
    }

}
