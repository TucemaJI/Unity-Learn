using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject hangar;

    [SerializeField]
    private List<GameObject> chickens;

    [SerializeField]
    private GameObject powerup;

    [SerializeField]
    private GameObject owner;

    private float powerupSpawnTime = 69f;
    private float startDelay = 0f;

    private float xPowerupRange = 13f;
    private float zPowerupRange = 13f;
    private float ySpawn = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnPowerup), startDelay, powerupSpawnTime);
        Invoke(nameof(SpawnOwner), startDelay);
        Invoke(nameof(SpawnChicken), startDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnOwner()
    {
        Instantiate(owner, hangar.transform.position, owner.transform.rotation);
    }

    private void SpawnChicken()
    {
        chickens.ForEach(x => Instantiate(x, hangar.transform.position, x.transform.rotation));
    }

    private void SpawnPowerup()
    {
        var randomX = Random.Range(-xPowerupRange, xPowerupRange);
        var randomZ = Random.Range(-zPowerupRange, zPowerupRange);

        Vector3 spawnPos = new(randomX, ySpawn, randomZ);

        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }
}
