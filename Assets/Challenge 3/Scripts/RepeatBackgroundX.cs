using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    private void Start()
    {
        startPos = transform.position; // Guardamos la posición inicial
        // Calculamos la mitad de la imagen gracias a las dimensiones del BoxCollider del Background
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; 
    }

    private void Update()
    {
        // Si el fondo llega a trasladarse la mitad de su tamaño, se resetea su posición a la posición inicial
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}


