using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazard : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController colScript = other.gameObject.GetComponent<PlayerController>();
            colScript.rb.velocity = Vector2.zero;
            other.transform.position = colScript.spawn.transform.position;
        }
    }
}
