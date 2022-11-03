using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{
    [SerializeField]
    private AudioManager am;


    private void Start()
    {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().score++;
            am.Play("Collectable");
            Destroy(this.gameObject);
        }
    }
}
