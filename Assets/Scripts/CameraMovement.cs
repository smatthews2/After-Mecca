using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float xRot, yRot;
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float Speed;
    private Vector2 MouseInput;
    private Vector3 MovementInput;

    // Start is called before the first frame update
    void Start()
    {
        // Uncomment once done.
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MoveCamera();
        RotateCamera();
    }

    private void MoveCamera()
    {
        Vector3 MoveVector = transform.TransformDirection(MovementInput);
        PlayerCamera.transform.position += MoveVector * Speed * Time.deltaTime;
    }

    private void RotateCamera()
    {
        xRot -= MouseInput.y * Sensitivity;
        yRot += MouseInput.x * Sensitivity;
        transform.Rotate(MouseInput.x * Sensitivity, MouseInput.y * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, yRot, 0f);
    }
}
