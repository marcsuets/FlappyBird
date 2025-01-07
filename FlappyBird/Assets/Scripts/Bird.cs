using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Instancia estática del singleton
    public static Bird Instance { get; private set; }
    private SpriteRenderer spriteRenderer;

    private GameManager gm;
    private Animator animator;

    public float jumpForce = 7f; // Fuerza del salto
    public float gravity = 0.6f; // Gravedad adicional (opcional)
    public float rotationSpeed = 5f; // Velocidad de rotación gradual (ajustable)
    private Rigidbody2D rb; // Referencia al Rigidbody2D del pájaro
    private float currentRotation = 0f; // Ángulo de rotación actual

    void Awake()
    {
        // Verifica si ya existe una instancia del singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye este objeto
        }
        else
        {
            Instance = this; // Si no existe, asigna la instancia a esta clase
            //DontDestroyOnLoad(gameObject); // Asegura que el objeto persista entre escenas si es necesario
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D
        rb.gravityScale = gravity; // Aplica la gravedad al pájaro
        gm = GameManager.Instance;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update es llamado una vez por frame
    void Update()
    {
        // Detecta si se presiona la tecla espacio o si se hace clic en la pantalla
        if (Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if (!gm.getGameOver())
            {
                gm.PlaySound(3);
            }
            Jump();
        }
        
        // Calcula la rotación en función de la velocidad en el eje Y
        RotateBird();
        
    }

    // Función que hace saltar al pájaro
    void Jump()
    {
        if (!gm.getGameOver())
        {
            rb.velocity = Vector2.zero; // Resetea la velocidad del pájaro (evita movimientos no deseados)
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Aplica una fuerza hacia arriba
        }
    }

    // Función para rotar el pájaro dependiendo de su velocidad vertical
    void RotateBird()
    {
        // Calcula el ángulo de rotación basado en la velocidad vertical
        float targetRotation = Mathf.Clamp(rb.velocity.y * 2, -90f, 45f);

        // Suaviza la rotación utilizando Mathf.Lerp
        currentRotation = Mathf.Lerp(currentRotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Aplica la rotación al pájaro
        transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
    }

    public void triggerDeath()
    {
        gm.PlaySound(2);
        animator.SetTrigger("Hit");
    }
}
