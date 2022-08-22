using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMenuScene : MonoBehaviour
{
    public Text bestScoreText;
    public InputField nameField;
    public int score;
    public string playerName;
    public string currentPlayer;

    private void Start()
    {
        GameManager.Instance.LoadScore();
        if (GameManager.Instance.playerName != "")
        {
            playerName = GameManager.Instance.playerName;
            score = GameManager.Instance.bestScore;
            bestScoreText.text = "Best score : " + playerName + " : " + score;
        } else
        {
            bestScoreText.text = "Play to set your best score";
        }

        
    }
    private void Update()
    {
        UpdateName();
    }

    void UpdateName()
    {
        currentPlayer = nameField.text;
    }

    public void StartGame()
    {
        GameManager.Instance.playerName = playerName;
        GameManager.Instance.currentPlayer = currentPlayer;
        SceneManager.LoadScene(1);
    }

    public void ResetScore()
    {
        if(GameManager.Instance.playerName != "")
        {
            GameManager.Instance.ResetScore();
            GameManager.Instance.LoadScore();
            bestScoreText.text = "Best score reseted!";
        } else
        {
            bestScoreText.text = "There is nothing to reset";
        }
        
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); // for quiting unity editor playmode
#else
        Application.Quit(); // quiting from the builded app
#endif
    }
}
