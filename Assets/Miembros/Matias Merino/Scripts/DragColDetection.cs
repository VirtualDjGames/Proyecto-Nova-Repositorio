using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragColDetection : MonoBehaviour
{
    public GameObject dc;
    public void OnTriggerEnter(Collider col)
    {

        if (col.tag == "pickableObj")
        {

            dc.GetComponent<DoorControllerDrag>().OpenDoor();

        }
    }
}
