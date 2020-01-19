using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagersAndShadow : MonoBehaviour
{
    public GameObject ManFighting;
    public GameObject WomanFighting;

    public bool changedToPositive = false;

    public GameObject shadowMonster;

    public int timesNeeded = 0;

    public GameObject impactPoint;

    // Start is called before the first frame update
    void Start()
    {
        impactPoint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (timesNeeded >= 10 && changedToPositive == false)
        {
            changedToPositive = true;

            StartCoroutine(Disappear());

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject voiceMagic = other.gameObject;

        if (voiceMagic.CompareTag("Voice Magic") && changedToPositive == false && impactPoint.activeSelf == true)
        {
            timesNeeded++;
        }
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSecondsRealtime(3.0f);

        ManFighting.SetActive(false);
        WomanFighting.SetActive(false);

        shadowMonster.SetActive(false);

        //KidWithStick.transform.lossyScale += -0.5f;
    }

}
