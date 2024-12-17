using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 7; 
    public float rotationSpeed = 250;
    public float mouseSensitivity = 5f; // Sensibilidad para el giro con el rat�n

    public Animator animator;
    public Rigidbody rb;
    public float fuerzaSalto = 8;
    public bool puedoSaltar;

    private float x, y;

    void FixedUpdate()
    {
        // Calcular la direcci�n de movimiento relativa a la rotaci�n actual
        Vector3 direccionMovimiento = transform.forward * y + transform.right * x;
        Vector3 movimiento = direccionMovimiento.normalized * runSpeed * Time.deltaTime;

        // Aplicar el movimiento
        rb.MovePosition(rb.position + movimiento);
    }

    void Update()
    {
        HandleMouseRotation(); // Rotar el jugador con el rat�n

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

        // Aplicar la rotaci�n suavemente
        transform.Rotate(0, rotationY, 0);
    }

    public void EstoyCayendo()
    {
        animator.SetBool("tocoSuelo", false);
        animator.SetBool("salte", false);
    }

    // Detectar contacto con el Canvas o cualquier objeto con etiqueta "Canvas"
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Canvas")) // Verifica que el objeto tenga la etiqueta "Canvas"
        {
            Debug.Log("Contacto con Canvas. Cargando escena 2...");
            SceneManager.LoadScene(2); // Cambia a la escena con �ndice 2
        }
        if (other.CompareTag("Canvas2")) // Detecta colisi�n con el Canvas2
        {
            Debug.Log("Contacto con Canvas2. Cargando escena 1...");
            SceneManager.LoadScene(1); // Cambia a la escena 1
        }
    }
    
}
