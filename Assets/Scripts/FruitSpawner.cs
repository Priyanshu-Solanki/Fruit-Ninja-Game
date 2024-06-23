using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruit;
    public GameObject bomb;
    public float maxXPos;

    public static FruitSpawner instance;
    void Start()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Invoke("StartSpawning", 1f);
        
    }
    public void StartSpawning()
    {
        InvokeRepeating("SpawnFruitGroups", 1, 6f);
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnFruitGroups");
        StopCoroutine("SpawnFruit");
    }

    public void SpawnFruitGroups()
    {
        StartCoroutine("SpawnFruit");

        int rnd = Random.Range(1,10);
        if (rnd > 4)
            SpawnBomb();
    }
    IEnumerator SpawnFruit()
    {
        for(int i=0;i<5;i++)
        {
            float rnd = Random.Range(-maxXPos, maxXPos);
            Vector3 pos = new Vector3(rnd, transform.position.y, 0);

            GameObject f = Instantiate(fruit, pos, Quaternion.identity) as GameObject;

            f.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,12f),ForceMode2D.Impulse);
            f.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-20f,20f));

            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnBomb()
    {
        float rnd = Random.Range(-maxXPos, maxXPos);
        Vector3 pos = new Vector3(rnd, transform.position.y, 0);

        GameObject b = Instantiate(bomb, pos, Quaternion.identity) as GameObject;

        b.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 12f), ForceMode2D.Impulse);
        b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-50f, 50f));

        Destroy(b, 5f);
    }
}
