using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    //timer

    [SerializeField] Text timerText;
    float time = 0f;

    //not timer
    public GameObject delivered;
    public int deliveredMat;
    public int goalCount;
    public string currentLevel;
    public string nextLevel;

    public Animator animator;

    public Text score;

    private PlayerController pc;
    private claw claw;

    [SerializeField]
    private AudioManager am;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        claw = GameObject.Find("Player").GetComponentInChildren<claw>();
        am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        time = ScoreCard.timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartStage();        
        }


            if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Tutorial");
        }

        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            SceneManager.LoadScene("Tutorial");
        }

        if (goalCount == deliveredMat /*|| Input.GetKeyDown(KeyCode.T)*/)
        {
            animator.SetTrigger("FadeOut");
            deliveredMat++;
            StartCoroutine("LoadScene");
            
        }

        DeliverMaterials();

        updateTimer();
        score.text = "Score: " + pc.score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Mineral")
        {
            delivered = other.gameObject;
        }
    }

    void DeliverMaterials()
    {
        if(!claw.holding && delivered != null)
        {
            am.Play("GemsDeposited");
            pc.score += 10;
            deliveredMat++;
            Destroy(delivered);
        }
    }

    public void RestartStage()
    {
            SceneManager.LoadScene(currentLevel);
    }

    private IEnumerator LoadScene()
    {
        ScoreCard.score = pc.score;
        ScoreCard.timer = time;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextLevel.ToString());
    }

    void updateTimer()
    {
        time += 1 * Time.deltaTime;
        int minutes = (int)Mathf.Floor(time/60);
        int seconds = (int)Mathf.Floor(time) % 60;
        int tenths = (int) (time % 1 * 10);
        int hundredths = (int)(time % 0.1 * 100);

        timerText.text = "Time: " + minutes + "m " + seconds + "." + tenths + "" + hundredths + "s";

        //print(seconds%60);
    }
    
}
