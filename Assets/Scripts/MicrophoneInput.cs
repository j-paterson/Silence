namespace Prisma
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using Valve.VR;

    public class MicrophoneInput : MonoBehaviour
    {
        public SteamVR_Action_Boolean useVoice;
        public Material quillPaintMat;
        public static BubbleController bubbleController;
        public Text debug;

        //bool MicrophoneIsAwake = false;
        AudioSource source;
        AudioClip audioClip;
        public float volumeSensitivity1 = .2f;
        public float volumeSensitivity2 = .3f;
        public float volumeSensitivity3 = .4f;
        public float volumeSensitivity4 = .5f;
        public float volumeSensitivity5 = .6f;
        int decibels = 128;
        int micPosition;
        float wavePeak;
        float level;

        public GameObject colorOrigin;

        public int bubbleCount = 0;

        // Start is called before the first frame update
        void Start()
        {
            bubbleController = new BubbleController(quillPaintMat);

            source = GetComponent<AudioSource>();

            if (Microphone.devices.Length > 0)
            {
                audioClip = Microphone.Start(Microphone.devices[0], true, 999, 44100);
                //MicrophoneIsAwake = true;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (useVoice.state)
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

                if (level > volumeSensitivity1)
                {
                    bubbleController.addBubble(colorOrigin.transform.position, colorOrigin.transform.localScale.x*3);
                } else if (level > volumeSensitivity2)
                {
                    bubbleController.addBubble(colorOrigin.transform.position, colorOrigin.transform.localScale.x*6);                    //print(level);
                }
                else if (level > volumeSensitivity3)
                {
                    bubbleController.addBubble(colorOrigin.transform.position, colorOrigin.transform.localScale.x*9);
                }
                else if (level > volumeSensitivity4)
                {
                    bubbleController.addBubble(colorOrigin.transform.position, colorOrigin.transform.localScale.x*12);
                } else if (level > volumeSensitivity5)
                {
                    bubbleController.addBubble(colorOrigin.transform.position, colorOrigin.transform.localScale.x*18);
                }
            }
            debug.text = bubbleController.BubbleCount.ToString();

        }
    }
}

