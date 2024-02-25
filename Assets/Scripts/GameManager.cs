using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("User Interface")]
    [SerializeField] GameObject Title_Screen;
    [SerializeField] GameObject Menu_Screen;
    [SerializeField] GameObject Lose_Screen;
    [SerializeField] GameObject Win_Screen;
    [SerializeField] GameObject IdleMain;
    // Object for buttons, can grab them all with this??
    [SerializeField] List<GameObject> Game_Buttons; // List of buttons

    [Header("Minigames")]
    // Minigame Parent Objects
    [SerializeField] GameObject Health_Minigame;
    [SerializeField] GameObject Strength_Minigame;
    [SerializeField] GameObject Stamina_Minigame;
    [SerializeField] GameObject Friendship_Minigame;
    [SerializeField] GameObject Meteor_Minigame;
    [SerializeField] GameObject Meteor_Cutscene;

    [Header("Events")]
    //[SerializeField] GameObjectEvent MinigameEndEvent; // Event that, when raised, ends the minigame
    [SerializeField] VoidEvent healthColorEvent; //the four horsemen of the apocalypse
    [SerializeField] VoidEvent strengthColorEvent; 
    [SerializeField] VoidEvent staminColorEvent; 
    [SerializeField] VoidEvent friendshipColorEvent;
    [SerializeField] VoidEvent finalColorEvent;
    [SerializeField] VoidEvent startMeteorCutscene;

    public enum GameState
    {
        Title,    // -> To Title Screen
        Menu,     // -> Menu Screen, Home Page
        Minigame, // -> Any Minigame
        Finale,   // -> Meteor Fight
        EndScreen // -> End Screen, win OR lose
    }

    [Header("Information")]
    [SerializeField] Timer timer;
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
                    timer.timeToDisplay = 300.0f;
                    Title_Screen.SetActive(true);
                    break;
                }
            case GameState.Menu:
                {
                    if (!timerStarted) EventManager.OnTimerStart();
                    break;
                }
            case GameState.Minigame:
                {
                    break;
                }
            case GameState.Finale:
                {
                    break;
                }
            case GameState.EndScreen:
                {
                    //End_Screen.SetActive(true);
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
        IdleMain.SetActive(false);
        Health_Minigame.SetActive(true);
        healthColorEvent.RaiseEvent(); //green
        state = GameState.Minigame;
    }
    public void ToStrengthGame()
    {
        disableButtons();
		IdleMain.SetActive(false);
		Strength_Minigame.SetActive(true);
		strengthColorEvent.RaiseEvent(); //orange
		state = GameState.Minigame;
    }
    public void ToStaminaGame()
    {
        disableButtons();
		IdleMain.SetActive(false);
		Stamina_Minigame?.SetActive(true);
		staminColorEvent.RaiseEvent(); //blue
		state = GameState.Minigame;
    }
    public void ToFriendshipGame()
    {
        disableButtons();
		IdleMain.SetActive(false);
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
		IdleMain.SetActive(true);

		state = GameState.Menu;
    }
    public void ToTitle()
    {
        state = GameState.Title;
        Lose_Screen.SetActive(false);
        Win_Screen.SetActive(false);
        Menu_Screen.SetActive(false);
    }

    public void ToMenu()
    {
        state = GameState.Menu;
        Title_Screen.SetActive(false);
        Menu_Screen.SetActive(true);
    }

    public void ToFinale()
    {
        state = GameState.Finale;
		IdleMain.SetActive(false);
		Menu_Screen.SetActive(false);
		finalColorEvent.RaiseEvent();
		Meteor_Cutscene.SetActive(true);
        startMeteorCutscene.RaiseEvent();
        if (Health_Minigame.activeSelf)
        {
			Health_Minigame.GetComponent<RythmTest>().ForceStop();
			Health_Minigame.SetActive(false);
		}
        if (Strength_Minigame.activeSelf)
        {
            Strength_Minigame.SetActive(false);
			Strength_Minigame.GetComponent<RythmTest>().ForceStop();
		}
        if (Stamina_Minigame.activeSelf)
        {
            Stamina_Minigame.SetActive(false);
			Stamina_Minigame.GetComponent<RythmTest>().ForceStop();
		}
        if (Friendship_Minigame.activeSelf)
        {
            Friendship_Minigame.SetActive(false);
			Friendship_Minigame.GetComponent<RythmTest>().ForceStop();
		}
	}

    public void ToLoseScreen()
    {
        Lose_Screen.SetActive(true);
        Meteor_Minigame.SetActive(false);
    }

    public void ToWinScreen()
    {
		Win_Screen.SetActive(true);
		Meteor_Minigame.SetActive(false);
	}

    public void ToMeteor()
    {
        Meteor_Cutscene.SetActive(false);
        Meteor_Minigame.SetActive(true);
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
        Debug.Log("Time ran out!");
        ToFinale();
    }
}
