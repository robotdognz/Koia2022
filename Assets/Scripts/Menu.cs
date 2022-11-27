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
    [SerializeField] RawImage overlay;
    [SerializeField] RawImage screen;
    [SerializeField] RawImage phoneGame;
    [SerializeField] Texture smashedOverlay;
    [SerializeField] Texture smashedScreen;
    [SerializeField] Image blackOut;

    [SerializeField] bool startActive = false;

    private void Awake()
    {
        blackOut.gameObject.SetActive(true);

        if (startActive)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }

    void Start() {
        StartCoroutine(FadeBlack(false));
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
    }

    public void LoseGame()
    {
        FindObjectOfType<PlayerMovement>().DisablePlayer();
        StartCoroutine(LoseGameIEnum(2));
        FindObjectOfType<PhoneToggle>().PhoneDeath();
        overlay.texture = smashedOverlay;
        screen.texture = smashedScreen;
        phoneGame.gameObject.SetActive(false);
    }

    IEnumerator LoseGameIEnum(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(FadeBlack());

        // restart game
        Debug.Log("Lost game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    IEnumerator FadeBlack(bool fadeToBlack = true, int fadeSpeed = 5)
    {
        Color color = blackOut.color;
        float fadeAmount;

        if(fadeToBlack)
        {
            while (blackOut.color.a < 1)
            {
                fadeAmount = color.a + (fadeSpeed * Time.deltaTime);

                color = new Color(color.r, color.g, color.b, fadeAmount);
                blackOut.color = color;
                yield return null;
            }
        }
        else
        {
            while (blackOut.color.a > 0)
            {
                fadeAmount = color.a - (fadeSpeed * Time.deltaTime);

                color = new Color(color.r, color.g, color.b, fadeAmount);
                blackOut.color = color;
                yield return null;
            }
        }
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
