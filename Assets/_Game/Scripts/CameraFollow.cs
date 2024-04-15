using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform taget;
    public Vector3 offset;
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        taget = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, taget.position + offset, Time.deltaTime * speed);
    }
}
