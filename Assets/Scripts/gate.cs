using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour
{
    public GameObject gateUp;
    [SerializeField]
    private BoxCollider m_bc;
    [SerializeField]
    private BoxCollider g_bc;
    private claw pc;

    private Vector3 gateUpSize = new Vector3(1f, 1.7f, 1f);
    private Vector3 gateDefault = new Vector3(1f, 1f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponentInChildren<claw>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.holding && pc.selected.name == "Mineral")
        {
            gateUp.transform.localScale = gateUpSize;
            m_bc.isTrigger = false;
            g_bc.isTrigger = false;
        }

        else
        {
            gateUp.transform.localScale = gateDefault;
            m_bc.isTrigger = true;
            g_bc.isTrigger = true;
        }
    }
}
