using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Like : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] Sprite[] sprites;
    Vector2 movementDirection;

    Animation animation;

    void Start()
    {
        // choose random sprite
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];

        animation = GetComponent<Animation>();
    }

    public void SetMovementDirection(Vector2 direction)
    {
        movementDirection = direction;
    }

    void FixedUpdate()
    {
        transform.position += (Vector3)(movementDirection * moveSpeed);
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "LikeDespawn")
        {
            // Debug.Log("Exit");
            Destroy(this.gameObject);
        }
    }

    public void Pop()
    {
        animation.Play();
        StartCoroutine(WaitForAnimationFinish());
    }

    private IEnumerator WaitForAnimationFinish()
    {
        while (animation.isPlaying) yield return null;
        Destroy(gameObject);
    }

    private void OnMouseDown() {
        Debug.Log("Exit");
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.tag == "Finger")
    //     {
    //         // increment score
    //         PhoneGameController phoneGame = FindObjectOfType<PhoneGameController>();
    //         phoneGame.IncrementScore();
    //         Destroy(this.gameObject);
    //     }
    // }
}
