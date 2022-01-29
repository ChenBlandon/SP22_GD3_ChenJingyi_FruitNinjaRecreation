using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoHoShooter : MonoBehaviour
{
    public GameObject Fruit;
    public float WaveTime, Speed;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= WaveTime)
        {
            GameObject T = Instantiate(Fruit);
            T.transform.position = transform.position;
            T.GetComponent<Rigidbody2D>().AddForce(T.transform.up * Speed, ForceMode2D.Impulse);
            Destroy(gameObject);
        }
    }
}
