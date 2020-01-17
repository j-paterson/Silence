using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeHumanoids : MonoBehaviour
{
    public bool isNegative = true;
    public bool changedToPositive = false;

    public GameObject negativeFire;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        isNegative = true;
        anim = GetComponent<Animator>();
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
