using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
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
        // Movimento A e D
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        anim.SetBool("correr", inputHorizontal != 0);

        // Flip
        if (inputHorizontal > 0)
            sr.flipX = false;
        else if (inputHorizontal < 0)
            sr.flipX = true;

        // Ataque
        if (Input.GetKeyDown(KeyCode.Space))
            anim.SetTrigger("atacar");

        // Pulo — agora FUNCIONA
        if (!Input.GetKeyDown(KeyCode.W) || !estaNoChao)
        {
            return;
        }
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
    }

    void FixedUpdate()
    {
        // Movimento — agora FUNCIONA
        rb.linearVelocity = new Vector2(inputHorizontal * velocidade, rb.linearVelocity.y);

        // Detectar chão
        estaNoChao = Physics2D.OverlapCircle(peDoPersonagem.position, raioDeteccao, layerChao);
    }

    private void OnDrawGizmosSelected()
    {
        if (peDoPersonagem != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(peDoPersonagem.position, raioDeteccao);
        }
    }
}
