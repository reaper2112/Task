using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _restartButton;

    private void Awake()
    {
        _exitButton.onClick.AddListener(GameExit);
        _restartButton.onClick.AddListener(GameRestart);
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void GameRestart()
    {
        SceneManager.LoadScene("Game");
        Cursor.visible = false;
    }

    private void GameExit()
    {
        Application.Quit();
    }

}
