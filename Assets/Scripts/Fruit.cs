using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cut1;
    public GameObject cut2;

    bool collided = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -7f)
        {
            Destroy(gameObject);
            GameManager.instance.Updatelives();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Line" && !collided)
        {
            collided = true;
            GameManager.instance.UpdateScore();

            GameObject c1 = Instantiate(cut1, transform.position, Quaternion.identity) as GameObject;
            GameObject c2 = Instantiate(cut2, new Vector3(transform.position.x - 2f,transform.position.y,0), cut2.transform.rotation) as GameObject;

            c1.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 2f),ForceMode2D.Impulse);
            c1.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-2f, 2f), ForceMode2D.Impulse);

            c2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2f, 2f), ForceMode2D.Impulse);
            c2.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-2f, 2f), ForceMode2D.Impulse);

            Destroy(gameObject);
            Destroy(c1, 2f);
            Destroy(c2, 2f);
        }
    }
}
