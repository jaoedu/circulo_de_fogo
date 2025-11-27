using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class LifeSystem : MonoBehaviour
{
    [Header("Configuração de Vida")]
    public int vidaMax = 5;
    public int vidaAtual;

    [Header("UI")]
    public Image greenBar;   // barra verde
    public Image redBar;     // barra vermelha (delay)

    [Header("Knockback")]
    public float knockForce = 6f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Coroutine redRoutine;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        vidaAtual = vidaMax;
        AtualizarBarra(1f); // barra cheia
    }

    // ===== VIDA =====
    public void TomarDano(int quantidade, Transform atacante)
    {
        vidaAtual = Mathf.Clamp(vidaAtual - quantidade, 0, vidaMax);
        float ratio = (float)vidaAtual / vidaMax;

        // Atualiza barra verde
        SetGreen(ratio);

        // Atualiza barra vermelha com delay
        if (redRoutine != null) StopCoroutine(redRoutine);
        redRoutine = StartCoroutine(DelayRedBar(ratio));

        // Knockback
        AplicarKnockback(atacante);

        // Se morreu
        if (vidaAtual <= 0)
            Morrer();
    }

    // ====== BARRAS ======
    public void AtualizarBarra(float value)
    {
        SetGreen(value);
        SetRed(value);
    }

    void SetGreen(float value)
    {
        if (!greenBar) return;
        var s = greenBar.rectTransform.localScale;
        s.x = Mathf.Clamp01(value);
        greenBar.rectTransform.localScale = s;
    }

    void SetRed(float value)
    {
        if (!redBar) return;
        var s = redBar.rectTransform.localScale;
        s.x = Mathf.Clamp01(value);
        redBar.rectTransform.localScale = s;
    }

    System.Collections.IEnumerator DelayRedBar(float alvo)
    {
        yield return new WaitForSeconds(0.25f);

        float inicial = redBar.rectTransform.localScale.x;
        float t = 0f, dur = 0.4f;

        while (t < dur)
        {
            t += Time.deltaTime;
            float x = Mathf.Lerp(inicial, alvo, t / dur);
            SetRed(x);
            yield return null;
        }

        SetRed(alvo);
    }

    // ===== KNOCKBACK =====
    void AplicarKnockback(Transform atacante)
    {
        Vector2 direcao = (transform.position - atacante.position).normalized;
        rb.AddForce(direcao * knockForce, ForceMode2D.Impulse);
    }

    // ===== MORTE =====
    void Morrer()
    {
        // toca animação
        Animator anim = GetComponent<Animator>();
        if (anim != null)
            anim.SetTrigger("morrer");

        // desativa MOVIMENTO
        var pc1 = GetComponent<PlayerController>();
        if (pc1) pc1.enabled = false;

        var pc2 = GetComponent<Player2Controller>();
        if (pc2) pc2.enabled = false;

        var atk = GetComponent<AttackController>();
        if (atk) atk.enabled = false;

        // desativa hitboxes
        Collider2D[] colls = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D col in colls)
            col.enabled = false;

        // espera animação terminar
        StartCoroutine(DesativarDepoisDaAnimacao());
    }


    IEnumerator DesativarDepoisDaAnimacao()
    {
        yield return new WaitForSeconds(1.0f); // tempo da animação de morrer

        // desativa o objeto
        gameObject.SetActive(false);

        // avisa o GameManager
        if (gameObject.CompareTag("Player1"))
            GameManager.instance.PlayerGanhou("Player 2");
        else if (gameObject.CompareTag("PlayerSecond"))
            GameManager.instance.PlayerGanhou("Player 1");
    }

}
