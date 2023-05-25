using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{

    private float fallDelayTime = 0.75f;
    private float destroyDelayTime = 1.5f;

    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall(){
        yield return new WaitForSeconds(fallDelayTime);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelayTime);
    }
    
}
