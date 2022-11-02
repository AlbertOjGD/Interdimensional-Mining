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
            colScript.StartCoroutine("Pause");
        }
    }
}
