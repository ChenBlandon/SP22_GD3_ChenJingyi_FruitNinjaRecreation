using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject DeathEffect;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
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
        Instantiate(DeathEffect, transform.position+Vector3.up, Quaternion.identity);
    }
}
