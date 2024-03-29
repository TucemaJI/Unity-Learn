using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IEnumerator Enumer { get; set; }
    private Rigidbody PlayerRigidbody { get; set; }
    private GameObject FocalPoint { get; set; }

    public List<GameObject> indicators;
    public float speed;
    public float seconds;
    public float powerupStrength;
    public float ringStrength;
    public float upForce;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        PlayerRigidbody.AddForce(FocalPoint.transform.forward * speed * forwardInput);
        indicators.ForEach(x => x.transform.position =
            transform.position + new Vector3(byte.MinValue, -0.5f, byte.MinValue));

        if (indicators[2].GetComponent<MeshRenderer>().enabled && transform.position.y <= 0.1f)
        {
            PlayerRigidbody.AddForce(FocalPoint.transform.up * upForce, ForceMode.Impulse);
            var enemies = FindObjectsOfType<Enemy>().ToList();
            enemies.ForEach(x => x.GetComponent<Rigidbody>()
            .AddForce((x.transform.position - transform.position) * ringStrength, ForceMode.Impulse));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Powerup"))
        {
            return;
        }

        var words = other.gameObject.name.Split(' ').ToList();
        var index = indicators.FindIndex(x => words.Exists(y => x.name.StartsWith(y)));
        Destroy(other.gameObject);
        OnCompareTag(index);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && indicators[0].GetComponent<MeshRenderer>().enabled)
        {
            GameObject enemyRigidbody = collision.gameObject;
            Vector3 awayFromPlayer = enemyRigidbody.transform.position - transform.position;

            enemyRigidbody.GetComponent<Rigidbody>()
                .AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    private void OnCompareTag(int index)
    {
        if (indicators[index].GetComponent<MeshRenderer>().enabled)
        {
            StopCoroutine(Enumer);
        }
        Enumer = PowerupCountdownRoutline();
        StartCoroutine(Enumer);
        indicators[index].GetComponent<MeshRenderer>().enabled = true;

        IEnumerator PowerupCountdownRoutline()
        {
            yield return new WaitForSeconds(seconds);
            indicators[index].GetComponent<MeshRenderer>().enabled = false;
        }
    }


}
