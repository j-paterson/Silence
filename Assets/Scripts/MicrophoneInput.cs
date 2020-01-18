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

        public GameObject sphere1;
        public GameObject sphere2;
        public GameObject sphere3;
        public GameObject sphere4;
        public GameObject sphere5;

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
                    //bubbleController.addBubble(sphere1.transform.position, (sphere1.GetComponent<SphereCollider>().radius * sphere1.transform.localScale.x));
                }
                else
                {
                    sphere2.SetActive(false);
                }


                if (level > volumeSensitivity2)
                {
                    bubbleController.addBubble(sphere2.transform.position, (sphere2.GetComponent<SphereCollider>().radius * sphere2.transform.localScale.x * 2));
                    //print(level);
                }
                else
                {
                    sphere2.SetActive(false);
                }


                if (level > volumeSensitivity3)
                {
                    bubbleController.addBubble(sphere3.transform.position, (sphere3.GetComponent<SphereCollider>().radius * sphere3.transform.localScale.x * 3));
                    //sphere3.SetActive(true);
                    //print(level);
                }
                else
                {
                    sphere3.SetActive(false);
                }

                if (level > volumeSensitivity4)
                {
                    bubbleController.addBubble(sphere3.transform.position, (sphere3.GetComponent<SphereCollider>().radius * sphere3.transform.localScale.x * 4));
                    //sphere4.SetActive(true);
                    //print(level);
                }
                else
                {
                    sphere4.SetActive(false);
                }

                if (level > volumeSensitivity5)
                {
                    bubbleController.addBubble(sphere3.transform.position, (sphere3.GetComponent<SphereCollider>().radius * sphere3.transform.localScale.x * 5));
                    //sphere5.SetActive(true);
                    //print(level);
                }
                else
                {
                    sphere5.SetActive(false);
                }
            }
            else
            {
                sphere1.SetActive(false);
                sphere2.SetActive(false);
                sphere3.SetActive(false);
                sphere4.SetActive(false);
                sphere5.SetActive(false);
            }

            debug.text = bubbleController.BubbleCount.ToString();

        }
    }
}

