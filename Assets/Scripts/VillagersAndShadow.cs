using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagersAndShadow : MonoBehaviour
{
    public GameObject ManFighting;
    public GameObject WomanFighting;

    public GameObject crowdMember1;
    public GameObject crowdMember2;
    public GameObject crowdMember3;

    public bool changedToPositive = false;

    public GameObject shadowMonster;

    public int timesNeeded = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (timesNeeded >= 10 && changedToPositive == false)
        {
            changedToPositive = true;

            ManFighting.SetActive(false);
            WomanFighting.SetActive(false);

            shadowMonster.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject voiceMagic = other.gameObject;

        if (voiceMagic.CompareTag("Voice Magic") && changedToPositive == false)
        {
            timesNeeded++;
        }
    }
}
