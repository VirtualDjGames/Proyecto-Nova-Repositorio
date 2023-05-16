using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragColDetection : MonoBehaviour
{
    public DoorControllerDrag dc;
    public void OnTriggerEnter(Collider col)
    {

        if (col.transform.tag == "pickableObj")
        {

            dc.OpenDoor();

        }
    }
}
