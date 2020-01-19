using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSequence : MonoBehaviour
{
    public Animator shadowAnim;
    public GameObject ImpactPoint;

    public float transitionTime = 0.1f;

    public bool readyForNextPhase = false;

    // Start is called before the first frame update
    void Start()
    {
        //slimeAnim = GetComponent<Animator>();
        //spikeAnim = GetComponent<Animator>();

        StartBattle();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartBattle()
    {
        print("Restarting Battle");
        //slimeAnim.CrossFade("IdleBattle", transitionTime);
        //spikeAnim.CrossFade("IdleBattle", transitionTime);

        StartCoroutine(WaitForTransition(3.0f));

    }

    IEnumerator WaitForTransition(float secondsNeeded)
    {
        yield return new WaitForSeconds(secondsNeeded);
        //slimeAnim.CrossFade("Attack01", transitionTime);
        //spikeAnim.CrossFade("GetHit", transitionTime);
        StartBattle();
    }

}

