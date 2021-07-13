using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    [Range(0, 300)]
    public float carSpawnOffset = 150f;

    public GameObject envoirment1;
    public GameObject envoirment2;

    public int currentEnvoirment = 1;

    public float roadOffset;
    public Transform carSpawnTransform;

    public Transform playerTransform;

    private bool readyToSpawnCars = false;


    // Start is called before the first frame update
    void Start()
    {
        readyToSpawnCars = false;
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
            UpdateCarSpawnPosition(envoirment2.transform);
        }
        else if (currentEnvoirment == 2)
        {
            envoirment1.transform.position = envoirment2.transform.position + new Vector3(0, 0, roadOffset);
            currentEnvoirment = 1;
            UpdateCarSpawnPosition(envoirment1.transform);
        }
        readyToSpawnCars = true;
    }

    public void UpdateCarSpawnPosition(Transform newParent) 
    {
        carSpawnTransform.SetParent(newParent);
            // update car spawn transform
            carSpawnTransform.localPosition = new Vector3(0, 0, carSpawnOffset); //carSpawnOffset + playerTransform.position.z
            readyToSpawnCars = false;
            
        
        
    }
}
