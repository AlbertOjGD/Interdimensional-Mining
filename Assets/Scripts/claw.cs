using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class claw : MonoBehaviour
{
    [SerializeField] SpinningLight lightScript;

    public GameObject selected;
    public BoxCollider bc;
    public GameObject geo;
    private float grabDistance = 0.8f;
    [SerializeField]
    public bool holding = false;

    private float targetColSize = 0.6f;
    private float defaultColSize = 0.8f;

    [SerializeField]
    private AudioManager am;

    private PlayerController player;

    private void Start()
    {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        geo = GameObject.Find("Geo");
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Vector3.Magnitude(selected.transform.position - this.transform.position));
        }*/

        if (selected != null && !player.paused)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.J)) && !holding && Vector3.Magnitude(selected.transform.position - this.transform.position) <= grabDistance)
            {
                selected.transform.SetParent(this.transform);
                selected.GetComponent<BoxCollider>().size = new Vector3(targetColSize, targetColSize, targetColSize);
                Physics.IgnoreCollision(selected.GetComponent<BoxCollider>(), bc);
                holding = true;
                lightScript.toggleLight(true);
                am.Play("PickUp");
            }
            else if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.J)) && holding)
            {
                PutDown();
            }
        }

        else
        {
            holding = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "pickup" && !holding)
        {
            selected = other.gameObject;
        }
    }

    public void PutDown()
    {
        selected.transform.SetParent(geo.transform);
        selected.GetComponent<BoxCollider>().size = new Vector3(defaultColSize, defaultColSize, defaultColSize);
        Physics.IgnoreCollision(selected.GetComponent<BoxCollider>(), bc, false);
        holding = false;
        lightScript.toggleLight(false);
        am.Stop("PickUp");
    }
}
