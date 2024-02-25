using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("User Interface")]
    [SerializeField] GameObject Title_Screen;
    [SerializeField] GameObject End_Screen;
    // Object for buttons, can grab them all with this??
    [SerializeField] List<GameObject> Game_Buttons; // List of buttons

    [Header("Minigames")]
    // Minigame Parent Objects
    [SerializeField] GameObject Health_Minigame;
    [SerializeField] GameObject Strength_Minigame;
    [SerializeField] GameObject Stamina_Minigame;
    [SerializeField] GameObject Friendship_Minigame;

    [Header("Events")]
    //[SerializeField] GameObjectEvent MinigameEndEvent; // Event that, when raised, ends the minigame
    [SerializeField] VoidEvent healthColorEvent; //the four horsemen of the apocalypse
    [SerializeField] VoidEvent strengthColorEvent; 
    [SerializeField] VoidEvent staminColorEvent; 
    [SerializeField] VoidEvent friendshipColorEvent; 

    public enum GameState
    {
        Title,    // -> To Title Screen
        Menu,     // -> Menu Screen, Home Page
        Minigame, // -> Any Minigame
        Finale,   // -> Meteor Fight
        EndScreen // -> End Screen, win OR lose
    }

    [Header("Information")]
    public GameState state = GameState.Menu;

    bool timerStarted = false;

    void Start()
    {
        Health_Minigame.SetActive(false);
        Strength_Minigame.SetActive(false);
        Stamina_Minigame.SetActive(false);
        Friendship_Minigame.SetActive(false);
        OnEnable();
    }

    void Update()
    {
        // Switch Case for state of the game
        switch (state)
        {
            case GameState.Title:
                {
                    break;
                }
            case GameState.Menu:
                {
                    if (!timerStarted) EventManager.OnTimerStart();
                    break;
                }
            case GameState.Minigame:
                {

                    if(Input.GetKeyDown(KeyCode.Q))
                    {
                        OnExitMinigame();
                    }

                    break;
                }
            case GameState.Finale:
                {
                    break;
                }
            case GameState.EndScreen:
                {
                    break;
                }
        }
        if(timerStarted)
        {
            EventManager.OnTimerUpdate(-Time.deltaTime);
        }
    }

// OnClicks for buttons

    public void ToHealthGame()
    {
        disableButtons();
        Health_Minigame.SetActive(true);
        healthColorEvent.RaiseEvent(); //green
        state = GameState.Minigame;
    }
    public void ToStrengthGame()
    {
        disableButtons();
        Strength_Minigame.SetActive(true);
		strengthColorEvent.RaiseEvent(); //orange
		state = GameState.Minigame;
    }
    public void ToStaminaGame()
    {
        disableButtons();
        Stamina_Minigame?.SetActive(true);
		staminColorEvent.RaiseEvent(); //blue
		state = GameState.Minigame;
    }
    public void ToFriendshipGame()
    {
        disableButtons();
        Friendship_Minigame.SetActive(true);
		friendshipColorEvent.RaiseEvent(); //pink
		state = GameState.Minigame;
    }

    // Function to end minigame and exit minigame state, going back to the menu
    public void OnExitMinigame()
    {
        Health_Minigame.SetActive(false);
        Strength_Minigame.SetActive(false);
        Stamina_Minigame.SetActive(false);
        Friendship_Minigame.SetActive(false);

        enableButtons();

        state = GameState.Menu;
    }

    public void ToFinale()
    {
        state = GameState.Finale;
    }

    public void ToTitle()
    {
        state = GameState.Title;
    }

    public void ToEndScreen()
    {
        state = GameState.EndScreen;
    }

// Utiliy Functions

    // Disables all the buttons on the Games_Button list
    private void disableButtons()
    {
        foreach (var obj in Game_Buttons)
        {
            if (obj.TryGetComponent(out Button button))
            {
                button.enabled = false;
                button.image.color = new Color(0.7f, 0.7f, 0.7f);
            }
        }
    }
    // Enables all the buttons on the Games_Button list
    private void enableButtons()
    {
        foreach (var obj in Game_Buttons)
        {
            if (obj.TryGetComponent(out Button button))
            {
                button.enabled = true;
                button.image.color = Color.white;
                
            }
        }
    }

    // Timer Garbage

    private void OnEnable()
    {
        EventManager.TimerStop += EventManagerOnTimerStop;
    }
    private void EventManagerOnTimerStop()
    {
        ToFinale();
    }
}
