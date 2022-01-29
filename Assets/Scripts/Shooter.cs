using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Fruit, Bomb, Aimpoint;
    public float WaveTime,Speed,angleVarient;
    public bool IsBomb;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        Aimpoint = GameObject.Find("Aimpoint");
        transform.up = Aimpoint.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= WaveTime)
        {
            GameObject T;
            if (IsBomb)
            {
                T = Instantiate(Bomb);
            }
            else
            {
                T = Instantiate(Fruit);
                T.transform.localScale = new Vector3(Random.Range(0.5f, 1.5f), Random.Range(.5f, 1.5f), 0);
            }
            
            T.transform.position = transform.position;
            T.transform.up = transform.up;
            T.transform.Rotate(new Vector3(0, 0, Random.Range(-angleVarient, angleVarient)));
            T.GetComponent<Rigidbody2D>().AddForce(T.transform.up*Speed,ForceMode2D.Impulse);
            Destroy(gameObject);
        }
    }
}
