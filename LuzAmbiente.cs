using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzAmbiente : MonoBehaviour
{
    float incremento = 0.5f;
    Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            light.intensity -= Time.deltaTime * incremento;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            light.intensity += Time.deltaTime * incremento;
        }
    }
}
