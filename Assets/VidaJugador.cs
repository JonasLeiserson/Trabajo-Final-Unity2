using UnityEngine;
using TMPro;

public class VidaJugador : MonoBehaviour
{
    public static VidaJugador Instance { get; private set; }

    public float vidaActual = 100f;
    public TextMeshProUGUI textoVida;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        ActualizarUI();
    }

    public void RecibirDaño(float cantidad)
    {
        vidaActual -= cantidad;
        ActualizarUI();

        if (vidaActual <= 0)
        {
            Debug.Log("El jugador ha muerto.");
        }
    }

    private void ActualizarUI()
    {
        if (textoVida != null)
        {
            textoVida.text = vidaActual.ToString("F0");
        }
    }
}