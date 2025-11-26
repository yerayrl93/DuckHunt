using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escenaFinal : MonoBehaviour
{
    public TextMeshProUGUI textoTitulo;
    public TextMeshProUGUI textoPuntuacion;
    public TextMeshProUGUI textoMaxScore;

    void Start()
    {
        // Lee si fue victoria (1 = victoria, 0 = derrota)
        int esVictoria = PlayerPrefs.GetInt("EsVictoria", 0);

        // Leer puntajes guardados
        int scoreFinal = PlayerPrefs.GetInt("UltimoScore", 0); 
        int maxScore = PlayerPrefs.GetInt("MaxScore", 0);       

        // Mostrar textos
        if (textoPuntuacion != null)
            textoPuntuacion.text = "SCORE: " + scoreFinal;

        if (textoMaxScore != null)
            textoMaxScore.text = "MEJOR SCORE: " + maxScore;

        if (textoTitulo != null)
            textoTitulo.text = (esVictoria == 1) ? "YOU WIN" : "GAME OVER";
    }

    // Método para el botón
    public void reiniciarJuego()
    {
        SceneManager.LoadScene("Juego");
    }
}
