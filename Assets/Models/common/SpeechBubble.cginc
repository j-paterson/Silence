#ifndef SPEECH_BUBBLE
#define SPEECH_BUBBLE
#include "UnityCG.cginc"

struct bubble
{
	float x;
	float y;
	float z;
	float a;
};

float4 _ColorBubble;
StructuredBuffer<bubble> sBuffer;
float numBubbles;

float bubbleVal(float3 worldPos) {
	float sdfVal = 1;

	for (int i = 0; i < numBubbles; i++) {
		bubble currBubble = sBuffer[i];
		float3 bubbleLocation = float3(currBubble.x, currBubble.y, currBubble.z);
		float radius = currBubble.a;
		float currVal = distance(worldPos, bubbleLocation) - radius;

		//first run
		if (i == 0) {
			sdfVal = currVal;
		}
		else if (currVal < sdfVal) {
			sdfVal = currVal;
		}
	}

	//float4 currBubble = _ColorBubble;
	//float3 bubbleLocation = float3(currBubble.x, currBubble.y, currBubble.z);
	//float radius = currBubble.w;
	//sdfVal = distance(worldPos, bubbleLocation) - radius;

	return sdfVal;
}

float getMargin() {
	return 0.5;
}

#endif /* SPEECH_BUBBLE */
