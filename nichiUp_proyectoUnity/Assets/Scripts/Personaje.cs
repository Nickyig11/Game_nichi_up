using UnityEngine;

public class Personaje : MonoBehaviour
{
    // Velocidades ajustables desde el Inspector
    public float velocidad = 5f;

    void Update()
    {
        // Obtener entradas de movimiento
        float movimientoHorizontal = Input.GetAxis("Horizontal"); // A/D o flechas izquierda/derecha
        float movimientoVertical = Input.GetAxis("Vertical"); // W/S o flechas arriba/abajo

        // Calcular la dirección del movimiento
        Vector3 movimiento = new Vector3(movimientoVertical, 0f, movimientoHorizontal);

        // Aplicar el movimiento al cubo
        transform.Translate(movimiento * velocidad * Time.deltaTime);
    }
}
