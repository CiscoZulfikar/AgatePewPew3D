using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Start()
    {
        //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        //Jika player telah mati maka tidak membuat enemy baru
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        //Mendapatkan nilai random
        int spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
        int spawnEnemy = UnityEngine.Random.Range(0, 3);

        //Memduplikasi enemy
        GameObject enemy = Factory.FactoryMethod(spawnEnemy);

        //Transform
        enemy.transform.position = spawnPoints[spawnPointIndex].transform.position;
    }
}