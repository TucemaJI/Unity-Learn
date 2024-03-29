using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator PlayerAnimator { get; set; }
    private Rigidbody PlayerRigidbody { get; set; }
    private AudioSource PlayerAudio { get; set; }
    private bool IsOnGround { get; set; }

    public bool GameOver { get; private set; } = false;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public float jumpForce;
    public float gravityModifier;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        PlayerAnimator = GetComponent<Animator>();
        PlayerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !GameOver)
        {
            PlayerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            IsOnGround = !IsOnGround;
            PlayerAnimator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            PlayerAudio.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
            dirtParticle.Play();
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver = true;
            Debug.Log("Game Over!");
            PlayerAnimator.SetBool("Death_b", true);
            PlayerAnimator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            PlayerAudio.PlayOneShot(crashSound);
        }
    }
}
