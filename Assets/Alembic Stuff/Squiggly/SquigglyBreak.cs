using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquigglyBreak : MonoBehaviour
{

    public GameObject squiggly;
    public GameObject squiggly2;

    public GameObject squigglyRunning;
    public GameObject squigglyRunning2;

    public bool changedToPositive = false;

    public GameObject shadowMonster;

    // Start is called before the first frame update
    void Start()
    {
        if(squigglyRunning.activeSelf || squigglyRunning2.activeSelf)
        {
            squigglyRunning.SetActive(false);
            squigglyRunning2.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject voiceMagic = other.gameObject;

        if (voiceMagic.CompareTag("Voice Magic") && changedToPositive == false)
        {
            changedToPositive = true;

            squiggly.SetActive(false);
            squiggly2.SetActive(false);

            squigglyRunning.SetActive(true);
            squigglyRunning2.SetActive(true);

            shadowMonster.SetActive(false);
        }
    }

}
