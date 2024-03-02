using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerStat m_playerStat
    {
        get { return FindObjectOfType<PlayerStat>(); }
    }

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(this);

        m_playerStat.OnHealthChange += HandleDeath;
    }

    private void HandleDeath(int health)
    {
        if (health <= 0) SceneManager.LoadScene("Game");
    }
}
