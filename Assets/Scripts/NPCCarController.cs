using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCarController : MonoBehaviour
{
    public float speed = 10f;

    public enum DriveDirection {Back, Forward}
    public DriveDirection direction = DriveDirection.Forward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Drive();
    }

    void Drive() 
    {
        if (direction == DriveDirection.Forward)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
        }
        else 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime * -1);
        }
    }

    public void SetPosition(Vector3 startPos) 
    {
        this.transform.position = startPos;
    }
}
