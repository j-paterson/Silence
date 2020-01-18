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

        struct bubble
        {
            public float x;
            public float y;
            public float z;
            public float a;

            public bubble(float x, float y, float z, float a)
            {
                this.x = x;
                this.y = y;
                this.z = z;
                this.a = a;
            }
        }

        public BubbleController(Material passedMat)
        {
            // Assign material
            quillPaintMat = passedMat;

            //Build bubble list
            bubbles = new List<bubble>();

            bubble newBubble = new bubble(0,0,0,1f);
            bubbles.Add(newBubble);

            cBuffer = new ComputeBuffer(bubbles.Count, sizeof(float) * 4);
            cBuffer.SetData(bubbles);

            quillPaintMat.SetBuffer("sBuffer", cBuffer);
            quillPaintMat.SetFloat("numBubbles", bubbles.Count);
        }

        public void addBubble(Vector3 position, float amplitude)
        {
            var bubble = new bubble(position.x, position.y, position.z, amplitude);
            
            bubbles.Add(bubble);

            cBuffer = new ComputeBuffer(bubbles.Count, sizeof(float) * 4);
            cBuffer.SetData(bubbles);

            quillPaintMat.SetBuffer("sBuffer", cBuffer);
            quillPaintMat.SetFloat("numBubbles", bubbles.Count);
        }
    }
}
