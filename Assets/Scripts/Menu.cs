using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Button[] menuButtons;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject instructions;
    [SerializeField] GameObject win;
    [SerializeField] GameObject fail;

    [SerializeField] bool startActive = false;

    private void Awake()
    {
        if (startActive)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }

    public void ActivateMenu()
    {
        if (menuButtons != null && menuButtons.Length > 0)
        {
            foreach (Button b in menuButtons)
            {
                b.gameObject.SetActive(true);
            }
        }
        titleScreen.SetActive(true);
        instructions.SetActive(false);
        win.SetActive(false);
        fail.SetActive(false);
    }

    public void DeactivateMenu()
    {
        if (menuButtons != null && menuButtons.Length > 0)
        {
            foreach (Button b in menuButtons)
            {
                b.gameObject.SetActive(false);
            }
        }
        titleScreen.SetActive(false);
        instructions.SetActive(false);
        win.SetActive(false);
        fail.SetActive(false);
    }

    public void StartNewGame()
    {
        Debug.Log("Started new game");
        // start the game
    }

    public void ShowInstructions()
    {
        Debug.Log("Display instructions");
        titleScreen.SetActive(false);
        instructions.SetActive(true);
        win.SetActive(false);
        fail.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("Quit game");
        // quit the game
    }
}
