using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider HealthSlider;
    public Slider ManaSlider;
    public GameObject NotEnoughManaText;
    public GameObject scoreGameObject;
    public float NotEnoughManaTime;

    private Player player;
    private GameManager gameManager;
    private TextMeshProUGUI score;
    private float NotEnoughManaTimer;

    public void OnAwake()
    {
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
        score = scoreGameObject.GetComponent<TextMeshProUGUI>();
    }

    public void OnStart()
    {
        Player.uiUpdateHealth += UpdateHealth;
        Player.uiUpdateMana += UpdateMana;
        HealthTrigger.uiUpdateHealth += UpdateHealth;
        ManaTrigger.uiUpdateMana += UpdateMana;

        UpdateHealth();
        UpdateMana();
        NotEnoughManaText.SetActive(false);
    }

    public void OnUpdate()
    {
        if (NotEnoughManaTimer >= 0) { NotEnoughManaTimer -= Time.deltaTime; }

        if (NotEnoughManaTimer <= 0)
        {
            NotEnoughManaText.SetActive(false);
        }
    }

    public void UpdateHealth()
    {
        HealthSlider.value = player.Health;
    }

    public void UpdateMana()
    {
        ManaSlider.value = player.Mana;
    }

    public void NotEnoughmana()
    {
        NotEnoughManaText.SetActive(true);
        NotEnoughManaTimer = NotEnoughManaTime;
    }

    public void UpdateScore()
    {
        score.text = gameManager.score.ToString();
    }
}