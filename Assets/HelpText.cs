using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpText : MonoBehaviour
{
    public string firstText = "Pull the trigger and use your Voice to make it stop and change the world.";

    public GameObject impactPoint;

    public Text UIText;

    public bool hasChanged;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(impactPoint.activeSelf == true && hasChanged == false)
        {
            UIText.text  = firstText;
            hasChanged = true;
            StartCoroutine(StopText());
        }
    }

    IEnumerator StopText()
    {
        yield return new WaitForSeconds(7.5f);
        UIText.text = "";
    }

}
