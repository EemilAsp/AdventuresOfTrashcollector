using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarScript : MonoBehaviour
{

    [SerializeField] public Transform playerTransform;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x-9, playerTransform.position.y+7, transform.position.z);
    }
}
