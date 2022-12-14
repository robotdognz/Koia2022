using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneGameController : MonoBehaviour
{
    [SerializeField] Camera phoneGameCamera;
    [SerializeField] GameObject pointer;

    [SerializeField] private float sanityRecovery = 0.15f;

    TextMeshProUGUI scoreText;

    Vector3 pointerOffScreenPos;

    public int score = 0;

    public void IncrementScore()
    {
        score += 1;
        if (scoreText == null)
        {
            scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        }
        scoreText.text = "Likes: " + score;
        AudioManager.Instance.PlayLikeSound();
        PhoneDeprivation phoneDeprivation = FindObjectOfType<PhoneDeprivation>();
        phoneDeprivation.RecoverSanity(sanityRecovery);
        // Debug.Log("Score: " + score);
    }

    private void Start()
    {
        pointerOffScreenPos = pointer.transform.position;
        if (scoreText != null)
        {
            scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        }
    }

    public void InputMouse(Vector2 mouse)
    {
        // pointer.SetActive(true);
        // move pointer to mouse
        // Debug.Log("screen pos: "+ mouse + ", world pos: " + phoneGameCamera.ScreenToWorldPoint(mouse));


        // pointer.transform.position = phoneGameCamera.ViewportToWorldPoint(mouse) + Vector3.forward;

        // phoneGameCamera.ViewportPointToRay

        // phoneGameCamera.ViewportToWorldPoint


        // Debug.Log(mouse);
        // Ray ray = phoneGameCamera.ViewportPointToRay(mouse);
        RaycastHit2D hit = Physics2D.GetRayIntersection(phoneGameCamera.ViewportPointToRay(mouse));
        if (hit.collider != null)
        {
            // Debug.Log(hit.transform.position);
            // Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag != "LikeDespawn")
            {
                // Debug.Log("Thing");
                //Destroy(hit.collider.gameObject);
                hit.collider.GetComponent<Like>().Pop();
                PhoneGameController phoneGame = FindObjectOfType<PhoneGameController>();
                phoneGame.IncrementScore();
            }
        }
    }

    public void NoMouse()
    {
        pointer.transform.position = pointerOffScreenPos;
        // pointer.SetActive(false);
    }
}
