using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalWeno : MonoBehaviour
{
    public Animator anim;
    public GameObject Joystick;
    public GameObject texto1;
    public GameObject texto2;
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Joystick.SetActive(false);
            anim.SetBool("Cambio", true);
            texto1.SetActive(true);
            texto2.SetActive(true);
        }
    }
}
