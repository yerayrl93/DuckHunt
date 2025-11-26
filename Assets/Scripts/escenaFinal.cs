using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escenaFinal : MonoBehaviour
{

    public TextMeshProUGUI textoTitulo;
    public TextMeshProUGUI textoPuntuacion;
    public TextMeshProUGUI textoMaxScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int scoreFinal = PlayerPrefs.GetInt("Ultimo Score", 0);
        int maxScore = PlayerPrefs.GetInt("MaxScore, 0");
        if (textoPuntuacion != null)
            textoPuntuacion.text = "SCORE: " + scoreFinal;
        if (textoMaxScore != null)
            textoMaxScore.text = "MEJOR SCORE: " + maxScore;
        if (textoTitulo != null)
            textoTitulo.text = scoreFinal >= 1000 ? "YOU WIN" : "GAME OVER";
    }

    // Update is called once per frame
    public void reiniciarJuego()

    {
        SceneManager.LoadScene("Juego");
    }
}
