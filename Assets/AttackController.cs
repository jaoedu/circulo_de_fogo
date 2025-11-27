using UnityEngine;

public class AttackController : MonoBehaviour
{
    public GameObject hitbox;

    public void AtivarHitbox()
    {
        hitbox.SetActive(true);
    }

    public void DesativarHitbox()
    {
        hitbox.SetActive(false);
    }
}
