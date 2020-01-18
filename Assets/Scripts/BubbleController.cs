using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Prisma
{
    public class BubbleController
    {
        Material quillPaintMat;
        List<bubble> bubbles;
        ComputeBuffer cBuffer;

        public int BubbleCount => bubbles.Count;

        struct bubble
        {
            public Vector3 position;
            public float a;
            public float t;

            public bubble(float x, float y, float z, float a, float time)
            {
                position = new Vector3(x, y, z);
                this.a = a;
                this.t = time;
            }
        }

        public BubbleController(Material passedMat)
        {
            // Assign material
            quillPaintMat = passedMat;

            //Build bubble list
            bubbles = new List<bubble>();

            bubble newBubble = new bubble(0,0,0,1f,Time.time);
            bubbles.Add(newBubble);

            cBuffer = new ComputeBuffer(bubbles.Count, sizeof(float) * 5);
            cBuffer.SetData(bubbles);

            quillPaintMat.SetBuffer("sBuffer", cBuffer);
            quillPaintMat.SetFloat("numBubbles", bubbles.Count);
        }

        public void addBubble(Vector3 position, float amplitude)
        {
            foreach (bubble bub in bubbles)
            {
                if (Vector3.Distance(position, bub.position) < bub.a * 0.75)
                {
                    return;
                }
            }
               
            var newBub = new bubble(position.x, position.y, position.z, amplitude, Time.time);
            
            bubbles.Add(newBub);

            cBuffer = new ComputeBuffer(bubbles.Count, sizeof(float) * 5);
            cBuffer.SetData(bubbles);

            quillPaintMat.SetBuffer("sBuffer", cBuffer);
            quillPaintMat.SetFloat("numBubbles", bubbles.Count);
        }
    }
}
