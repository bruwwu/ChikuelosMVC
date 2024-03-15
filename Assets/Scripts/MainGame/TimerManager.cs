using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float maxTime = 10f; // Tiempo máximo
    private float currentTime; // Tiempo actual
    private bool timerActive = false; // Bandera para activar/desactivar el temporizador
    public int counter = 0; // Contador público para realizar el seguimiento

    public TMP_Text timer;

    void Start()
    {
        currentTime = 0;
        UpdateTimerText(); // Actualizar el texto del temporizador
        timer.enabled = false; 
    }
    
    public void StartTimer()
    {
        timerActive = true;
        currentTime = maxTime; // Reiniciar el temporizador al máximo tiempo

        // Reiniciar el contador cuando se inicia el temporizador
        counter = 0;
    }

    void Update()
    {
        // Solo actualizar el temporizador si está activo
        if (timerActive)
        {
            if (currentTime > 0f)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                // Cuando el tiempo llega a cero, desactivar el temporizador
                currentTime = 0f;
                timerActive = false;
            }
        }
    }

    // Método para actualizar el texto del temporizador
    void UpdateTimerText()
    {
        timer.text = currentTime.ToString("f2");
    }
}
