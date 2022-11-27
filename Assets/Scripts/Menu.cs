using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void LoseGame()
    {
        FindObjectOfType<PlayerMovement>().DisablePlayer();
        StartCoroutine(LoseGameIEnum(2));
    }

    IEnumerator LoseGameIEnum(float time)
    {
        yield return new WaitForSeconds(time);

        // restart game
        Debug.Log("Lost game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartNewGame()
    {
        Debug.Log("Started new game");
        DeactivateMenu();
        // start the game
        FindObjectOfType<PlayerMovement>().EnablePlayer();
        FindObjectOfType<PhoneToggle>().TogglePhone();
        FindObjectOfType<LikeSpawner>().StartPhoneGame();
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
        if (Application.platform != RuntimePlatform.WebGLPlayer)
        {
            Application.Quit();
        }
    }
}
