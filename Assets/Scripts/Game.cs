using UnityEngine;

public class Game : MonoBehaviour
{
    public UI Ui;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonClicked()
    {
        // hide StartScreen
        Ui.HideStartScreen();
        // start game
    }
}
