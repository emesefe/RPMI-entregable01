using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;

    private PlayerControllerX playerControllerScript;
    
    void Start()
    {
        // Del Game Object llamado Player, cogemos referencia de su componente PlayerControllerX
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        
        // Se repite periódicamente la llamada a la función SpawnObjects
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
    }

    // Lógica de spawnear objetos
    void SpawnObjects ()
    {
        // Establecemos una altura aleatoria y un Game Object aleatorio a spawnear
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
        int index = Random.Range(0, objectPrefabs.Length);

        // Siempre que no gameOver, seguimos instanciando Game Objects
        if (!playerControllerScript.gameOver)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }
    }
}
