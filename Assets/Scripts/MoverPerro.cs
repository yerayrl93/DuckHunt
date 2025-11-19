using UnityEngine;

public class MoverPerro : MonoBehaviour
{
    private Transform miTransform;
    public int velocidad;
    public GameObject posPararPerro; //PUBLIC PARA AÑADIRLO GAMEOBJECT PORQUE ES EL OBJETO QUE HEMOS CREADO Y POSPARARPERRO ES EL NOMBRE QUE LE HE LLAMADO
    private Animator miAnimator;
    
    void Start()
    {
        miTransform = this.transform;
        miAnimator = GetComponent<Animator>(); //REPASAR LO TENGO MAL
    }

    
    void Update()
    {
        miTransform.Translate(Vector3.right * velocidad * Time.deltaTime);
        if(miTransform.position.x >= posPararPerro.transform.position.x)
        {
            velocidad = 0;
            miAnimator.SetTrigger("pararPerro");
        }
    }



    public void desaparecer()
    {
        Destroy(this.gameObject);

    }
}
