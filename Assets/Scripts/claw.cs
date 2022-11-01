using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class claw : MonoBehaviour
{
    public GameObject selected;
    private float grabDistance = 0.5f;
    private bool holding = false;

    private void Update()
    {
        if (selected != null  && Vector3.Magnitude(selected.transform.position - this.transform.position) <= grabDistance)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !holding)
            {
                selected.transform.SetParent(this.transform);
                selected.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                holding = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && holding)
            {
                selected.transform.SetParent(null);
                selected.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                holding = false;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "pickup")
        {
            selected = other.gameObject;
        }
    }
}
