using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text ScoreDisplay,FailDisplay;
    public GameObject[] FailSign = new GameObject[2];
    public int Score, FailNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreDisplay.text = Score.ToString();
        FailDisplay.text = FailNumber.ToString();
    }
}
