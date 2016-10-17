using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public enum ControlState
    {
        Stuck, // player can look but cant move
        Free, // player is free to move and look
        None // player cannot look or move
    }

    private ControlState controlState = ControlState.Free;

    private CharacterController _CharacterController;
    private Transform _Camera;

    //private const float accelWalk = 30;
    private const float moveSpeedWalk = 2f;
    private const float moveSpeedRun = 4f;
    private const float mouseSense = 3f;

    // Use this for initialization
    void Start()
    {
        _CharacterController = GetComponent<CharacterController>();
        _Camera = transform.GetChild(0);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (controlState == ControlState.Free || controlState == ControlState.Stuck)
        {
            Look();
        }
    }

    public void FixedUpdate()
    {
        if (controlState == ControlState.Free)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 input = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
        input.Normalize();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _CharacterController.SimpleMove(input * moveSpeedRun);
        }
        else
        {
            _CharacterController.SimpleMove(input * moveSpeedWalk);
        }
        if (!_CharacterController.isGrounded)
        {
            _CharacterController.Move(Vector3.zero);
        }
    }

    void Look()
    {
        if (!Cursor.visible)
        {
        Vector2 mouseIn = Vector2.right * Input.GetAxis("Mouse X") + Vector2.up * Input.GetAxis("Mouse Y");
        mouseIn *= mouseSense;
        transform.Rotate(Vector3.up, mouseIn.x);

        float newRotX = mouseIn.y;
        Quaternion targetRotation = _Camera.localRotation;

        targetRotation *= Quaternion.Euler(-newRotX, 0f, 0f);
        targetRotation = MouseLook.ClampRotationAroundXAxis(targetRotation, -90, 90);

        _Camera.localRotation = targetRotation;
        }
        CheckCursorLock();
    }

    public void CheckCursorLock()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
