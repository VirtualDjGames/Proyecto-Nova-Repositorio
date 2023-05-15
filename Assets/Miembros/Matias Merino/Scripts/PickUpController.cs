using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpController : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldObj;
    private Rigidbody heldObjRB;

    [Header("Physics Parameters")]
    [SerializeField] private float PickupRange = 10f;
    [SerializeField] private float PickupForce = 150f;

    [Header("References")]
    [SerializeField] private Button objButton;
    RaycastHit hit;


    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, PickupRange))
        {
            if (hit.collider.CompareTag("pickableObj"))
            {
                objButton.gameObject.SetActive(true);
            }
            else
            {
                objButton.gameObject.SetActive(false);
            }
        }
        else
        {
            objButton.gameObject.SetActive(false);
        }

        if (heldObj != null)
        {
            MoveObj();
        }
    }

    public void GrabObj()
    {
        if (heldObj == null)
        {
            PickupObj(hit.transform.gameObject);
        }
        else
        {
            DropObj();
        }
    }
    void MoveObj()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDir = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDir * PickupForce);
        }
    }

    void PickupObj(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObj()
    {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 10;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObj.transform.parent = null;
        heldObj = null;
    }
}
