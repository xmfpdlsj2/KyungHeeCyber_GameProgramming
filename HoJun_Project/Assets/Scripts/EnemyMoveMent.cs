using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveMent : MonoBehaviour
{
    [Header("������̼�")]
    [SerializeField] private Transform _MainChar;
    [SerializeField] private NavMeshAgent _NavAgent;

    [Header("��Ʈ��")]
    [SerializeField] private Transform[] _PatrolPos;

    private int _PatrolIndex = 0;


    private void Update()
    {
        if (_NavAgent.remainingDistance < 0.2f && _NavAgent.pathPending == false)
        {
            MoveToNextPatrolPos();
        }
    }

    private void MoveToNextPatrolPos()
    {
        if (_PatrolPos.Length <= 0 )    // ��� �ڵ�
        {
            return;
        }

        _NavAgent.destination = _PatrolPos[_PatrolIndex].position;
        _PatrolIndex = (_PatrolIndex + 1) % _PatrolPos.Length;  // �ε��� �ݺ�
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == _MainChar.gameObject.name)
        {
            _NavAgent.destination = _MainChar.position;
        }
    }
}
