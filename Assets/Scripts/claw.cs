using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class claw : MonoBehaviour
{
    public GameObject selected;
    public BoxCollider bc;
    public GameObject geo;
    private float grabDistance = 0.8f;
    [SerializeField]
    public bool holding = false;

    private float targetColSize = 0.6f;
    private float defaultColSize = 0.8f;


    private void Start()
    {
       geo = GameObject.Find("Geo");
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Vector3.Magnitude(selected.transform.position - this.transform.position));
        }*/

        if (selected != null)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !holding && Vector3.Magnitude(selected.transform.position - this.transform.position) <= grabDistance)
            {
                selected.transform.SetParent(this.transform);
                selected.GetComponent<BoxCollider>().size = new Vector3(targetColSize, targetColSize, targetColSize);
                Physics.IgnoreCollision(selected.GetComponent<BoxCollider>(), bc);
                holding = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && holding)
            {
                selected.transform.SetParent(geo.transform);
                selected.GetComponent<BoxCollider>().size = new Vector3(defaultColSize, defaultColSize, defaultColSize);
                Physics.IgnoreCollision(selected.GetComponent<BoxCollider>(), bc, false);
                holding = false;
            }
        }

        else
        {
            holding = false;
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
