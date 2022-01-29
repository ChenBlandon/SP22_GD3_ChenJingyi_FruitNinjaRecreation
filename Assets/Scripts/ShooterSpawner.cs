using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterSpawner : MonoBehaviour
{
    public enum ThrowMode { AllOut,Sequencing,HoHo}
    public ThrowMode CurrentThrowMode;
    public float TimePerWave,timer;
    public GameObject Shooter,specialShooter,HoHoShooter, Pragagamatre;
    public int CurrentThrowIndex;
    public int NumberOfProjectile,NumberOfBomb;
    public bool HavePragagamatre;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindWithTag("Projectile") <= 0)
        {
            timer += Time.deltaTime;
        }
        
        if (timer > TimePerWave)
        {
            CurrentThrowIndex++;
            if (CurrentThrowIndex <= 2)
            {
                GameObject T = Instantiate(Shooter, new Vector3(Random.Range(-6f, 6f), -6.8f, 0), Quaternion.identity);
                
            }
            else if (CurrentThrowIndex <= 4)
            {
                GameObject T = Instantiate(Shooter, new Vector3(Random.Range(-6f, 6f), -6.8f, 0), Quaternion.identity);
                GameObject T1 = Instantiate(Shooter, new Vector3(Random.Range(-6f, 6f), -6.8f, 0), Quaternion.identity);
                
            }
            else if (CurrentThrowIndex <= 5)
            {
                GameObject T = Instantiate(Shooter, new Vector3(Random.Range(-6f, 6f), -6.8f, 0), Quaternion.identity);
                T.GetComponent<Shooter>().IsBomb = true;
                
            }
            else
            {
                if (CurrentThrowIndex % 25 == 0)
                {
                    CurrentThrowMode = ThrowMode.HoHo;
                }
                else
                {
                    if (Random.Range(1, 5) == 1)
                    {
                        CurrentThrowMode = ThrowMode.Sequencing;
                    }
                    else
                    {
                        CurrentThrowMode = ThrowMode.AllOut;
                    }
                }
                switch (CurrentThrowMode)
                {
                    case ThrowMode.AllOut:
                        NumberOfProjectile = 2 + Random.Range(0, 3);
                        NumberOfBomb = Random.Range(0, 2);
                        if (Random.Range(1, 5) == 1)
                        {
                            HavePragagamatre = true;
                        }
                        for (int i = 0; i < NumberOfProjectile; i++)
                        {
                            if (HavePragagamatre)
                            {
                                GameObject T1 = Instantiate(specialShooter, new Vector3(-12,-1, 0), Quaternion.identity);
                                T1.GetComponent<Shooter>().WaveTime+=0.5f;
                                NumberOfBomb = 0;
                                i++;
                                HavePragagamatre = false;
                            }
                                GameObject T = Instantiate(Shooter, new Vector3(Random.Range(-6f, 6f), -6.8f, 0), Quaternion.identity);
                                
                            if (NumberOfBomb > 0)
                            {
                                T.GetComponent<Shooter>().IsBomb = true;
                                NumberOfBomb--;
                            }
                        }
                        
                        break;
                    case ThrowMode.Sequencing:
                        NumberOfProjectile = 6 + Random.Range(0, 3) * (CurrentThrowIndex % 3);
                        NumberOfBomb = Random.Range(0, CurrentThrowIndex % 5);
                        for (int i = 0; i < NumberOfProjectile; i++)
                        {
                            GameObject T = Instantiate(Shooter, new Vector3(Random.Range(-6f, 6f), -6.8f, 0), Quaternion.identity);
                            if (NumberOfBomb > 0)
                            {
                                if (Random.Range(0, 1) == 0)
                                {
                                    T.GetComponent<Shooter>().IsBomb = true;
                                    NumberOfBomb--;
                                }
                            }
                            T.GetComponent<Shooter>().WaveTime = 3 + i * .5f;
                        }
                        
                        break;
                    case ThrowMode.HoHo:
                        NumberOfProjectile = 7;
                        for (int i = 0; i < 7; i++)
                        {
                            GameObject T = Instantiate(HoHoShooter, new Vector3(-6 + 12 / 6 * i, -6.8f, 0), Quaternion.identity);
                            T.GetComponent<HoHoShooter>().WaveTime = 3 + i * .2f;
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            GameObject T = Instantiate(HoHoShooter, new Vector3(6 - 12 / 6 * i, -6.8f, 0), Quaternion.identity);
                            T.GetComponent<HoHoShooter>().WaveTime = 6 + i * .2f;
                        }
                        
                        break;
                }
            }
            timer = 0;
        }
    }
    public int FindWithTag(string tag)
    {
        GameObject[] Objs;
        Objs = GameObject.FindGameObjectsWithTag(tag);
        return Objs.Length;
    }
}
