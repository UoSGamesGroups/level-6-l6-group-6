using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    public enum ControlState
    {
        Stuck, // player can look but cant move
        Free, // player is free to move and look
        None // player cannot look or move
    }

    private ControlState controlState = ControlState.Free;
    private Rigidbody _Rigidbody;
    private Transform _Camera;

    //private const float accelWalk = 30;
    private const float moveSpeedWalk = 5f;
    private const float moveSpeedRun = 10f;
    private const float mouseSense = 3f;

    // Use this for initialization
    void Start()
    {
        _Rigidbody = GetComponent<Rigidbody>();
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

        if (input != Vector3.zero)
        {
            input.Normalize();

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _Rigidbody.velocity += input * moveSpeedRun;
                if (_Rigidbody.velocity.magnitude > moveSpeedRun)
                {
                    _Rigidbody.velocity = _Rigidbody.velocity.normalized * moveSpeedRun;
                }
            }
            else
            {
                _Rigidbody.velocity += (input * moveSpeedWalk);
                if (_Rigidbody.velocity.magnitude > moveSpeedWalk)
                {
                    _Rigidbody.velocity = _Rigidbody.velocity.normalized * moveSpeedWalk;
                }
            }
        }
        else
        {
            _Rigidbody.velocity = -_Rigidbody.velocity / moveSpeedRun;
        }
    }

    void Look()
    {
        Vector2 mouseIn = Vector2.right * Input.GetAxis("Mouse X") + Vector2.up * Input.GetAxis("Mouse Y");
        mouseIn *= mouseSense;
        transform.Rotate(Vector3.up, mouseIn.x);

        float newRotX = mouseIn.y;
        Quaternion targetRotation = _Camera.localRotation;

        targetRotation *= Quaternion.Euler(-newRotX, 0f, 0f);
        targetRotation = MouseLook.ClampRotationAroundXAxis(targetRotation, -90, 90);

        _Camera.localRotation = targetRotation;
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
