using UnityEngine;

public class CharacterClimbingController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb; // Referencia al Rigidbody
    private bool isClimbing = false;

    void Start()
    {
        // Obt�n el Animator y Rigidbody
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("No se encontr� el Rigidbody en el GameObject");
        }

        TriggerClimbingAnimation();
    }

    void Update()
    {
        if (isClimbing)
        {
            // Comprueba si la animaci�n est� en su �ltimo fotograma
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                // Mant�n la animaci�n fija en el �ltimo fotograma
                animator.Play("Climbing", 0, 1.0f);
                isClimbing = false; // Det�n la comprobaci�n para evitar llamadas repetidas
            }
        }

        HandleMovement(); // L�gica para el movimiento del personaje
    }

    void HandleMovement()
    {
        if (isClimbing)
        {
            float moveSpeed = 2f; // Velocidad de movimiento mientras est�s escalando
            float verticalInput = Input.GetAxis("Vertical"); // Captura entrada vertical

            // Aplica el movimiento en la direcci�n Y (subir/bajar) mientras est�s escalando
            rb.velocity = new Vector3(0, verticalInput * moveSpeed, 0);
        }
    }

    public void TriggerClimbingAnimation()
    {
        // Activa la animaci�n de escalada
        animator.Play("Climbing");
        isClimbing = true;
    }
}
