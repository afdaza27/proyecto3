using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista : MonoBehaviour
{

    List<Texture2D> texturas = new List<Texture2D>();
    int texturaActual = 0;
    int cantidadTexturas = 4;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= cantidadTexturas; i++)
        {

            texturas.Add(Resources.Load<Texture2D>("pista" + i));
        }
        gameObject.GetComponent<Renderer>().material.mainTexture = texturas[texturaActual];
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
