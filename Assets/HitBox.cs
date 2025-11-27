using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public int dano = 1;
    public string alvoTag; // "Player1" ou "Player2"
    private Transform dono;

    void Awake()
    {
        dono = transform.root; // quem é o dono da hitbox
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(alvoTag))
        {
            LifeSystem vida = other.GetComponent<LifeSystem>();

            if (vida != null)
            {
                Transform atacante = transform.root; // GARANTE QUE É O PLAYER
                vida.TomarDano(dano, atacante);
            }
        }
    }


}
