using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Hp : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MainChar")
        {
            this.gameObject.SetActive(false);
        }

        Debug.Log("#### OnCollisionEnter");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MainChar")
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            Debug.Log("#### OnTriggerEnter");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "MainChar")
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("#### OnTriggerExit");
        }
    }
}
