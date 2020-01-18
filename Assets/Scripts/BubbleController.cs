using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Prisma
{
    public class BubbleController
    {
        Material quillPaintMat;
        List<Vector4> bubbles;
        ComputeBuffer cBuffer;

        public BubbleController(Material passedMat)
        {
            // Assign material
            quillPaintMat = passedMat;

            //Build bubble list
            bubbles = new List<Vector4>();
            bubbles.Add(new Vector4(0, 0, 0, 0.1f));
            bubbles.Add(new Vector4(0, 1, 0, 0.1f));
            bubbles.Add(new Vector4(0, 0, 1, 0.1f));

            cBuffer = new ComputeBuffer(bubbles.Count, sizeof(float) * 4);
            cBuffer.SetData(bubbles);

            quillPaintMat.SetBuffer("sBuffer", cBuffer);
            quillPaintMat.SetFloat("numBubbles", bubbles.Count);
        }

        public void addBubble(Vector3 position, float amplitude)
        {
            Vector4 bubble = new Vector4(position.x, position.y, position.z, amplitude);
            
            bubbles.Add(bubble);

            cBuffer = new ComputeBuffer(bubbles.Count, sizeof(float) * 4);
            cBuffer.SetData(bubbles);

            quillPaintMat.SetBuffer("sBuffer", cBuffer);
            quillPaintMat.SetFloat("numBubbles", bubbles.Count);
        }
    }
}
