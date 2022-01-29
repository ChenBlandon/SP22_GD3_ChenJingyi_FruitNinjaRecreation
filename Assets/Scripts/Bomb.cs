using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            GameObject.Find("ShooterSpawner").GetComponent<UI>().FailNumber=0;
            GameObject.Find("ShooterSpawner").GetComponent<UI>().Score = 0;
            GameObject.Find("ShooterSpawner").GetComponent<ShooterSpawner>().CurrentThrowIndex=0;
            GameObject.Find("ShooterSpawner").GetComponent<ShooterSpawner>().timer = 0;
        }
    }
}
