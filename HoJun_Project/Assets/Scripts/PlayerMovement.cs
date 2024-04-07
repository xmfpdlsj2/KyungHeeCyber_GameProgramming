using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("ī�޶�")]
    [SerializeField] private Transform _MainCamera;

    [Header("�̵� ����")]
    [SerializeField] private float _MoveSpeed = 10F;
    [SerializeField] private float _RotateSpeed = 75F;

    [SerializeField] private Rigidbody _Rb;

    [Header("���� ����")]
    [SerializeField] private LayerMask _LayerMask;
    [SerializeField] private CapsuleCollider _CapCol;

    [Header("�߻�ü ����")]
    [SerializeField] private GameObject _BulletPrefab;

    // �̵�
    private float _VInput;
    private float _HInput;

    // ����
    private float _JumpVelocity = 5F;
    private bool _IsJump = false;
    private float _DistanceToGround = 0.1f;

    // �߻�ü
    private float _BulletSpeed = 100F;
    private bool _IsShoot = false;


    private void Update()
    {
        // �̵�
        _VInput = Input.GetAxis("Vertical") * _MoveSpeed;
        _HInput = Input.GetAxis("Horizontal") * _RotateSpeed;

        this.transform.Translate(Vector3.forward * _VInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _HInput * Time.deltaTime);

        // ����
        _IsJump |= Input.GetKeyDown(KeyCode.Space);

        // �߻�ü
        _IsShoot |= Input.GetKeyDown(KeyCode.F);
    }

    private void FixedUpdate()
    {
        if (IsGrounded() && _IsJump) 
        {
            Jump();
        }

        if (_IsShoot)
        {
            GameObject newBullet = Instantiate(_BulletPrefab,
                this.transform.position + new Vector3(0F, 0F, 1F),
                this.transform.rotation);

            Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
            bulletRb.velocity = this.transform.forward * _BulletSpeed;

            Bullet.BulletCount();
        }

        _IsJump = false;
        _IsShoot = false;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            Debug.Log("Damge by Enemy!");
            _MainCamera.DOShakeRotation(0.5F, 10F);

            GameManager.Instance.PlayerHp--;
            GameManager.Instance.DecreaseHudValue(0);
        }
    }
}
