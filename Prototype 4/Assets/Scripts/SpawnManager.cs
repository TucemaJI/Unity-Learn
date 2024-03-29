using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private MeshRenderer BoltLightningPower { get; set; }

    public List<GameObject> powerupPrefabs;
    public List<GameObject> enemyPrefabs;
    public GameObject boltPrefab;
    public float cubeSpawnRange;
    public byte enemyToSpawn;

    float fireElapsedTime = 0;
    public float fireDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        BoltLightningPower = GameObject.FindGameObjectsWithTag("Indicator").ToList()
            .Find(x => x.name.Contains("Bolt")).GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectsOfType<Enemy>().Length is byte.MinValue)
        {
            SpawnEnemyWave();
            InstantiateArray(powerupPrefabs);
            enemyToSpawn++;
        }

        fireElapsedTime += Time.deltaTime;
        if (BoltLightningPower.enabled && fireElapsedTime >= fireDelay)
        {
            var enemies = FindObjectsOfType<Enemy>().ToList();
            enemies.ForEach(x => BoltIstantiate(x.transform));
            fireElapsedTime = 0;
        }
    }

    private void BoltIstantiate(Transform transformEnemy)
    {
        var playerPosition = GameObject.Find("Player").transform.position + new Vector3(0, 1.5f);
        Instantiate(boltPrefab, playerPosition, boltPrefab.transform.rotation)
                .GetComponent<FlyToEnemy>().Fire(transformEnemy);
    }

    private void SpawnEnemyWave()
    {
        for (byte i = byte.MinValue; i < enemyToSpawn; i++)
        {
            InstantiateArray(enemyPrefabs);
        }
    }

    private void InstantiateArray(IList<GameObject> array)
    {
        var prefabNumber = Random.Range(byte.MinValue, array.Count);
        Instantiate(array[prefabNumber], GenerateSpawnPosition(), array[prefabNumber].transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        return new Vector3(GenerateFloat(), byte.MinValue, GenerateFloat());

        float GenerateFloat() => Random.Range(-cubeSpawnRange, cubeSpawnRange);
    }
}
