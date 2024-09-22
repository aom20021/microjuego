using System.Collections.Generic;
using UnityEngine;

public class MeteorPool : MonoBehaviour
{
    public static MeteorPool SharedMeteorInstance;
    private List<GameObject> PooledMeteors;
    public GameObject MeteorPrefabToPool;
    public int amountOfMeteorToPool;
    // Start is called before the first frame update
    void Awake()
    {
        SharedMeteorInstance = this;
    }

    // Update is called once per frame
    void Start()
    {
        PooledMeteors = new List<GameObject>();
        GameObject meteor;
        for (int i = 0; i < amountOfMeteorToPool; i++)
        {
            meteor = Instantiate(MeteorPrefabToPool);
            meteor.SetActive(false);
            PooledMeteors.Add(meteor);
        }
    }

    public GameObject GetPooledMeteor()
    {
        for (int i = 0; i < amountOfMeteorToPool; i++)
        {
            if (!PooledMeteors[i].activeInHierarchy)
            {
                return PooledMeteors[i];
            }
        }
        return null;
    }
}
