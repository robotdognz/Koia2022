using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneGameController : MonoBehaviour
{
    [SerializeField] Camera phoneGameCamera;
    [SerializeField] GameObject pointer;

    [SerializeField] TextMeshProUGUI scoreText;

    Vector3 pointerOffScreenPos;

    int score = 0;

    public void IncrementScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
        Debug.Log("Score: " + score);
    }

    private void Start() {
        pointerOffScreenPos = pointer.transform.position;
    }

    public void InputMouse(Vector2 mouse)
    {
        // pointer.SetActive(true);
        // move pointer to mouse
        // Debug.Log("screen pos: "+ mouse + ", world pos: " + phoneGameCamera.ScreenToWorldPoint(mouse));
        pointer.transform.position = phoneGameCamera.ViewportToWorldPoint(mouse) + Vector3.forward;

        // FindObjectOfType<LikeSpawner>().SpawnNewLike();
    }

    public void NoMouse()
    {
        pointer.transform.position = pointerOffScreenPos;
        // pointer.SetActive(false);
    }
}
