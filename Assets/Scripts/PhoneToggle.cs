using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneToggle : MonoBehaviour
{
    [SerializeField] GameObject phonePanel;
    [SerializeField] TextMeshProUGUI testText;
    [SerializeField] PhoneGameController phoneGame;

    void Update()
    {
        // mouse position on phone
        Vector3 mouse = Input.mousePosition;
        RectTransform rectT = phonePanel.GetComponentInChildren<RawImage>().GetComponent<RectTransform>();
        Vector2 size = Vector2.Scale(rectT.rect.size, rectT.lossyScale);
        Rect phoneOnScreen = new Rect((Vector2)rectT.position - (size * 0.5f), size);
        if (phoneOnScreen.Contains(mouse))
        {
            testText.enabled = true;
            // get mouse position relative to phone screen
            float mouseX = mouse.x - phoneOnScreen.xMin;
            float mouseY = mouse.y - phoneOnScreen.yMin;
            // convert to viewport coordinates
            mouseX = mouseX / phoneOnScreen.width;
            mouseY = mouseY / phoneOnScreen.height;
            // pass to phone game
            if (phoneGame != null && Input.GetMouseButtonDown(0))
            {
                phoneGame.InputMouse(new Vector2(mouseX, mouseY));
            }
            // debug
            testText.SetText("X:{0:2}\nY:{1:2}", mouseX, mouseY);
        }
        else
        {
            testText.enabled = false;
        }


        // move phone
        if (phonePanel != null && Input.GetKeyDown(KeyCode.Return))
        {
            // toggle phone
            Animator animator = phonePanel.GetComponent<Animator>();
            if (animator != null)
            {
                bool onPhone = animator.GetBool("OnPhone");
                animator.SetBool("OnPhone", !onPhone);
            }
        }
    }
}
