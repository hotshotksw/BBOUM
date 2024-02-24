using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("User Interface")]
    [SerializeField] GameObject Title_Screen;
    [SerializeField] GameObject End_Screen;
    // Object for buttons, can grab them all with this??
    [SerializeField] GameObject Game_Buttons;

    [Header("Minigames")]
    // Minigame Parent Objects
    [SerializeField] GameObject Health_Minigame;
    [SerializeField] GameObject Strength_Minigame;
    [SerializeField] GameObject Stamina_Minigame;
    [SerializeField] GameObject Friendship_Minigame;

    [Header("Events")]
    [SerializeField] GameObjectEvent MinigameType;

    public enum GameState
    {
        Title,    // -> To Title Screen
        Menu,     // -> Menu Screen, Home Page
        Minigame, // -> Any Minigame
        Finale,   // -> Meteor Fight
        EndScreen // -> End Screen, win OR lose
    }

    public GameState state = GameState.Menu;

    void Start()
    {
        Health_Minigame.SetActive(false);
        Strength_Minigame.SetActive(false);
        Stamina_Minigame.SetActive(false);
        Friendship_Minigame.SetActive(false);
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
                    break;
                }
        }
    }

    public void ToHealthGame()
    {
        Health_Minigame.SetActive(true);
        state = GameState.Minigame;
    }
    public void ToStrengthGame()
    {
        Strength_Minigame.SetActive(true);
        state = GameState.Minigame;
    }
    public void ToStaminaGame()
    {
        Stamina_Minigame?.SetActive(true);
        state = GameState.Minigame;
    }
    public void ToFriendshipGame()
    {
        Friendship_Minigame.SetActive(true);
        state = GameState.Minigame;
    }

    // Function to end minigame and exit minigame state, going back to the menu
    public void OnExitMinigame()
    {
        Health_Minigame.SetActive(false);
        Strength_Minigame.SetActive(false);
        Stamina_Minigame.SetActive(false);
        Friendship_Minigame.SetActive(false);


        Game_Buttons.SetActive(true);

        state = GameState.Menu;
    }

    public void ToFinale()
    {
        state = GameState.Finale;
    }

    public void ToTitle()
    {
        Game_Buttons.SetActive(false);
        state = GameState.Title;
    }

    public void ToEndScreen()
    {
        state = GameState.EndScreen;
    }

}
