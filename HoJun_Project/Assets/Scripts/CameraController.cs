using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 _CameraPos = new Vector3(0F, 1.2f, -3F);
    [SerializeField] private Transform _Player;

    private void LateUpdate()
    {
        this.transform.position = _Player.TransformPoint(_CameraPos);
        this.transform.LookAt(_Player);
    }
}
