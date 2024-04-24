using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public int zombiesKilled;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private PlayerScript playerScript;
    [SerializeField] private BulletSpawnerScript bulletSpawnerScript;

    public TextMeshProUGUI zombieKilledText;
    public TextMeshProUGUI currentASText;
    public TextMeshProUGUI gameOverScore;

    void Start()
    {
        zombiesKilled = 0;
    }

    void Update()
    {
        if (!playerScript.isAlive)
        {
            ShowGameOverScreen();
        }

        UpdateUI();
    }

    public void ShowGameOverScreen()
    {
        gameOverScore.text = "Your Score: " + zombiesKilled;
        gameOverScreen.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("MyGame");
    }

    void UpdateUI()
    {
        currentASText.text = "Current Attack Speed: " + bulletSpawnerScript.attackSpeed;
        zombieKilledText.text = "Zombies Killed: " + zombiesKilled;
    }
}
