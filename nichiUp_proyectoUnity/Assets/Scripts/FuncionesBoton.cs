using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class FuncionesBoton : MonoBehaviour
{
    public void empezarJuego()
    {
        SceneManager.LoadScene(1);
    }
    public void salirJuego()
    {
        Application.Quit();
    }
    public void OpcionesJuego()
    {
        Debug.Log("Opciones juego");
    }

    public void VoverAMenu()
    {
        SceneManager.LoadScene(0);
    }
        public void escenaWin()
    {
        SceneManager.LoadScene(2);
    }
}
