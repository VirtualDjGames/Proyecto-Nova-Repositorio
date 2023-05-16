using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class downCollision : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    public GameObject Joystick;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Joystick.SetActive(false);
            anim.SetBool("Cambio", true);
            SceneManager.LoadScene("Nivel_1");
        }
    }
}
