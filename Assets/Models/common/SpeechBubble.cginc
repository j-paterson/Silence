#ifndef SPEECH_BUBBLE
#define SPEECH_BUBBLE
#include "UnityCG.cginc"

float4 _ColorBubble;
StructuredBuffer<float4> sBuffer;
float numBubbles;

float bubbleVal(float3 worldPos) {
	float sdfVal = 1;

	for (int i = 0; i < numBubbles; i++) {
		float4 currBubble = sBuffer[i];
		float3 bubbleLocation = currBubble.xyz;
		float radius = currBubble.w;
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
