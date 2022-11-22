using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isSneakyHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isSneakyHash = Animator.StringToHash("isSneaky");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isSneaky = animator.GetBool(isSneakyHash);
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool sneakyPressed = Input.GetKey(KeyCode.LeftShift);

        Debug.Log(sneakyPressed);
   
        if (!isWalking && forwardPressed && !isSneaky)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);

        }

        if (sneakyPressed && forwardPressed)
        {
            animator.SetBool(isSneakyHash, true);
        }
        if (!forwardPressed || !sneakyPressed)
        {
            animator.SetBool(isSneakyHash, false);
        }
    }
}
