using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MicrophoneInput : MonoBehaviour
{

    bool MicrophoneIsAwake = false;
    AudioClip audioClip;
    public float volumeSensitivity;
    int decibels = 128;
    int micPosition;
    float wavePeak;
    float level;

    // Start is called before the first frame update
    void Start()
    {
        if(Microphone.devices.Length > 0)
        {
            Microphone.Start(Microphone.devices[0], true, 999, 44100);
            MicrophoneIsAwake = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float[] waveData = new float[decibels];
        micPosition = Microphone.GetPosition(null) - (decibels + 1);
        audioClip.GetData(waveData, micPosition);

        float levelMax = 0;
        for (int i = 0; i < decibels; i++)
        {
            wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }

        level = Mathf.Sqrt(Mathf.Sqrt(levelMax));


        if (level > volumeSensitivity)
        {


        }
        if (level < volumeSensitivity)
        {

        }

    }

}

