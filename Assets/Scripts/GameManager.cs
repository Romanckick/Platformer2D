using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int coinCount = 0;         // кількість монет
    public int coinsToNextLevel; // скільки потрібно для переходу
    
    public TMP_Text coinText;
  
    public void AddCoin()
    {
        coinCount++;
        Debug.Log("Монет зібрано: " + coinCount);
        UpdateUI();
        if (coinCount >= coinsToNextLevel)
        {
            LoadNextLevel();
        }
    }
     void UpdateUI()
    {
        coinText.text = coinCount.ToString();
    }
    void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Якщо наступний рівень існує
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
