using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] obstacles;
    private float maxX = 150.0f;
    private float minX = -150.0f;
    private float maxZ = 200.0f;
    private float minZ = -200.0f;
    public Bounds[] bound;
    public int AmountToSpawn;
    public GameObject Target;
    [SerializeField] private GameObject[] tempObs;
    // Use this for initialization
    void Start ()
    {
        bound = new Bounds[AmountToSpawn];
        tempObs = new GameObject[AmountToSpawn];
        StartCoroutine(spawn(obstacles));

    }
	
	// Update is called once per frame
	void Update ()
    {

    }


    public IEnumerator spawn(GameObject[] objs)
    {
        int num = 0;
        while (num < AmountToSpawn)
        {
            for (int i = 0; i < tempObs.Length; i++)
            {
                GameObject targ = Target;
                targ.transform.position = new Vector3(Random.Range(minX, maxX), 0.5f, Random.Range(minZ, maxZ));
              
                if (hasCollisions(targ))
                {
                    targ.transform.position = new Vector3(Random.Range(minX, maxX), 0.5f, Random.Range(minZ, maxZ));
                }
                else
                {
                    tempObs[i] = (GameObject)Instantiate(objs[Random.Range(0, 2)], targ.transform.position, Quaternion.identity);
                    bound[i] = tempObs[i].GetComponent<BoxCollider>().bounds;


                }

                num++;
            }
        }

        yield return null;


    }

    bool hasCollisions(GameObject target)
    {
        for (int j = 0; j < tempObs.Length; j++)
        {
            if (target.GetComponent<BoxCollider>().bounds.Intersects(bound[j]))
            {
                return true;
            }

        }
        return false;
    }
}
