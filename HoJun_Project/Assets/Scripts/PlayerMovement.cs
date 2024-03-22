using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _MoveSpeed = 10F;
    [SerializeField] private float _RotateSpeed = 75F;

    [SerializeField] private Rigidbody _Rb;

    [SerializeField] private LayerMask _LayerMask;
    [SerializeField] private CapsuleCollider _CapCol;

    // 이동
    private float _VInput;
    private float _HInput;

    // 점프
    private float _JumpVelocity = 5F;
    private bool _IsJump = false;
    private float _DistanceToGround = 0.1f;

    private void Update()
    {
        // 이동
        _VInput = Input.GetAxis("Vertical") * _MoveSpeed;
        _HInput = Input.GetAxis("Horizontal") * _RotateSpeed;

        this.transform.Translate(Vector3.forward * _VInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _HInput * Time.deltaTime);

        // 점프
        _IsJump |= Input.GetKeyDown(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        if (IsGrounded() && _IsJump) 
        {
            Jump();
        }

        _IsJump = false;
    }

    private void Jump()
    {
        _Rb.AddForce(Vector3.up * _JumpVelocity, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_CapCol.bounds.center.x,
            _CapCol.bounds.min.y, _CapCol.bounds.center.z);

        bool isGround = Physics.CheckCapsule(_CapCol.bounds.center,
            capsuleBottom, _DistanceToGround, _LayerMask,
            QueryTriggerInteraction.Ignore);

        return isGround;
    }
}
