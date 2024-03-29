using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    [SerializeField] private Camera firstCamera;
    [SerializeField] private Camera secondCamera;
    [SerializeField] private KeyCode switchKey;

    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            firstCamera.enabled = !firstCamera.enabled;
            secondCamera.enabled = !secondCamera.enabled;
        }
    }
}
