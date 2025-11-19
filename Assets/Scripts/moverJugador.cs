using UnityEngine;
using UnityEngine.Rendering;

public class moverJugador : MonoBehaviour
{

    private Transform miTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        miTransform= this.transform;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        miTransform.position = worldPosition;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePos;
        if(Input.GetMouseButton(0))
        {
            disparar();
        }
    }

    private void disparar() //Rayo

    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), //el concepto hit nos permite trabajar con el pato depsues
                                                                                         Vector2.zero);
        if (hit.collider != null)

        {
            //He chocado con algo
            if (hit.collider.tag == "pato")
            {
                hit.collider.gameObject.GetComponent<moverPato>().impactoPato();
            }
        }

    }
}
