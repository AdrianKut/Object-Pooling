using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;
    private bool _isLockedCursor = false;

    private void LateUpdate()
    {
        ChangeCursorState();
        Movement();
        Crouch();
        Jump();
    }

    private void ChangeCursorState()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switch (_isLockedCursor)
            {
                case true:
                    Cursor.lockState = CursorLockMode.None;
                    _isLockedCursor = false;
                    break;
                case false:
                    Cursor.lockState = CursorLockMode.Locked;
                    _isLockedCursor = true;
                    break;
            }
        }
    }

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            var cameraTransform =  Camera.main.transform;
            cameraTransform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var cameraTransform = Camera.main.transform;
            cameraTransform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
        }
    }

    private void Movement()
    {
        var transformCamera = Camera.main.transform;

        if (Input.GetMouseButton(1))
        {
            float xMouse = Input.GetAxis("Mouse X");
            float yMouse = Input.GetAxis("Mouse Y");

            var currentRotation = Quaternion.Euler(transformCamera.rotation.eulerAngles + new Vector3(-yMouse, xMouse, 0)
                * _rotationSpeed * Time.deltaTime);
            transformCamera.rotation = currentRotation;
        }

        float xKeyboard = Input.GetAxis("Horizontal");
        float yKeyboard = Input.GetAxis("Vertical");

        var moveDirection = new Vector3(xKeyboard, 0f, yKeyboard) * _moveSpeed * Time.deltaTime;
        transformCamera.Translate(moveDirection);
    }
}