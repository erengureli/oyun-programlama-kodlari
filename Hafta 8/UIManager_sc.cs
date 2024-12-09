using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_sc : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreTMP;

    [SerializeField]
    TextMeshProUGUI gameOverTMP;

    [SerializeField]
    TextMeshProUGUI restartTMP;

    [SerializeField]
    Image liveImg;

    [SerializeField]
    Sprite[] livesSprites;

    GameManager_sc gameManager_Sc;

    void Start()
    {
        gameManager_Sc = GameObject.Find("Game_Manager").GetComponent<GameManager_sc>();
        if(gameManager_Sc == null) Debug.Log("UIManager_sc::Start gameManager_Sc is NULL");

        UpdateScoreTMP(0);
        UpdateLivesIMG(3);
        gameOverTMP.gameObject.SetActive(false);
        restartTMP.gameObject.SetActive(false);
    }

    public void UpdateScoreTMP(int score)
    {
        scoreTMP.text = "Score: " + score;
    }

    public void UpdateLivesIMG(int lives)
    {
        liveImg.sprite = livesSprites[lives];
        if(lives == 0) GameOverSequence();
    }

    void GameOverSequence()
    {
        gameManager_Sc.GameOver();
        gameOverTMP.gameObject.SetActive(true);
        restartTMP.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while(true)
        {
            gameOverTMP.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            gameOverTMP.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
