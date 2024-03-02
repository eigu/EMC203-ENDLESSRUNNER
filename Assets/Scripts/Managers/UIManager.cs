using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    private PlayerStat m_playerStat
    {
            get { return FindObjectOfType<PlayerStat>(); }
    }

    [SerializeField]
    private TextMeshProUGUI _playerHealthText;
    [SerializeField]
    private Image _playerHealthBar;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(this);

        m_playerStat.OnHealthChange += HandleHealthBar;
    }

    private void Start()
    {
        Time.timeScale = 1;

        HandleHealthBar(m_playerStat.CurrentHealth);
    }

    private void HandleHealthBar(int health)
    {
        _playerHealthText.text = "HP: " + health;

        HealthBarFiller((float)health);
        ColorChanger((float)health);
    }

    void HealthBarFiller(float health)
    {
        float healthPercentage = health / (float)m_playerStat.MaxHealth;

        _playerHealthBar.fillAmount = healthPercentage;
    }

    void ColorChanger(float health)
    {
        float healthPercentage = health / (float)m_playerStat.MaxHealth;

        Color healthColor = Color.Lerp(Color.red, Color.green, healthPercentage);
        _playerHealthBar.color = healthColor;
    }
}
