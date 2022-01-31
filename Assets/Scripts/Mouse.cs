using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public bool startCombo;
    public int comboNumber;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition/108-new Vector3(9,5,0);
        
        if (startCombo)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                startCombo = false;
                if (comboNumber > 1)
                {
                    GameObject.Find("ShooterSpawner").GetComponent<UI>().Score+=comboNumber;
                    comboNumber = 0;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Projectile"))
        {
            if (c.GetComponent<Fruit>() != null)
            {
                startCombo = true;
                comboNumber++;
            }
        }
    }
}
