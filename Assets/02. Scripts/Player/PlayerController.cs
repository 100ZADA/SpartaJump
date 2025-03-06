using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;             // 플레이어의 이동 속도
    private Vector2 curMovementInput;   // 플레이어의 입력 값
    public float jumpPoewr;             // 플레이어의 점프력
    public LayerMask groundLayerMask;   // 레이어 정보

    [Header("Look")]
    public Transform cameraContainer;    // 카메라
    public float minXLook;              // 카메라 범위 최소값
    public float maxXLook;              // 카메라 범위 최대값
    private float camCurXRot;
    public float lookSensitivity;       // 카메라 민감도
    public bool canLook = true;

    private Vector2 mouseDelta;         // 마우스 변화 방법

    private Rigidbody _rigidbody;

    private PlayerCondition playerCondition;        // 플레이어 상태

    public float jumpStaminaCost = 10f;             // 점프 시 스테미나 소모

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        playerCondition = GetComponent<PlayerCondition>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;           // 시작 시 커서 안보임
    }

    private void FixedUpdate()
    {
        Move();
    }

    // 모든 동작 실행 후 실행
    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)                 // 동작 시 이동
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)             // 동작 안할 시 멈춤
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())       // 플레이어가 땅 위에 있을시 점프 가능
        {
            // 스테미나가 충분하면 점프
            if (playerCondition.UseStamina(jumpStaminaCost))
            {
                _rigidbody.AddForce(Vector3.up * jumpPoewr, ForceMode.Impulse);
            }
        }
    }

    // 캐릭터 이동
    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }

    // 카메라 회전 반경
    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    // 앞뒤 좌우의 좌표가 땅과 맞닿는지 확인
    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.2f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    // 마우스 커서 상태 유무
    public void ToggleCursor(bool toggle)
    {
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }
}