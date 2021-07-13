using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] CommutingCars;
    [Tooltip("0 index is inner lane, 1 index outter lane")]
    [SerializeField]
    private Transform[] rightSideCarsSpawn = new Transform[2];
    [Tooltip("0 index is outside lane, 1 index inner lane")]
    [SerializeField]
    private Transform[] leftSideCarSpawn = new Transform[2];

    [SerializeField]
    [Tooltip("inner lane is the faster lane")]
    private float innerLaneSpeed = 18f;
    [SerializeField]
    [Tooltip("out side lane is the slowest lane")]
    private float outterLaneSpeed = 15f;

    public WorldController worldController;


    // Start is called before the first frame update
    void Start()
    {
        timeLeft = SpawnFrequency;
        //worldController.UpdateCarSpawnPosition();
        SpawnTraffic();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            //SpawnTraffic
            SpawnTraffic();
            //worldController.UpdateCarSpawnPosition();
            ResetCountDownTimer();
        }
    }

    // spawning traffic
    private void SpawnTraffic() 
    {
        // Spawn traffic based off timer
        // dicide how many cars i want to spawn
        // delay spawning on right side of road

        float carsToSpawn = Random.RandomRange(1, 5);

        // random number to decide which lane to spawn cars in

        if (carsToSpawn == 1)
        {
            float laneToSpawnIn = Random.RandomRange(1, 5);
            TrafficSpawnHelper(laneToSpawnIn);
        }
        else if (carsToSpawn == 2)
        {
            float lane1 = Random.RandomRange(1, 5);
            float lane2 = Random.RandomRange(1, 5);
            while (lane2 == lane1) 
            {
                lane2 = Random.RandomRange(1, 5);
            }

            TrafficSpawnHelper(lane1);
            TrafficSpawnHelper(lane2);
        }
        else if (carsToSpawn == 3)
        {
            float lane1 = Random.RandomRange(1, 5);
            float lane2 = Random.RandomRange(1, 5);
            float lane3 = Random.RandomRange(1, 5);

            while (lane2 == lane1 || lane2 == lane3) 
            {
                lane2 =  Random.RandomRange(1, 5);
            }

            while (lane3 == lane2 || lane3 == lane1) 
            {
                lane3 = Random.RandomRange(1, 5);
            }

            TrafficSpawnHelper(lane1);
            TrafficSpawnHelper(lane2);
            TrafficSpawnHelper(lane3);


        }
        else if (carsToSpawn == 4) 
        {
            // spawn cars in all lanes
            TrafficSpawnHelper(1);
            TrafficSpawnHelper(2);
            TrafficSpawnHelper(3);
            TrafficSpawnHelper(4);
        }
    }

    private void TrafficSpawnHelper(float laneToSpawnIn) 
    {
        // convert to int
        int lane = (int)laneToSpawnIn;
        switch (lane) {
            case 1 :
                TrafficSpawnLeft(lane);
                break;
            case 2 :
                TrafficSpawnLeft(lane);
                break;
            case 3 :
                TrafficSpawnRight(lane);
                break;
            case 4 :
                TrafficSpawnRight(lane);
                break;
            default :
                TrafficSpawnLeft(lane);
                break;
        }
    }

    private void TrafficSpawnLeft(int lane) 
    {
        float carSpawnIndex = Random.RandomRange(0, CommutingCars.Length - 1);
        // 1 outer lane
        // 2 inner lane

        if (lane == 1)
        {
            GameObject car = Instantiate(CommutingCars[(int)carSpawnIndex]); //Instantiate(CommutingCars[(int)carSpawnIndex], leftSideCarSpawn[0].position, Quaternion.identity);
            car.GetComponent<NPCCarController>().direction = NPCCarController.DriveDirection.Back;
            car.GetComponent<NPCCarController>().speed = outterLaneSpeed;
            car.transform.position = leftSideCarSpawn[0].position;
            Debug.Log(leftSideCarSpawn[0].position);

        }
        else 
        {
            GameObject car = Instantiate(CommutingCars[(int)carSpawnIndex]); //Instantiate(CommutingCars[(int)carSpawnIndex], leftSideCarSpawn[1].position, Quaternion.identity);
            car.GetComponent<NPCCarController>().direction = NPCCarController.DriveDirection.Back;
            car.GetComponent<NPCCarController>().speed = innerLaneSpeed;
            //car.GetComponent<NPCCarController>().SetPosition(new Vector3(leftSideCarSpawn[1].position.x, 0, 0));
            car.transform.position = leftSideCarSpawn[1].position;
            Debug.Log(leftSideCarSpawn[1].position);
        }
        
    }

    private void TrafficSpawnRight(int lane) 
    {
        float carSpawnIndex = Random.RandomRange(0, rightSideCarsSpawn.Length - 1);
        // 3 inner lane
        // 4 outer lane

        if (lane == 3)
        {
            GameObject car = Instantiate(CommutingCars[(int)carSpawnIndex], rightSideCarsSpawn[0].position, Quaternion.identity);
            car.GetComponent<NPCCarController>().direction = NPCCarController.DriveDirection.Forward;
            car.GetComponent<NPCCarController>().speed = innerLaneSpeed;
            //car.GetComponent<NPCCarController>().SetPosition(rightSideCarsSpawn[0].position);
            Debug.Log(rightSideCarsSpawn[0].position);
        }
        else 
        {
            GameObject car = Instantiate(CommutingCars[(int)carSpawnIndex], rightSideCarsSpawn[1].position, Quaternion.identity);
            car.GetComponent<NPCCarController>().direction = NPCCarController.DriveDirection.Forward;
            car.GetComponent<NPCCarController>().speed = outterLaneSpeed;
            //car.GetComponent<NPCCarController>().SetPosition(rightSideCarsSpawn[1].position);
            Debug.Log(rightSideCarsSpawn[1].position);
        }
    }

    // Count Down Timer
    public float SpawnFrequency = 10f;

    private float timeLeft;

    private void ResetCountDownTimer() {
        timeLeft = SpawnFrequency;
    }
}
