using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public byte TimeSpawn = 1;

    private float InputTime { get; set; } = 0;

    // Update is called once per frame
    void LateUpdate()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && InputTime < Time.fixedTime)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            InputTime = TimeSpawn + Time.fixedTime;
        }
    }
}
