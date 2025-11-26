using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{


    public GameObject patoVerde;
    public float tiempoSpawn = 1f;
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
        InvokeRepeating(nameof(SpawnearPato), 1f, tiempoSpawn);
    }

  
    void SpawnearPato()
    {
        Vector3 posicion = posAleatoria();
        Instantiate(patoVerde, posicion, Quaternion.identity);
    }

    Vector3 posAleatoria()
    {
        float x = Random.Range(0f, 1f);
        float y = 0.5f;
        Vector3 posviewport = new Vector3(x, y, 10f);
        return cam.ViewportToWorldPoint(posviewport);     
    }
}
