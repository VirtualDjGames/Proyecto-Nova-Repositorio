using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorControllerKey : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float interactDistance = 10f; // Distancia a la que el jugador puede interactuar con la puerta
    public Button doorButton; 
    public Button keyButton; 
    public float rotationSpeed = 90f;
    public float tr;
    public Transform posPuerta;
    public Transform posLlave;
    //public GameObject llave;

    private bool nearKey = false;
    private bool nearDoor = false; // Variable para controlar si el jugador está cerca de la puerta
    private bool doorOpened = false; // Variable para controlar si la puerta está abierta
    private bool hasKey = false;

    private void Update()
    {
        float distanceKey = Vector3.Distance(posLlave.position, player.position);
        float distanceDoor = Vector3.Distance(posPuerta.position, player.position);

        if (distanceDoor <= interactDistance && doorOpened == false)
        {
            if (!nearDoor)
            {
                nearDoor = true;
                doorButton.gameObject.SetActive(true);
            }
        }
        else
        {
            if (nearDoor)
            {
                nearDoor = false;
                doorButton.gameObject.SetActive(false);
            }
        }

        if (distanceKey <= interactDistance)
        {
            if (!nearKey)
            {
                nearKey = true;
                keyButton.gameObject.SetActive(true);
            }
        }
        else
        {
            if (nearKey)
            {
                nearKey = false;
                keyButton.gameObject.SetActive(false);
            }
        }
    }

    public void PickKey()
    {
        hasKey = true;
        posLlave.gameObject.SetActive(false);
        keyButton.gameObject.SetActive(false);
    }
    public void OpenDoor()
    {
        // Si la puerta ya está abierta, no hacer nada
        if (doorOpened)
            return;
        if (hasKey == true)
        {
            // Rota la puerta hacia la posición abierta
            Quaternion targetRotation = Quaternion.Euler(0f, tr, 0f);
            StartCoroutine(RotateDoor(targetRotation));

            // Marca la puerta como abierta
            doorOpened = true;
            doorButton.gameObject.SetActive(false);
        }
    }

    private IEnumerator RotateDoor(Quaternion targetRotation)
    {
        // Obtiene la rotación actual de la puerta
        Quaternion startRotation = transform.rotation;

        // Calcula el tiempo total de rotación en función de la velocidad de rotación
        float rotationTime = Quaternion.Angle(startRotation, targetRotation) / rotationSpeed;

        // Realiza la rotación gradual de la puerta
        float elapsedTime = 0f;
        while (elapsedTime < rotationTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / rotationTime);
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
            yield return null;
        }
    }
}

