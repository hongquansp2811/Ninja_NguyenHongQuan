using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform aPonit, bPonit;
    [SerializeField] private float speed;
    private Vector3 taget;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = aPonit.position;
        taget = bPonit.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, taget, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, aPonit.position) < 0.1f)
        {
            taget = bPonit.position;
        }
        else if(Vector2.Distance(transform.position, bPonit.position) < 0.1f)
        {
            taget = aPonit.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
