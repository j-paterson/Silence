using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeEnergyHolder : MonoBehaviour
{
    public GameObject negativeFire;

    public bool changedToPositive = false;

    public bool isNegative = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (changedToPositive == true && isNegative == true)
        {
            isNegative = false;
            negativeFire.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject voiceMagic = other.gameObject;

        if (voiceMagic.CompareTag("Voice Magic") && changedToPositive == false)
        {
            changedToPositive = true;
        }
    }

}
