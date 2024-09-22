using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool SharedBulletInstance;
    private List<GameObject> PooledBullets;
    public GameObject BulletPrefabToPool;
    public int amountOfBulletToPool;
    // Start is called before the first frame update
    void Awake()
    {
        SharedBulletInstance = this;
    }

    // Update is called once per frame
    void Start()
    {
        PooledBullets = new List<GameObject>();
        GameObject bullet;
        for (int i = 0; i < amountOfBulletToPool; i++)
        {
            bullet = Instantiate(BulletPrefabToPool);
            bullet.SetActive(false);
            PooledBullets.Add(bullet);
        }
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < amountOfBulletToPool; i++)
        {
            if (!PooledBullets[i].activeInHierarchy)
            {
                PooledBullets[i].gameObject.transform.position = Vector3.zero;
                PooledBullets[i].gameObject.SetActive(true);
                return PooledBullets[i];
            }
        }
        return null;
    }
}