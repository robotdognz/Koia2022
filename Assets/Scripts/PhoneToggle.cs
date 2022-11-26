using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneToggle : MonoBehaviour
{
    [SerializeField] GameObject panel;

    void Update()
    {
        if(panel != null && Input.GetKeyDown(KeyCode.Return))
        {
            // toggle phone
            Animator animator = panel.GetComponent<Animator>();
            if(animator != null)
            {
                bool onPhone = animator.GetBool("OnPhone");
                animator.SetBool("OnPhone", !onPhone);
            }
        }
    }
}
