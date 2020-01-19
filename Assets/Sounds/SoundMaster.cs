using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour
{

    public AudioSource intro;
    public AudioSource firstPowerUse;
    public AudioSource villagers;
    public AudioSource beforeTheDoor;
    public AudioSource endAtShadowSelf;

    
    public AudioClip introClip;
    public AudioClip firstPowerUseClip;
    public AudioClip villagersClip;
    public AudioClip beforeTheDoorClip;
    public AudioClip endAtShadowSelfClip;

    /*
    public GameObject firstPowerUseArea;
    public GameObject villageArea;
    public GameObject beforeTheDoorArea;
    public GameObject nextToMirrorArea;
    */

    // Start is called before the first frame update
    void Start()
    {
        introClip = intro.clip;
        firstPowerUseClip = firstPowerUse.clip;
        villagersClip = villagers.clip;
        beforeTheDoorClip = beforeTheDoor.clip;
        endAtShadowSelfClip = endAtShadowSelf.clip;

        StartCoroutine(PauseBeforeIntro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PauseBeforeIntro()
    {
        yield return new WaitForSecondsRealtime(4.0f);
        intro.Play();
    }

}
