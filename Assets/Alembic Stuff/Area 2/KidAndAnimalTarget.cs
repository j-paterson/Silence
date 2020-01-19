using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidAndAnimalTarget : MonoBehaviour
{
    public GameObject KidWithStick;
    public GameObject SadSquiggly;
    public GameObject HappySquiggly;

    public GameObject crowdMember1;

    public bool changedToPositive = false;

    public GameObject shadowMonster;

    public int timesNeeded = 0;

    Animator kidAnim;

    public GameObject impactPoint;

    // Start is called before the first frame update
    void Start()
    {
        kidAnim = KidWithStick.GetComponent<Animator>();

        impactPoint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (timesNeeded >= 10 && changedToPositive == false)
        {
            changedToPositive = true;

            kidAnim.CrossFade("Idle", 0.2f);

            SadSquiggly.SetActive(false);
            HappySquiggly.SetActive(true);
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
        yield return new WaitForSecondsRealtime(3.5f);

        KidWithStick.SetActive(false);
        HappySquiggly.SetActive(false);

        shadowMonster.SetActive(false);

        //KidWithStick.transform.lossyScale += -0.5f;
    }

}
