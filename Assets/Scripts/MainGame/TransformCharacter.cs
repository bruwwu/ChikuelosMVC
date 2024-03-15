using Cinemachine;
using UnityEngine;
using TMPro;
using System.Collections;

public class TransformCharacter : MonoBehaviour
{
    public GameObject newCharacterPrefab; // Prefab del nuevo personaje
    public CinemachineVirtualCamera cam2;
    public CinemachineVirtualCamera cam1;
    public float transformationTime = 5f; // Tiempo en segundos antes de regresar

    private Coroutine transformationCoroutine; // Referencia a la corrutina de transformación activa
    private Vector3 respawnPoint; // Punto de reaparición del jugador

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto con el que colisiona es el ítem deseado
        if (other.CompareTag("Player"))
        {
            Debug.Log("Transformado");

            // Crear una instancia del nuevo personaje en la posición del ítem recolectable
            GameObject newCharacter = Instantiate(newCharacterPrefab, transform.position, transform.rotation);

            // Guardar la posición del nuevo personaje como punto de reaparición del jugador
            respawnPoint = newCharacter.transform.position;

            // Desactivar el sprite y el colisionador del ítem recolectable
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;

            // Desactivar al jugador actual
            other.gameObject.SetActive(false);

            // Cambiar las cámaras
            VCOff();

            // Iniciar el temporizador para la transformación de regreso
            transformationCoroutine = StartCoroutine(ReturnTransformation(other.gameObject));
        }
    }

    // Método para desactivar la primera cámara y activar la segunda
    private void VCOff()
    {
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(true);
    }

    // Método para activar la primera cámara y desactivar la segunda
    private void VCOn()
    {
        cam1.gameObject.SetActive(true);
        cam2.gameObject.SetActive(false);
    }

    // Corrutina para el tiempo de espera antes de regresar de la transformación
    private IEnumerator ReturnTransformation(GameObject playerObject)
    {
        yield return new WaitForSeconds(transformationTime);

        // Activar al jugador actual en el punto de reaparición
        playerObject.transform.position = respawnPoint;
        playerObject.SetActive(true);
        

        // Cambiar las cámaras
        VCOn();

        // Detener la corrutina
        transformationCoroutine = null;
    }
}
