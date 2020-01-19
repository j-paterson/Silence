using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSequence : MonoBehaviour
{
    public GameObject shadow;

    Animator anim;

    public GameObject ImpactPoint;

    public float transitionTime = 0.1f;

    public bool readyForNextPhase = false;

    public int timesNeeded = 0;

    public AudioSource ending;

    public AudioSource noiseLight;

    bool canHit = false;

    bool hasStartedAnim = false;

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
        if( timesNeeded >= 10 && hasStartedAnim == false)
        {

            hasStartedAnim = true;
            // break glass, fall down.

            anim.CrossFade("Fallen", 0.1f);

            //anim.SetBool("mirrorBreak", true);

            print("Animating!");


            ending.PlayDelayed(2.0f);

        }
    }

    void StartBattle()
    {
        anim = shadow.GetComponent<Animator>();

        StartCoroutine(WaitForTransition(5.0f));

    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject voiceMagic = other.gameObject;

        if (voiceMagic.CompareTag("Voice Magic") && canHit == true)
        {
            timesNeeded++;
            print(timesNeeded);
        }
    }



    IEnumerator WaitForTransition(float secondsNeeded)
    {
        yield return new WaitForSeconds(secondsNeeded);
        //slimeAnim.CrossFade("Attack01", transitionTime);
        //spikeAnim.CrossFade("GetHit", transitionTime);
        ImpactPoint.SetActive(true);

        canHit = true;
    }

}

