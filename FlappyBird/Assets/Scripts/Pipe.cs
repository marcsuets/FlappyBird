using System;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float moveSpeed;
    private Bird bird;
    private GameManager gm;
    

    private void Start()
    {
        bird = Bird.Instance;
        gm = GameManager.Instance;
    }

    // Inicializa la velocidad de movimiento de la tubería
    public void Initialize(float speed)
    {
        moveSpeed = speed;
        bird = Bird.Instance;
    }

    void Update()
    {
        if (!gm.getGameOver())
        {
            // Mueve la tubería hacia la izquierda
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.left);
        }
        
        // Destruye la tubería si sale de la pantalla
        if (transform.position.x < Camera.main.transform.position.x - 10f) // Asegura que la destrucción dependa de la cámara
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // Usamos Collision2D para colisiones físicas
    {
        
        if (collision.gameObject.CompareTag("Bird")) // Mejor práctica para comparar etiquetas
        {
            Debug.Log("Collisió: " + collision.gameObject.name);
            bird.triggerDeath();
            gm.setGameOver(true);
            gm.saveBestScore();
        }
    }
}