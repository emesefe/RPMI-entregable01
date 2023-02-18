using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObjectsX : MonoBehaviour
{
    public float spinSpeed;
    
    void Update()
    {
        // Rotamos sobre el eje Y
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
