using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfD", 4);
    }
    public void SelfD()
    {
        Destroy(gameObject);
    }
}
