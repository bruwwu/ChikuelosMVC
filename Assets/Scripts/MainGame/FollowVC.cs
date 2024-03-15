using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVC : MonoBehaviour
{
    private Transform _transform; // Referencia al Transform del objeto que sigue
    private Transform _target; // Referencia al Transform del objetivo a seguir (jugador)

    // Método Start se llama una vez al inicio
    private void Start()
    {
        // Aquí se pueden agregar inicializaciones necesarias al iniciar el script
        // (Actualmente está vacío en este caso)
    }

    // Método Update se llama una vez por cada fotograma
    void Update()
    {
        _transform = transform; // Actualizamos la referencia al Transform del objeto que sigue

        // Buscamos al objeto del jugador por su etiqueta y obtenemos su Transform
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // Si el objetivo existe, movemos el objeto que sigue hacia él
        if (_target != null)
        {
            _transform.Translate((_target.position - _transform.position) * (15f * Time.deltaTime), Space.Self);
        }

        // Si encontramos al jugador, actualizamos la referencia al Transform del objetivo
        if (playerObject != null)
        {
            _target = playerObject.transform;
        }
        else
        {
            // Si el jugador no se encuentra, mostramos un mensaje de error en la consola
            Debug.LogError("Player object not found!");
        }
    }
}
