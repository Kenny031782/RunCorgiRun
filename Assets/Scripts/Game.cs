using UnityEngine;

public class Game : MonoBehaviour
{
    public UI Ui;
    public GameTimer GameTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Ui.HideGameOverScreen();
        Ui.ShowStartScreen();
    }

    // Update is called once per frame
    void Update()
    {
        Ui.ShowTime();
    }

    public void OnStartButtonClicked()
    {
        // hide StartScreen
        Ui.HideStartScreen();
        StartGame();
    }

    public void OnPlayAgainButtonClicked()
    {
        Ui.HideGameOverScreen();
        StartGame();
    }

    private void StartGame()
    {
        GameTimer.StartTimer(10, OnTimerFinished);
    }

    private void OnTimerFinished()
    {
        Ui.ShowGameOverScreen();
    }
}
