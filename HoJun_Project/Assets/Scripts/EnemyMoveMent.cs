using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMoveMent : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;

    [Header("내비게이션")]
    [SerializeField] private Transform _MainChar;
    [SerializeField] private NavMeshAgent _NavAgent;

    [Header("패트롤")]
    [SerializeField] private Transform[] _PatrolPos;
    
    private int _PatrolIndex = 0;
    private int _Hp = 3;

    private float _DefaultSpeed = 3.5f;
    private float _ChaseSpeed = 8.5f;
    private float _ChaseTime = 0F;

    private void Update()
    {
        if (_NavAgent.remainingDistance < 0.2f && _NavAgent.pathPending == false)
        {
            _NavAgent.speed = _DefaultSpeed;
            MoveToNextPatrolPos();
        }
    }

    private void MoveToNextPatrolPos()
    {
        if (_PatrolPos.Length <= 0 )    // 방어 코드
        {
            return;
        }

        _NavAgent.destination = _PatrolPos[_PatrolIndex].position;
        _PatrolIndex = (_PatrolIndex + 1) % _PatrolPos.Length;  // 인덱스 반복
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == _MainChar.gameObject.name)
        {
            _ChaseTime = 3F;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        _ChaseTime -= Time.deltaTime;
        if (_ChaseTime < 0F)
        {
            return;
        }

        if (other.name == _MainChar.gameObject.name)
        {
            _NavAgent.speed = _ChaseSpeed;
            _NavAgent.destination = _MainChar.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            _Hp--;
            if (_Hp <= 0 )
            {
                _GameManager.EnemyDown();
                return;
            }

            Debug.Log($"Damge by Player!(Hp: [{_Hp}])");
        }
    }
}