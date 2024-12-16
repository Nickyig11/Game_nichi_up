using UnityEngine;

public class CharacterClimbingController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb; // Referencia al Rigidbody
    private bool isClimbing = false;

    void Start()
    {
        // Obtén el Animator y Rigidbody
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("No se encontró el Rigidbody en el GameObject");
        }

        TriggerClimbingAnimation();
    }

    void Update()
    {
        if (isClimbing)
        {
            // Comprueba si la animación está en su último fotograma
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                // Mantén la animación fija en el último fotograma
                animator.Play("Climbing", 0, 1.0f);
                isClimbing = false; // Detén la comprobación para evitar llamadas repetidas
            }
        }

        HandleMovement(); // Lógica para el movimiento del personaje
    }

    void HandleMovement()
    {
        if (isClimbing)
        {
            float moveSpeed = 2f; // Velocidad de movimiento mientras estás escalando
            float verticalInput = Input.GetAxis("Vertical"); // Captura entrada vertical

            // Aplica el movimiento en la dirección Y (subir/bajar) mientras estás escalando
            rb.velocity = new Vector3(0, verticalInput * moveSpeed, 0);
        }
    }

    public void TriggerClimbingAnimation()
    {
        // Activa la animación de escalada
        animator.Play("Climbing");
        isClimbing = true;
    }
}
