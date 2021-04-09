using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{
    const float VelocidadBase = 2.5f;
    float velocidad = 2.5f;
    float incremento = 0.1f;
    float steer = 0.5f;
    bool lucesFrontalesEncendidas = true;

    List<Texture2D> texturas =  new List<Texture2D>();
    int texturaActual = 0;
    int cantidadTexturas = 6;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i <= cantidadTexturas; i++)
        {

            texturas.Add(Resources.Load<Texture2D>("carro"+i));
        }
        gameObject.GetComponent<Renderer>().material.mainTexture = texturas[texturaActual];
    }

    // Update is called once per frame
    void Update()
    {
        Avanzar();
        RevisarInputs();
    }

    private void Avanzar()
    {
        //gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * velocidad * Time.deltaTime, ForceMode.Acceleration);
        Vector3 posicion = transform.position;
        posicion += transform.up * Time.deltaTime * velocidad;
        transform.position = posicion;
    }

    public void CambiarTextura()
    {
        if (texturaActual < texturas.Count - 1)
        {
            texturaActual++;
        }
        else
        {
            texturaActual = 0;
        }
        gameObject.GetComponent<Renderer>().material.mainTexture = texturas[texturaActual];
    }

    private void RevisarInputs()
    {
        float steeringInput = Input.GetAxis("Horizontal");
        Vector3 rotation = new Vector3(0,0,0);
        if (steeringInput < 0)
        {
            rotation = new Vector3(0, 0, steer);
        }
        else if (steeringInput > 0)
        {
            rotation = new Vector3(0, 0, -steer);
        }
        if (Input.GetKey("w"))
        {
            velocidad += incremento;
            print(velocidad);
        }
        else
        {
            if (velocidad > VelocidadBase)
            {
                velocidad -= incremento;
            }
        }
        transform.Rotate(rotation);
        if (Input.GetKeyDown("l"))
        {
            GameObject[] lucesFrontales = GameObject.FindGameObjectsWithTag("luzFrontal");
            foreach(GameObject luzFrontal in lucesFrontales)
            {
                luzFrontal.GetComponent<Light>().enabled = !lucesFrontalesEncendidas;
            }
            lucesFrontalesEncendidas = !lucesFrontalesEncendidas;
        }
    }
}
