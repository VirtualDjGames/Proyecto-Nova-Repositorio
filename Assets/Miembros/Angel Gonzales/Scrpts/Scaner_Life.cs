using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaner_Life : MonoBehaviour
{
    public float grouth = 5;
    public float force = 2;
    public float destroyTime = 5;
    public Color colorScanner;
    public Renderer render;
    
    // Start is called before the first frame update
    void Start()
    {
        render.material.SetColor("_Sc_Color",colorScanner);
        DestroyObject();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorMesh = transform.localScale;
        float growing = grouth * Time.deltaTime * force;
       
        transform.localScale = new Vector3(vectorMesh.x + growing, vectorMesh.y + growing, vectorMesh.z + growing);

    }
    void DestroyObject() 
    {
        Destroy(gameObject, destroyTime);
    }
    public void ScanerValues(float value) 
    {
        this.grouth = value;
        Mathf.Clamp(destroyTime, value * 30, value * 50);
        
       
    }

    
}
