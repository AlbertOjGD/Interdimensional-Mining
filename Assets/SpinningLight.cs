using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningLight : MonoBehaviour
{
    [SerializeField] float spinSpeed = 0f;
    bool isCarrying = false;

    private void Start()
    {
        gameObject.SetActive(false);
        isCarrying = false;
    }

    private void Update()
    {
        if (isCarrying)
        {
            transform.Rotate(new Vector3(0, 0, spinSpeed), Space.World);
        }
    }

    public void toggleLight()
    {
        if (!isCarrying)
        {
            isCarrying = true;
            gameObject.SetActive(true);

        }
        else
        {
            isCarrying = false;
            gameObject.SetActive(false);
        }
    }
}
