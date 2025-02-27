using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Drop : MonoBehaviour
{
    // Start is called before the first frame update
    public float dropHeight = 3f;  // How high the object drops from
    public float dropDuration = 1f;  // Time it takes to drop
    public float maxSway = 1f;  // Maximum left/right sway

    void OnEnable()
    {
        BeginDrop();
    }
    private void BeginDrop()
    {
        // transform.position = new Vector3(0, transform.position.y, transform.position.z);

        // Create a random final X position (adds sway)
        float randomSway = Random.Range(-maxSway, maxSway);
        Vector3 targetPosition = new Vector3(transform.position.x + randomSway, transform.position.y - dropHeight, transform.position.z);

        // Animate the drop
        transform.DOLocalMove(targetPosition, dropDuration)
            .SetEase(Ease.InBounce);
    }
}
