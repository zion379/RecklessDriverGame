using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerateTrigger : MonoBehaviour
{
    public WorldController worldController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            worldController.GenerateRoad();
        }
        Debug.Log("player hit trigger");
    }
}
