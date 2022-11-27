using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndDialogue : MonoBehaviour
{
    public GameObject[] dialogueBoxes;

    public void StartDialogue()
    {
        StartCoroutine(Dialogue());

        TextMeshProUGUI endText = dialogueBoxes[1].GetComponent<TextMeshProUGUI>();
        int playerScore = FindObjectOfType<PhoneGameController>().score;
        endText.text = "Check it out, I got " + (playerScore + 1) + " likes on Clout Chaser!";
    }

    private IEnumerator Dialogue()
    {
        yield return new WaitForSeconds(1f);

        for(int i = 0; i < dialogueBoxes.Length; i++)
        {
            float opacity = 0f;
            float holdTimer = 0f;

            dialogueBoxes[i].SetActive(true);
            TextMeshProUGUI text = dialogueBoxes[i].GetComponent<TextMeshProUGUI>();

            while (opacity < 1f)
            {
                opacity += Time.deltaTime;
                text.color = new Color(1, 1, 1, opacity);
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(2f);

            if (i != dialogueBoxes.Length - 1) { 

                while (opacity > 0f)
                {
                    opacity -= Time.deltaTime;
                    text.color = new Color(1, 1, 1, opacity);
                    yield return new WaitForEndOfFrame();
                }

                dialogueBoxes[i].SetActive(false);
            }
        }
    }
}
