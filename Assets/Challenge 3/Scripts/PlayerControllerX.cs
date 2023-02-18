using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver; // Necesitamos que sea pública, porque queremos acceder a esta variable desde otros scripts
    
    public float floatForce;
    
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;
    
    public AudioClip moneySound;
    public AudioClip explodeSound;
    
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    private AudioSource playerAudio;

    private int moneyCounter;

    private float maxY = 14.5f;
    
    void Start()
    {
        playerAudio = GetComponent<AudioSource>(); // Establecemos referencia con la componente AudioSource del Player
        playerRb = GetComponent<Rigidbody>(); // Establecemos referencia con la componente Rigidbody del Player
        
        Physics.gravity *= gravityModifier; // Aplicamos el modificador de gravedad
    }
    
    void Update()
    {
        // Si pulsamos la barra espaciadora y no gameOver, saltamos
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }

        if (transform.position.y > maxY)
        {
            playerRb.velocity = Vector3.zero;
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // Si el player colisiona con una bomba
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            
            GameOver();
            
            Destroy(other.gameObject);
        } 
        
        // Si el player colisiona con el suelo
        if (other.gameObject.CompareTag("Ground"))
        {
            GameOver();
        } 

        // Si el player colisiona con un money
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            
            Destroy(other.gameObject);
            
            moneyCounter++; // Sumamos uno al contador
        }
    }

    private void GameOver()
    {
        gameOver = true; // Game Over
        Debug.Log("Game Over!");
    }

}
