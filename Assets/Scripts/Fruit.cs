using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject DeathEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            GameObject.Find("ShooterSpawner").GetComponent<UI>().FailNumber++;
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            GameObject.Find("ShooterSpawner").GetComponent<UI>().Score++;
            SpawnDeathEffect();
            Destroy(gameObject);
        }
    }
    void SpawnDeathEffect()
    {
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
    }
}
