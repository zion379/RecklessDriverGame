using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // speed should increase as time goes on
    public float speed = 5f;
    public float TurningSpeed = 45f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move player forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.up, TurningSpeed * Input.GetAxis("Horizontal"));
    }
}
