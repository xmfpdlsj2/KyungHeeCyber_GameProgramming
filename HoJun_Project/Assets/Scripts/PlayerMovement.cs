using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _MoveSpeed = 10F;
    [SerializeField] private float _RotateSpeed = 75F;

    [SerializeField] private Rigidbody _Rb;

    private float _VInput;
    private float _HInput;

    private void Update()
    {
        _VInput = Input.GetAxis("Vertical") * _MoveSpeed;
        _HInput = Input.GetAxis("Horizontal") * _RotateSpeed;

        this.transform.Translate(Vector3.forward * _VInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _HInput * Time.deltaTime);
    }

    //private void FixedUpdate()
    //{
    //    var rot = Vector3.up * _HInput;
    //    var angleRot = Quaternion.Euler(rot * Time.fixedDeltaTime);
    //    _Rb.MovePosition(this.transform.position +
    //        this.transform.forward * _VInput * Time.fixedDeltaTime);
    //    _Rb.MoveRotation(_Rb.rotation * angleRot);
    //}
}
