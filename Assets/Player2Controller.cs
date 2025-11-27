using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class Player2Controller : MonoBehaviour
{
    [Header("Movimentação")]
    public float velocidade = 5f;
    public float forcaPulo = 7f;

    private float inputHorizontal;
    private bool estaNoChao;

    [Header("Detecção de Chão")]
    public Transform peDoPersonagem;
    public float raioDeteccao = 0.15f;
    public LayerMask layerChao;

    [Header("Componentes")]
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // --- MOVIMENTO J e L ---
        if (Input.GetKey(KeyCode.J))
            inputHorizontal = -1;
        else if (Input.GetKey(KeyCode.L))
            inputHorizontal = 1;
        else
            inputHorizontal = 0;

        // Animação de correr (Player 2)
        anim.SetBool("correrSecondPlayer", inputHorizontal != 0);

        // Flip horizontal
        if (inputHorizontal > 0)
            sr.flipX = false;
        else if (inputHorizontal < 0)
            sr.flipX = true;

        // --- ATAQUE (Enter) ---
        if (Input.GetKeyDown(KeyCode.Return))
            anim.SetTrigger("atacarSecondPlayer");

        // --- PULO (I) ---
        if (Input.GetKeyDown(KeyCode.I) && estaNoChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        }
    }

    void FixedUpdate()
    {
        // Aplicar movimento
        rb.linearVelocity = new Vector2(inputHorizontal * velocidade, rb.linearVelocity.y);

        // Detectar chão
        estaNoChao = Physics2D.OverlapCircle(peDoPersonagem.position, raioDeteccao, layerChao);
    }

    private void OnDrawGizmosSelected()
    {
        if (peDoPersonagem != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(peDoPersonagem.position, raioDeteccao);
        }
    }
}
