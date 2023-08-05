using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioClip[] moveSounds;
    public AudioClip sliceSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI winCoinsText;
    public TextMeshProUGUI loseCoinsText;
    public GameObject winPanel;
    public GameObject losePanel;

    private AudioSource audioSource;

    private int coins = 0;
    private int thisGameCoins = 0;

    //  Caso a faca tenha acertado em dois multiplicadores por acidente,
    //      o código só vai considerar o primeiro que acertou
    private bool winned = false;

    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = coins.ToString();
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    public void MoveSound()
    {
        audioSource.PlayOneShot(moveSounds[Random.Range(0, moveSounds.Length)]);
    }

    public void AddScore(int scoreValue, Vector3 position)
    {
        audioSource.PlayOneShot(sliceSound);
        coins += scoreValue;
        thisGameCoins += scoreValue;
        coinsText.text = coins.ToString();
    }

    public void Lose()
    {
        if(winned) return;
        audioSource.PlayOneShot(loseSound);
        losePanel.SetActive(true);
        loseCoinsText.text = $"Você conseguiu {thisGameCoins.ToString()} moedas!";
        ApplyChanges();
    }

    public void Win()
    {
        if(winned) return;
        audioSource.PlayOneShot(winSound);
        winPanel.SetActive(true);
        winCoinsText.text = $"Você conseguiu {thisGameCoins.ToString()} moedas!";
        ApplyChanges();
    }

    public void ApplyChanges()
    {
        winned = true;
        PlayerPrefs.SetInt("Coins", coins);
        coinsText.text = coins.ToString();
    }
    public int GetThisGameCoins()
    {
        return thisGameCoins;
    }
    public void Restart()
    {
        ApplyChanges();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
