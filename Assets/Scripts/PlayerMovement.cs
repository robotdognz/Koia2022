using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardMoveSpeed = 2;
    [SerializeField] float laneChangeSpeed = 1;
    [SerializeField] int lanes = 3;
    [SerializeField] float pathWidth = 5;

    public int currentLane;
    float[] lanePositions;
    public bool changingLane = false;

    float horizontalInput = 0;

    [SerializeField] bool isMoving = true;

    void Start()
    {
        // setup lanes from initial parameters

        // make sure there is an odd number of lanes, then create lane array
        if (lanes % 2 == 0)
        {
            lanes += 1;
        }
        lanePositions = new float[lanes];

        // start player in middle lane
        currentLane = lanes / 2;

        // store lane x positions in array
        float laneWidth = pathWidth / lanes;
        // Debug.Log("Lanes: " + lanes + ", Mid lane: " + currentLane + ", Lane width: " + laneWidth);
        float firstLane = transform.position.x - laneWidth * currentLane;
        for (int i = 0; i < lanePositions.Length; i++)
        {
            lanePositions[i] = firstLane + laneWidth * i;
            // Debug.Log("Lane[" + i + "] = " + lanePositions[i]);
        }
    }

    public void DisablePlayer()
    {
        isMoving = false;
    }

    public void EnablePlayer()
    {
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            // check for movement if we aren't already moving
            if (!changingLane)
            {
                horizontalInput = Input.GetAxis("Horizontal");

                // is player trying to change lane
                if (horizontalInput != 0)
                {
                    // change lane if target lane within bounds
                    int targetLane = currentLane + (horizontalInput > 0 ? 1 : -1);
                    if (targetLane >= 0 && targetLane < lanePositions.Length)
                    {
                        changingLane = true;
                        currentLane = targetLane;
                        AudioManager.Instance.PlayStrafeSound();
                    }
                }
            }
            else
            {
                horizontalInput = 0;
            }
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.forward * forwardMoveSpeed * Time.fixedDeltaTime);

            if (changingLane)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(lanePositions[currentLane], transform.position.y, transform.position.z), laneChangeSpeed * Time.fixedDeltaTime);
                if (transform.position.x == lanePositions[currentLane]) changingLane = false;
            }
        }
    }
}
