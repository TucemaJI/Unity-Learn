using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private string SpawnRandomAnimalName = "SpawnRandomAnimal";

    public List<GameObject> goodAnimalPrefabs = new List<GameObject>();
    public List<GameObject> badAnimalPrefabs = new List<GameObject>();
    public List<GameObject> badRightAnimalPrefabs = new List<GameObject>();
    private byte spawnRangeXZ = 20;
    private byte spawnPositionXZ = 20;
    private byte startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(SpawnRandomAnimalName, startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnRandomAnimal()
    {
        byte side = (byte)Random.Range(byte.MinValue, 3);
        if (side is byte.MinValue)
        {
            byte animalIndex = (byte)Random.Range(byte.MinValue, goodAnimalPrefabs.Count);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeXZ, spawnRangeXZ), byte.MinValue, spawnPositionXZ);

            Instantiate(goodAnimalPrefabs[animalIndex], spawnPosition, goodAnimalPrefabs[animalIndex].transform.rotation);
        }
        if (side is 1)
        {
            byte animalIndex = (byte)Random.Range(byte.MinValue, badAnimalPrefabs.Count);
            Vector3 spawnPosition = new Vector3(-spawnPositionXZ, byte.MinValue, Random.Range(byte.MinValue, spawnRangeXZ));

            Instantiate(badAnimalPrefabs[animalIndex], spawnPosition, badAnimalPrefabs[animalIndex].transform.rotation);
        }
        if (side is 2)
        {
            byte animalIndex = (byte)Random.Range(byte.MinValue, badRightAnimalPrefabs.Count);
            Vector3 spawnPosition = new Vector3(spawnPositionXZ, byte.MinValue, Random.Range(byte.MinValue, spawnRangeXZ));

            Instantiate(badRightAnimalPrefabs[animalIndex], spawnPosition, badRightAnimalPrefabs[animalIndex].transform.rotation);
        }

    }
}
