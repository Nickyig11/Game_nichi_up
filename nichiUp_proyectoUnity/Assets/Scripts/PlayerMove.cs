using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 7; 
    public float rotationSpeed = 250;
    public float mouseSensitivity = 5f; // Sensibilidad para el giro con el ratón

    public Animator animator;
    public Rigidbody rb;
    public float fuerzaSalto = 8;
    public bool puedoSaltar;

    private float x, y;

    void FixedUpdate()
    {
        // Calcular la dirección de movimiento relativa a la rotación actual
        Vector3 direccionMovimiento = transform.forward * y + transform.right * x;
        Vector3 movimiento = direccionMovimiento.normalized * runSpeed * Time.deltaTime;

        // Aplicar el movimiento
        rb.MovePosition(rb.position + movimiento);
    }

    void Update()
    {
        HandleMouseRotation(); // Rotar el jugador con el ratón

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("salte", true);
                rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            }
            animator.SetBool("tocoSuelo", true);
        }
        else
        {
            EstoyCayendo();
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector3.up * Physics.gravity.y * 2 * Time.deltaTime; 
            }
        }
    }

    void HandleMouseRotation()
    {
        float mouseInputX = Input.GetAxis("Mouse X");
        float rotationY = mouseInputX * mouseSensitivity;

        // Aplicar la rotación suavemente
        transform.Rotate(0, rotationY, 0);
    }

    public void EstoyCayendo()
    {
        animator.SetBool("tocoSuelo", false);
        animator.SetBool("salte", false);
    }
}
