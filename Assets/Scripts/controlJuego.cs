using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlJuego : MonoBehaviour
{
    private const float TIEMPO_INICIAL = 60f;
    private float tiempoTranscurrido = TIEMPO_INICIAL;
    [SerializeField] private TextMeshProUGUI textoCronometro;
    private bool juegoTerminado = false;

    [SerializeField] private int puntos = 0;
    [SerializeField] private TextMeshProUGUI textoPuntuacion;

    void Start()
    {
        Time.timeScale = 1f;
        if (textoCronometro != null)
        {
            int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60F);
            int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60F);
            textoCronometro.text = string.Format("{0:00}:{1:00}", minutos, segundos);

        }
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = "SCORE: " + puntos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            SceneManager.LoadScene("Juego");

        }

        if (Time.timeScale > 0)
        {
            tiempoTranscurrido -= Time.deltaTime;
            if(tiempoTranscurrido <= 0f )
            {
                tiempoTranscurrido = 0f;
                FinDelJuego(false);
                return;
            }

            if (textoCronometro != null)
            {
                int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60F);
                int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60F);
                textoCronometro.text = string.Format("{0:00}:{1:00}", minutos, segundos);
            }
        }
    }

    public void sumarPuntos (int cantidad)
    {
        if (juegoTerminado) return;
        puntos += cantidad;
        if(textoPuntuacion != null)
        {
            textoPuntuacion.text = "Score: " + puntos;
        }
    }
    private void FinDelJuego(bool victoria)
    {
        if (juegoTerminado) return;
        juegoTerminado = true;
        Time.timeScale = 0f; 
        
    }
}

