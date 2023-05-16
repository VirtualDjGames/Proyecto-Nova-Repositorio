using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float interactDistance = 3f; // Distancia a la que el jugador puede interactuar con la puerta
    public Button interactButton; // Referencia al bot�n de interacci�n en la interfaz de usuario
    public float rotationSpeed = 90f; // Velocidad de rotaci�n de la puerta
    public float tr;
    public Transform puerta;

    private bool nearDoor = false; // Variable para controlar si el jugador est� cerca de la puerta
    private bool doorOpened = false; // Variable para controlar si la puerta est� abierta

    private void Update()
    {
        // Calcula la distancia entre el jugador y la puerta
        float distance = Vector3.Distance(puerta.position, player.position);

        // Verifica si el jugador est� lo suficientemente cerca de la puerta
        if (distance <= interactDistance && doorOpened == false)
        {
            // El jugador est� cerca de la puerta
            if (!nearDoor)
            {
                // Si no estaba cerca antes, activa el bot�n de interacci�n
                nearDoor = true;
                interactButton.gameObject.SetActive(true);
            }
        }
        else
        {
            // El jugador no est� cerca de la puerta
            if (nearDoor)
            {
                // Si estaba cerca antes, desactiva el bot�n de interacci�n
                nearDoor = false;
                interactButton.gameObject.SetActive(false);
            }
        }
    }

    public void OpenDoor()
    {
        // Si la puerta ya est� abierta, no hacer nada
        if (doorOpened)
            return;

        // Rota la puerta hacia la posici�n abierta
        Quaternion targetRotation = Quaternion.Euler(0f, tr, 0f);
        StartCoroutine(RotateDoor(targetRotation));

        // Marca la puerta como abierta
        doorOpened = true;
    }

    private IEnumerator RotateDoor(Quaternion targetRotation)
    {
        // Obtiene la rotaci�n actual de la puerta
        Quaternion startRotation = transform.rotation;

        // Calcula el tiempo total de rotaci�n en funci�n de la velocidad de rotaci�n
        float rotationTime = Quaternion.Angle(startRotation, targetRotation) / rotationSpeed;

        // Realiza la rotaci�n gradual de la puerta
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

