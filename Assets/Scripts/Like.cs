using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Like : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] Sprite[] sprites;
    Vector2 movementDirection;

    void Start() {
        // choose random sprite
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    public void SetMovementDirection(Vector2 direction)
    {
        movementDirection = direction;
    }

    void FixedUpdate() {
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
}
