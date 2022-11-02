using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public int deliveredMat;
    public int goalCount;
    public string currentLevel;
    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        
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
            SceneManager.LoadScene(nextLevel.ToString());
            deliveredMat++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Mineral")
        {
            deliveredMat++;
            Destroy(other.gameObject);
        }
    }

    public void RestartStage()
    {
            SceneManager.LoadScene(currentLevel);
    }
}
