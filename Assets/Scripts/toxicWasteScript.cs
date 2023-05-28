using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toxicWasteScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer = 0f;
    public float shootingInterval = 5f;
    public GameObject toxicWaste;

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime; // Increment the timer

        // Check if it's time to shoot
        if (timer >= shootingInterval)
        {
            timer = 0f; // Reset the timer
            Destroy(toxicWaste);
        }
    }
}
