using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScaner : MonoBehaviour
{
    //este va en el player pa que cree los scaner en un intervalo de tiempo
    public AudioLoudnesDetection loudnesDetection;
    public float minimunLoudnes = 0.1f;  // el minimo que hace una voz en el microfono es de 0.01 mas abajo es ruido del ambiente
    public GameObject scanner;
    public bool canCreate;
    float LoudnessMicrophone;
    public float scannerCooldown = 0.8f;
    float timer;
    public Transform scannerPos;

    // Update is called once per frame
    void Update()
    {
        LoudnessMicrophone = loudnesDetection.GetLoudnessFromMicrophone();
        if (LoudnessMicrophone > minimunLoudnes && canCreate)
        {
            GameObject scaner = Instantiate(scanner, scannerPos.position, transform.rotation);
            scanner.GetComponent<Scaner_Life>().ScanerValues(LoudnessMicrophone);
            canCreate = false;
            Debug.Log("alcanzaste el minimo");
            timer = 0;

        }

        if (!canCreate)
            timer += Time.deltaTime;

        if (timer >= scannerCooldown)
            canCreate = true;
    }
}
