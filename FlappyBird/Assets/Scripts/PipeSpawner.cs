    using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab; // Prefab de la tubería
    public float spawnInterval = 2f; // Intervalo entre cada spawn
    public float minY = -1.5f; // Posición mínima en Y para la tubería
    public float maxY = 1.5f; // Posición máxima en Y para la tubería
    public float moveSpeed = 2f; // Velocidad de movimiento de las tuberías

    private float timeSinceLastSpawn = 0f; // Temporizador para el spawn

    void Update()
    {
        // Contador para el spawn de las tuberías
        timeSinceLastSpawn += Time.deltaTime;
        
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnPipe();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnPipe()
    {
        // Genera una tubería en una posición aleatoria en Y
        float spawnPosY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnPosY, 0);
        
        // Instancia la tubería
        GameObject pipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);

        // Asigna un script para mover las tuberías hacia la izquierda
        pipe.GetComponent<Pipe>().Initialize(moveSpeed);
    }
}
