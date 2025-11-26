using UnityEngine;

public class moverPato : MonoBehaviour
{
    private Transform miTransform;
    private Animator miAnimator;
    private int velX, velY;
    public int velocidad;
    private float crono = 0;
    private bool moverse = true;

    private Rigidbody2D rb;
    private Collider2D col;
    void Start()
    {
        miTransform = this.transform;
        miAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();   
        col = GetComponent<Collider2D>();
        velY = 1;
        velX = 1;
    }

    void Update()
    {
        if (moverse)
        {
            Vector3 _velocidad = new Vector3(velX, velY, 0);
            miTransform.Translate(_velocidad * velocidad * Time.deltaTime);

            crono += Time.deltaTime;

            if (crono > 1)
            {
                crono = 0;

                velY = Random.Range(0, 2); //velY se mueve en rango 0 y 1 ... la funcion esta hecha para que el segundo numero no entre, es decir es 0,1, el dos no cuenta.
                velX = Random.Range(0, 2);//hay que meter correcion, no queremos el 0


                if (velX == 0)
                    velX = -1;
                else
                    velX = 1;
            }

            miTransform.localScale = new Vector3(velX, 1, 1);

           
            miAnimator.SetInteger("VelY", velY);
        }
    }

    //nuevo metodo publico para comunicarnos con jUgador y Hit
    // M�todo llamado cuando el pato recibe un impacto
    public void impactoPato()
    {
      
        moverse = false;
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 1;
        col.enabled = false;
        miAnimator.SetTrigger("ImpactoPato");

        controlJuego control = Object.FindAnyObjectByType<controlJuego>();
        if(control != null)
        {
            control.sumarPuntos(25);

        }
 
    }
    public void caerPato()

    {
        this.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag.Equals("limite"))
        {
            Destroy(this.gameObject);

        }
    }
}
