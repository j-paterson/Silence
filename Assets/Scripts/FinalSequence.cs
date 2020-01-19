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

    }

    // Update is called once per frame
    void Update()
    {

    }

    void BreakPossible()
    {

    }

    IEnumerator WaitForTransition(float secondsNeeded)
    {
        yield return new WaitForSeconds(secondsNeeded);
        //slimeAnim.CrossFade("Attack01", transitionTime);
        //spikeAnim.CrossFade("GetHit", transitionTime);
        StartBattle();
    }

}

