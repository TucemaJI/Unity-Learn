using System.Collections;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500;
    private GameObject focalPoint;

    public GameObject powerupIndicator;
    public ParticleSystem dustParticle;
    public int powerUpDuration = 5;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        float force = Input.GetAxis("Vertical") * speed;

        if (Input.GetKey(KeyCode.Space))
        {
            dustParticle.Play();
            force *= 2;
        }

        // Add force to player in direction of the focal point (and camera)
        playerRb.AddForce(focalPoint.transform.forward * force * Time.deltaTime);

        // Set powerup indicator position to beneath player
        var position = transform.position + new Vector3(0, -0.6f, 0);
        powerupIndicator.transform.position = position;
        dustParticle.transform.position = position;
    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        powerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        GameObject gameObject = other.gameObject;
        if (gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = gameObject.transform.position - transform.position;

            // if have powerup hit enemy with powerup force
            enemyRigidbody.AddForce(awayFromPlayer * (powerupIndicator.activeSelf ? powerupStrength : normalStrength), ForceMode.Impulse);
        }
    }



}
