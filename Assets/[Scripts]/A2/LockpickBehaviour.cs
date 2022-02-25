using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockpickBehaviour : MonoBehaviour
{
    public float mouseSensitivity = 1.0f;
    public Transform lockPick;

    public float lockpickVal;

    private float YRotation = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        YRotation -= mouseX;
        YRotation = Mathf.Clamp(YRotation, -90.0f, 90.0f);

        lockpickVal = YRotation + 90.0f;

        //print(lockpickVal);

        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, YRotation);
        lockPick.Rotate(Vector3.right * mouseY);
    }
}
