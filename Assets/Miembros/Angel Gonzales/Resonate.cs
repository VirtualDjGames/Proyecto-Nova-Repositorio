using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resonate : MonoBehaviour
{
    public GameObject scanner;
    public Color color;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Scanner")
        {
            GameObject scaned = Instantiate(scanner, transform.position, transform.rotation);
            scaned.GetComponent<Renderer>().material.SetColor("_Sc_Color",color);

        }
    }
}
