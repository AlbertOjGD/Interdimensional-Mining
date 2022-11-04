using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public Vector2 inputLever;

    public GameObject spawn;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotSpeed;
    private float rotMaxSpeed;

    public bool paused;

    public int score;

    public claw claw;

    [SerializeField]
    private AudioManager am;

    // Start is called before the first frame update
    void Start()
    {
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        rb = GetComponent<Rigidbody>();
        claw = GetComponentInChildren <claw>();
        speed = 1f;
        rotSpeed = 0.6f;
        rotMaxSpeed = 0.8f;
        spawn = GameObject.Find("SpawnPoint");
        paused = false;
        transform.position = spawn.transform.position;
        score = ScoreCard.score;
        am.Play("BGM");
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        SoundManager();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    Vector2 GetInput()
    {
        if (!paused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.W))
            {
                if (am.IsPlaying("BotMoving") != true)
                {
                    am.Play("BotMoving");
                }
                inputLever.x = 1;
            }
            else if (Input.GetKeyUp(KeyCode.Alpha9) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.X) || Input.GetKeyUp(KeyCode.Alpha0))
            {
                inputLever.x = 0;
            }
            /*else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.S))
            {
                inputLever.x = 0;
            }*/
            else if (Input.GetKey(KeyCode.Alpha9) || Input.GetKey(KeyCode.X))
            {
                if (am.IsPlaying("BotMoving") != true)
                {
                    am.Play("BotMoving");
                }
                inputLever.x = -1;
            }

            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.H))
            {
                if (am.IsPlaying("BotMoving") != true)
                {
                    am.Play("BotMoving");
                }
                inputLever.y = 1;
            }

            else if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.H) || Input.GetKeyUp(KeyCode.Alpha8))
            {
                inputLever.y = 0;
            }

            /*else if (Input.GetKey(KeyCode.A))
            {
                inputLever.y = 0;
            }*/
            else if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Alpha8))
            {
                if (am.IsPlaying("BotMoving") != true)
                {
                    am.Play("BotMoving");
                }
                inputLever.y = -1;
            }
        }

        //Debug.Log(inputLever);
        return inputLever;
    }

    void MovePlayer()
    {
        //do nothing
        if (GetInput() == new Vector2(0, 0))
        {
            am.Stop("BotMoving");
            rb.velocity = new Vector2(0, 0) * speed;
            rb.angularVelocity = Vector3.zero;
        }

        //move forward
        else if (GetInput() == new Vector2(1, 1))
        {
            rb.velocity = transform.forward * speed;
            rb.angularVelocity = Vector3.zero;
        }

        //rotate towards the right
        else if (GetInput() == new Vector2(-1, 0))
        {
            rb.velocity = new Vector2(0, 0) * speed;
            rb.AddTorque(transform.up * rotSpeed, ForceMode.VelocityChange);
            //bot rotates in the X axis
            rb.angularVelocity = new Vector3(Mathf.Clamp(rb.angularVelocity.x, -rotMaxSpeed, rotMaxSpeed), Mathf.Clamp(rb.angularVelocity.y, -rotMaxSpeed, rotMaxSpeed), Mathf.Clamp(rb.angularVelocity.z, -rotMaxSpeed, rotMaxSpeed));
        }

        //rotate towards the left
        else if (GetInput() == new Vector2(0, -1))
        {
            rb.velocity = new Vector2(0, 0) * speed;
            rb.AddTorque(transform.up * -rotSpeed, ForceMode.VelocityChange);
            //bot rotates in the X axis

            rb.angularVelocity = new Vector3(Mathf.Clamp(rb.angularVelocity.x, -rotMaxSpeed, rotMaxSpeed), Mathf.Clamp(rb.angularVelocity.y, -rotMaxSpeed, rotMaxSpeed), Mathf.Clamp(rb.angularVelocity.z, -rotMaxSpeed, rotMaxSpeed));
        }

        //quickly rotate towards the left
        else if (GetInput() == new Vector2(1, -1))
        {
            rb.velocity = new Vector2(0, 0) * speed;
            rb.AddTorque(transform.up * -rotSpeed * 1.5f, ForceMode.VelocityChange);
            //bot rotates in the X axis
            rb.angularVelocity = new Vector3(Mathf.Clamp(rb.angularVelocity.x, -rotMaxSpeed * 1.25f, rotMaxSpeed * 1.25f), Mathf.Clamp(rb.angularVelocity.y, -rotMaxSpeed * 1.25f, rotMaxSpeed * 1.25f), Mathf.Clamp(rb.angularVelocity.z, -rotMaxSpeed * 1.25f, rotMaxSpeed * 1.25f));
        }

        //move backward
        else if (GetInput() == new Vector2(-1, -1))
        {
            rb.velocity = -transform.forward * speed;
            rb.angularVelocity = Vector3.zero;
        }

        //quickly rotate towards the right
        else if (GetInput() == new Vector2(-1, 1))
        {
            rb.velocity = new Vector2(0, 0) * speed;
            rb.AddTorque(transform.up * rotSpeed * 1.5f, ForceMode.VelocityChange);
            //bot rotates in the X axis
            rb.angularVelocity = new Vector3(Mathf.Clamp(rb.angularVelocity.x, -rotMaxSpeed * 1.25f, rotMaxSpeed * 1.25f), Mathf.Clamp(rb.angularVelocity.y, -rotMaxSpeed, rotMaxSpeed), Mathf.Clamp(rb.angularVelocity.z, -rotMaxSpeed * 1.25f, rotMaxSpeed * 1.25f));
        }

        //rotate to the right
        else if (GetInput() == new Vector2(0, 1))
        {
            rb.velocity = new Vector2(0, 0) * speed;
            rb.AddTorque(transform.up * rotSpeed, ForceMode.VelocityChange);
            //bot rotates in the X axis
            rb.angularVelocity = new Vector3(Mathf.Clamp(rb.angularVelocity.x, -rotMaxSpeed, rotMaxSpeed), Mathf.Clamp(rb.angularVelocity.y, -rotMaxSpeed, rotMaxSpeed), Mathf.Clamp(rb.angularVelocity.z, -rotMaxSpeed, rotMaxSpeed));
        }

        //rotate to the left
        else if (GetInput() == new Vector2(1, 0))
        {
            rb.velocity = new Vector2(0, 0) * speed;
            rb.AddTorque(transform.up * -rotSpeed, ForceMode.VelocityChange);
            //bot rotates in the X axis

            rb.angularVelocity = new Vector3(Mathf.Clamp(rb.angularVelocity.x, -rotMaxSpeed, rotMaxSpeed), Mathf.Clamp(rb.angularVelocity.y, -rotMaxSpeed, rotMaxSpeed), Mathf.Clamp(rb.angularVelocity.z, -rotMaxSpeed, rotMaxSpeed));

        }


    }

    public IEnumerator Pause()
    {
        rb.velocity = Vector2.zero;
        inputLever = Vector2.zero;
        paused = true;
        if(claw.selected != null && claw.holding)
        {
            claw.PutDown();
            claw.selected = null;
        }
        yield return new WaitForSeconds(0.5f);
        transform.position = spawn.transform.position;
        paused = false;
    }

    void SoundManager()
    {
        
        if (Mathf.Abs(rb.velocity.magnitude) >= 0.1f)
        {
            
        }
    }
}
