using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorControllerDrag : MonoBehaviour
{
    public float rotationSpeed = 90f; // Velocidad de rotación de la puerta
    public float tr;
    private bool doorOpened = false; // Variable para controlar si la puerta está abierta


    public void OpenDoor()
    {
        // Si la puerta ya está abierta, no hacer nada
        if (doorOpened)
            return;

        // Rota la puerta hacia la posición abierta
        Quaternion targetRotation = Quaternion.Euler(0f, tr, 0f);
        StartCoroutine(RotateDoor(targetRotation));

        // Marca la puerta como abierta
        doorOpened = true;
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

