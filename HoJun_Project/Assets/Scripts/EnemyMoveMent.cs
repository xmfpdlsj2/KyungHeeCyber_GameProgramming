using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveMent : MonoBehaviour
{
    [SerializeField] private Transform _MainChar;
    [SerializeField] private NavMeshAgent _NavAgent;


    private void Update()
    {
        _NavAgent.destination = _MainChar.position;
    }
}
