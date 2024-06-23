using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject particleSystem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Line")
        {
            Destroy(gameObject);
            GameObject p = Instantiate(particleSystem, new Vector3(transform.position.x,transform.position.y,-5f), particleSystem.transform.rotation) as GameObject;
            Destroy(p, 3f);
        }
    }
}
