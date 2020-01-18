using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class BubbleController : MonoBehaviour
{
    public Material quillPaintMat;
    List<Vector4> bubbles;
    ComputeBuffer cBuffer;

    // Start is called before the first frame update
    void Start()
    {
        bubbles = new List<Vector4>();
        bubbles.Add(new Vector4(0,0,0,0.1f));
        bubbles.Add(new Vector4(0, 1, 0, 0.1f));
        bubbles.Add(new Vector4(0, 0, 1, 0.1f));

        cBuffer = new ComputeBuffer(bubbles.Count, sizeof(float) * 4);
        cBuffer.SetData(bubbles);

        quillPaintMat.SetBuffer("sBuffer", cBuffer);
        quillPaintMat.SetFloat("numBubbles", bubbles.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
