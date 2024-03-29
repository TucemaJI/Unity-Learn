using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly string HorizontalAxis = "Horizontal";
    private readonly string VerticalAxis = "Vertical";

    private int Speed { get; set; }
    private float HPAtMoving { get; set; }
    private float HorizontalInput { get; set; }
    private float VerticalInput { get; set; }
    private Rigidbody PlayerRigidbody { get; set; }

    [SerializeField] private float horsePower = 10000f;
    [SerializeField] private float turnSpeed = 20f;
    [SerializeField] private string inputId;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private List<WheelCollider> allWheels;

    private void Start(){
        PlayerRigidbody = GetComponent<Rigidbody>();
        //PlayerRigidbody.centerOfMass = centerOfMass.transform.position;
    }

    private void FixedUpdate()
    {
        HorizontalInput = Input.GetAxis(HorizontalAxis + inputId);
        VerticalInput = Input.GetAxis(VerticalAxis + inputId);

        if (IsOnGround()) { return; }
        //Moves & Rotates the vehicle
        Speed = Mathf.RoundToInt(PlayerRigidbody.velocity.magnitude * 3.6f);//2.237f for MpH
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * VerticalInput);
        HPAtMoving = Speed < 5 ? 50000 : horsePower;
        PlayerRigidbody.AddRelativeForce(Vector3.forward * VerticalInput * HPAtMoving);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * HorizontalInput);
        speedometerText.SetText($"Speed: {Speed}");
        rpmText.SetText($"RPM: {Mathf.RoundToInt(Speed % 30 * 40)}");
    }

    private bool IsOnGround(){
        return allWheels.Exists(x => !x.isGrounded);
    }
}
