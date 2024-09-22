using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    
    
    private float nextSpawn = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + 60 / spawnRatePerMinute;
            
            spawnRatePerMinute += spawnRateIncrement;
            
            Vector2 spawnPosition = new Vector2(Random.Range(-10, 10), 6.5f);
            
            GameObject meteor = MeteorPool.SharedMeteorInstance.GetPooledMeteor();
            if (meteor != null)
            {
                meteor.transform.position = spawnPosition;
                meteor.SetActive(true);
            }
        }
    }
}
