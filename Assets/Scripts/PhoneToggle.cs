using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneToggle : MonoBehaviour
{
    [SerializeField] GameObject phonePanel;
    [SerializeField] TextMeshProUGUI testText;
    [SerializeField] Image finger;
    PhoneGameController phoneGame;

    Vector3 mouse;
    RectTransform rectT;
    Vector2 size;
    Rect phoneOnScreen;


    private void Start()
    {
        phoneGame = GameObject.FindGameObjectWithTag("PhoneGame").GetComponent<PhoneGameController>();
        AudioManager.Instance.SetGameState(true);
        // PostProcessingManager.Instance.SetGameState(true);
        finger.enabled = true;
    }

    void Update()
    {
        // mouse position on phone
        mouse = Input.mousePosition;
        rectT = phonePanel.GetComponentInChildren<RawImage>().GetComponent<RectTransform>();
        size = Vector2.Scale(rectT.rect.size, rectT.lossyScale);
        phoneOnScreen = new Rect((Vector2)rectT.position - (size * 0.5f), size);
        if (phoneOnScreen.Contains(mouse) && Input.GetMouseButtonDown(0)) //Input.GetMouseButtonDown(0)
        {
            // get mouse position relative to phone screen
            float mouseX = mouse.x - phoneOnScreen.xMin;
            float mouseY = mouse.y - phoneOnScreen.yMin;
            // convert to viewport coordinates
            mouseX = mouseX / phoneOnScreen.width;
            mouseY = mouseY / phoneOnScreen.height;
            // pass to phone game
            if (phoneGame != null)
            {
                phoneGame.InputMouse(new Vector2(mouseX, mouseY));
            }

            // debug
            // testText.enabled = true;
            // testText.SetText("X:{0:2}\nY:{1:2}", mouseX, mouseY);
        }
        else
        {
            if (phoneGame != null)
            {
                phoneGame.NoMouse();
            }

            // debug
            // testText.enabled = false;
        }

        // move phone
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1)) //phonePanel != null && 
        {
            TogglePhone();
        }
    }

    public void TogglePhone()
    {
        Animator animator = phonePanel.GetComponent<Animator>();
        if (phonePanel != null && animator != null)
        {
            bool onPhone = animator.GetBool("OnPhone");
            animator.SetBool("OnPhone", !onPhone);
            AudioManager.Instance.SetGameState(!onPhone);
            PostProcessingManager.Instance.SetGameState(!onPhone);
            finger.enabled = !onPhone;
        }
    }
}
