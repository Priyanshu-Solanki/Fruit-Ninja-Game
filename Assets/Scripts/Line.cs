using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    int vertexCnt = 0;
    bool mouseDown = false;
    LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if(Input.touchCount>0)
            {
                if(Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    line.SetVertexCount(vertexCnt + 1);
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    line.SetPosition(vertexCnt, mousePos);
                    vertexCnt++;

                    BoxCollider2D box = gameObject.AddComponent<BoxCollider2D>();
                    box.transform.position = line.transform.position;
                    box.size = new Vector2(0.1f, 0.1f);
                }

                if(Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    mouseDown = false;
                    line.SetVertexCount(0);
                    vertexCnt = 0;

                    BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
                    foreach (BoxCollider2D box in colliders)
                    {
                        Destroy(box);
                    }
                }
            }
        }

        else
        {
            if (Input.GetMouseButtonDown(0))
                mouseDown = true;

            if (mouseDown)
            {
                line.SetVertexCount(vertexCnt + 1);
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                line.SetPosition(vertexCnt, mousePos);
                vertexCnt++;

                BoxCollider2D box = gameObject.AddComponent<BoxCollider2D>();
                box.transform.position = line.transform.position;
                box.size = new Vector2(0.1f, 0.1f);
            }

            if (Input.GetMouseButtonUp(0))
            {
                mouseDown = false;
                line.SetVertexCount(0);
                vertexCnt = 0;

                BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D box in colliders)
                {
                    Destroy(box);
                }
            }
        }
        
    }
}
