using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    public float speed; // Debe ser pública porque hay múltiples Game Objects con este script y diferentes speed
    
    private PlayerControllerX playerControllerScript;
    private float leftBound = -10;
    
    void Start()
    {
        // Del Game Object llamado Player, cogemos referencia de su componente PlayerControllerX
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    void Update()
    {
        // Si no gameOver, movemos hacia la izquierda
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        // Si el Game Object se sale por la izquierda y no se trata de Background, lo eliminamos
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }
}
