using UnityEngine;
using System.Collections;

public class Random_Obstacle_Spawner : MonoBehaviour {

    // Use this for initialization
    public GameObject[] obstacles;
    private float maxX = 90.0f;
    private float minX = -90.0f;
    private float maxZ = 100.0f;
    private float minZ = -100.0f;

    public int AmountToSpawn;
	void Start ()
    {
        StartCoroutine(spawnObstacles(obstacles));
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public IEnumerator spawnObstacles(GameObject[] obj)
    {
        Debug.Log("started");

        int num = 0;
        while (num < AmountToSpawn)
        {
            bool checkBound = checkOverlap(obj);
            for (int i = 0; i < obj.Length; i++)
            {
                 obj[i] = (GameObject)Instantiate(obj[i], new Vector3(Random.Range(minX, maxX), 0.5f, Random.Range(minZ, maxZ)), Quaternion.identity); // Instantiate prefabs at random pos
                obj[i].name = obstacles[i].name;
                Debug.Log(obj[0].transform.position);
                if (checkBound) // check if colliding
                {
                    for (int j = 0; j < obj.Length; j++)
                    {
                        obj[j].transform.position = new Vector3(Random.Range(minX, maxX), 0.5f, Random.Range(minZ, maxZ));
                        Debug.Log(obj[0].transform.position);
                    }
                 
                }
                AmountToSpawn--; // decrease
            }

         
        }
        yield return null;
    }


    public bool checkOverlap(GameObject[] obj)
    {
        for (int i = 0; i < obj.Length-1; i++)
        {
            if (obj[i].GetComponent<BoxCollider>().bounds == obj[i + 1].GetComponent<BoxCollider>().bounds)
            {
                Debug.Log("checking");
                return false;
               
            }
        }

        return true;
    }
}
