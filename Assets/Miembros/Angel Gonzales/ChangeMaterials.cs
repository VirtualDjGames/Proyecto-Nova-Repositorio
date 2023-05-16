using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterials : MonoBehaviour
{
    public Material thisMaterial;
    public Material wireMaterial;

    public Renderer render;
    public float timer, changeTime = 1.8f;
    public bool change;
    
    // Start is called before the first frame update
    


    // Update is called once per frame
    void Update()
    {
        if (change)
        {
            timer += Time.deltaTime;

            if (timer >= changeTime)
            {
                render.material = thisMaterial;
                change = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Scanner")
        {
            Invoke("changeMaterial", 1.2f);
        }
    }
    void changeMaterial() 
    {
        timer = 0;
        render.material = wireMaterial;
        change = true;
    }
}
