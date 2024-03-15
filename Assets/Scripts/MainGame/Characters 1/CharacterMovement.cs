using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator; // Referencia al componente Animator
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    float horizontalMove = 1f;

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el componente Animator del objeto
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Establecer la velocidad del parámetro "Speed" en el Animator para controlar las animaciones de movimiento
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            // Establecer el parámetro "IsJumping" en true cuando se inicia el salto
        }

        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
    }

    // Método llamado cuando el personaje aterriza después de un salto
    
}
