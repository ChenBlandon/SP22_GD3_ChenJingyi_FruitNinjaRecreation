using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPaused;
    public GameObject PauseSign;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0f;
                PauseSign.SetActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                PauseSign.SetActive(false);
            }
        }
    }
}
