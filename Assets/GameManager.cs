using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text winnerText;
    public GameObject winnerPanel;

    void Awake()
    {
        instance = this;
        winnerPanel.SetActive(false);
    }

    public void PlayerGanhou(string nome)
    {
        winnerText.text = nome + " venceu!";
        winnerPanel.SetActive(true);

        Invoke(nameof(Reiniciar), 3f);
    }

    void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
