using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBehaviour : MonoBehaviour
{
    public GameObject lockPick;

    public float lockNum;

    public float lockDiff;

    // Start is called before the first frame update
    void Start()
    {
        lockNum = Random.Range(0, 36) * 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float lockpickNum = lockPick.GetComponent<LockpickBehaviour>().lockpickVal / 2;
        lockDiff = Mathf.Abs(lockpickNum - lockNum);

        if (Input.GetKeyDown("w"))
        {
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 90.0f - lockDiff);
        }
        if (Input.GetKeyUp("w"))
        {
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
}
