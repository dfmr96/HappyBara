using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] Transform localTrans;
    [SerializeField] Transform mLookAt;

    private void Start()
    {
        localTrans = GetComponent<Transform>();
        mLookAt = GameManager.sharedInstance.GetCamera().transform;
    }

    private void Update()
    {
        if (mLookAt)
        {
            localTrans.LookAt(2 * localTrans.position - mLookAt.position);
        }
    }
}
