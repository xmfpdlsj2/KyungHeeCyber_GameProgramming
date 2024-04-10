using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private static int TotalCount;
    private int LocalCount;

    private void Start()
    {
        Destroy(this.gameObject, 3F);
        Debug.Log($"\nTotalCount[{TotalCount}] // LocalCount[{LocalCount}]");
    }

    public static void BulletCount()
    {
        TotalCount++;
    }
}


