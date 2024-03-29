using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
public class ClickAndSwipe : MonoBehaviour
{
    private GameManager GameManager { get; set; }
    private Camera Camera { get; set; }
    private Vector3 MousePosition { get; set; }
    private TrailRenderer Trail { get; set; }
    private BoxCollider Collider { get; set; }

    private void Awake()
    {
        Camera = Camera.main;
        Trail = GetComponent<TrailRenderer>();
        Collider = GetComponent<BoxCollider>();

        Trail.enabled = false;
        Collider.enabled = false;

        GameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.IsGameActive) return;

        if(Input.GetMouseButton(0)){
            UpdateComponents(Input.GetMouseButton(0));
            UpdateMousePosition();
        }
        if(Input.GetMouseButtonUp(0)){
            UpdateComponents(!Input.GetMouseButtonUp(0));
        }
    }

    private void UpdateMousePosition(){
        MousePosition = Camera.ScreenToWorldPoint(new(Input.mousePosition.x, Input.mousePosition.y, 10f));
        transform.position = MousePosition;
    }

    private void UpdateComponents(bool enable){
        Trail.enabled = enable;
        Collider.enabled = enable;
    }

    private void OnCollisionEnter(Collision collision) => collision.gameObject.GetComponent<Target>()?.DestroyTarget();
}
