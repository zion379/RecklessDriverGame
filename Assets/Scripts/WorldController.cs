using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public float roadOffset;

    public GameObject envoirment1;
    public GameObject envoirment2;

    public int currentEnvoirment = 1;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateRoad() 
    {
        
        if (currentEnvoirment == 1)
        {
            envoirment2.transform.position = envoirment1.transform.position + new Vector3(0, 0, roadOffset);
            envoirment2.SetActive(true);
            currentEnvoirment = 2;
        }
        else if (currentEnvoirment == 2)
        {
            envoirment1.transform.position = envoirment2.transform.position + new Vector3(0, 0, roadOffset);
            currentEnvoirment = 1;
        }
    }
}
