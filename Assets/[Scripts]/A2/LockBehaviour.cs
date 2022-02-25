using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Difficulty 0 = Easy
//Difficulty 1 = Medium
//Difficulty 2 = Hard

public class LockBehaviour : MonoBehaviour
{
    public GameObject lockPick;

    public float lockNum; //Random number used as "Sweet Spot"

    public float lockDiff; //Difference between current lock pick position and "Sweet Spot"

    public float lockRot; //Rotation of lock

    public int currentDifficulty;

    private bool isHeld = false;

    private bool lockPicked = false;

    public GameObject skillContainer; //Object that holds player skill

    // Start is called before the first frame update
    void Start()
    {
        Setup(0);
    }

    public void Setup(int difficulty)
    {
        transform.Find("LockTop").transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        lockNum = Random.Range(0, 36) * 2.5f;
        lockRot = 0.0f;
        lockDiff = 0.0f;
        currentDifficulty = difficulty;
        lockPicked = false;
        isHeld = false;
    }

    // Update is called once per frame
    void Update()
    {
        float lockpickNum = lockPick.GetComponent<LockpickBehaviour>().lockpickVal / 2;
        lockDiff = Mathf.Abs(lockpickNum - lockNum);

        if (Input.GetKeyDown("w"))
        {
            isHeld = true;

        }
        if (Input.GetKeyUp("w"))
        {
            isHeld = false;
        }

        if (!lockPicked)
        {
            if (isHeld && (lockRot <= 90.0f - lockDiff))
            {
                lockRot = lockRot + 1.0f;
            }
            else if (isHeld && lockRot > 90.0f)
            {
                lockRot = 90.0f;
            }
            else if (!isHeld && lockRot > 0.0f)
            {
                lockRot = lockRot - 1.0f;
            }
            else if (!isHeld && lockRot <= 0.0f)
            {
                lockRot = 0.0f;
            }

            print((90.0f - (2.0f - currentDifficulty) * 7.5f));

            if (lockRot >= (90.0f - (2.0f - currentDifficulty) * 7.5f))
            {
                print("Lock Picked");
                lockRot = 90.0f;
                lockPicked = true;
                transform.Find("LockTop").transform.localPosition = new Vector3(0.0f, 50.0f, 0.0f);
                if (skillContainer.GetComponent<A2GameButtonBehaviour>().lockDifficulty < 2)
                {
                    skillContainer.GetComponent<A2GameButtonBehaviour>().lockDifficulty = currentDifficulty + 1;
                }
            }
        }

        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, lockRot);
    }
}
