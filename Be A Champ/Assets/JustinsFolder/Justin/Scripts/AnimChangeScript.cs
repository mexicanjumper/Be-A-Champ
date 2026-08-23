using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimChangeScript : MonoBehaviour
{
    [SerializeField] private Animator generalAnimator;

    [SerializeField] private string animationStateName;  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            generalAnimator.SetBool(animationStateName, true);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            generalAnimator.SetBool(animationStateName, false);
        }
    }
}
