using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTriggerForSounds : MonoBehaviour
{

    public GameObject shadowMonster;



    public AudioSource source;

    public AudioSource needToStop;

    bool hasPlayed = false;

    public GameObject voicePowers;

    // Start is called before the first frame update
    void Start()
    {
        if (shadowMonster.activeSelf == true)
        {
            shadowMonster.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;

        if(player.name.Contains("Player") && hasPlayed == false)
        {
            if(needToStop.isPlaying)
            {
                needToStop.Stop();
            }

            source.Play();

            hasPlayed = true;
            shadowMonster.SetActive(true);
            StartCoroutine(ActivateVoicePowers());
        }
    }

    IEnumerator ActivateVoicePowers()
    {
        yield return new WaitForSecondsRealtime(3.0f);
        voicePowers.SetActive(true);
}

}
