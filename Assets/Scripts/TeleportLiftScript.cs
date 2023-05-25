using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLiftScript : MonoBehaviour
{
    public float targetHeight = 5f;
    public float elevationSpeed = 2f;
    public float fallDelayTime = 2f;
    [SerializeField] private Rigidbody2D rb;
    private bool isElevating = true;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Lift());
        }
    }

    private IEnumerator Lift(){
        yield return new WaitForSeconds(fallDelayTime);
        FixedUpdate();
    }



    private void FixedUpdate()
    {
        if (isElevating)
        {
            // Elevate the Rigidbody
            Vector3 currentPos = transform.position;
            Vector3 newPos = new Vector3(currentPos.x, currentPos.y + elevationSpeed * Time.fixedDeltaTime, currentPos.z);
            rb.MovePosition(newPos);

            // Check if the target height is reached
            if (newPos.y >= targetHeight)
            {
                // Stop elevating and make the Rigidbody static
                isElevating = false;
                rb.isKinematic = true;
            }
        }
    }

}
