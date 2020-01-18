using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeHumanoids : MonoBehaviour
{
    public bool isNegative = true;
    public bool changedToPositive = false;

    public GameObject negativeFire;

    Animator anim;

    public int startingAnimation;

    // Start is called before the first frame update
    void Start()
    {
        isNegative = true;
        anim = GetComponent<Animator>();

        startingAnimation = Random.Range(0, 5);
        SetAnimationFromNumber(startingAnimation);
    }

    // Update is called once per frame
    void Update()
    {
        if(changedToPositive == true && isNegative == true)
        {
            anim.CrossFade("Happy Idle", 0.1f);
            isNegative = false;
            negativeFire.SetActive(false);
        }
    }


    public void SetAnimationFromNumber(float number)
    {
        switch (number)
        {
            case 0:
                anim.CrossFade("Writhing In Pain", 0.1f);
                break;
            case 1:
                anim.CrossFade("Sad Idle", 0.1f);
                break;
            case 2:
                anim.CrossFade("Sad Walk", 0.1f);
                break;
            case 3:
                anim.CrossFade("Agony", 0.1f);
                break;
            case 4:
                anim.CrossFade("Shake Fist", 0.1f);
                break;
            case 5:
                anim.CrossFade("Yelling Out", 0.1f);
                break;
            default:
                break;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject voiceMagic = other.gameObject;

        if (voiceMagic.CompareTag("Voice Magic") && changedToPositive == false)
        {
            changedToPositive = true;
            print("Hit the guy with Voice Magic!!");
        }
    }

}
