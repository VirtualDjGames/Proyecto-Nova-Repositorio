using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterials : MonoBehaviour
{
    public Material thisMaterial;
    public Material wireMaterial;

    public Renderer render;
    public float timer;
    public bool change;
    // Start is called before the first frame update
    void Start()
    {
        thisMaterial = render.material;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Scanner")
        {
            Invoke("changeMaterial", 1.2f);
        }
    }

}
