#ifndef SPEECH_BUBBLE
#define SPEECH_BUBBLE
#include "UnityCG.cginc"

struct bubble
{
	float3 position;
	float a;
	float t;
};

float4 _ColorBubble;
StructuredBuffer<bubble> sBuffer;
float numBubbles;

float bubbleVal(float3 worldPos) {
	float sdfVal = 2;

	for (int i = 0; i < numBubbles; i++) {
		bubble currBubble = sBuffer[i];

		float animTime = 1;
		float radius = currBubble.a * clamp(((_Time.y - currBubble.t)/animTime), 0, 1);

		float3 delta = worldPos - currBubble.position;
		float distanceSq = dot(delta, delta);
		float currVal = distanceSq - (radius*radius);

		sdfVal = min(currVal, sdfVal);
	}

	//float4 currBubble = _ColorBubble;
	//float3 bubbleLocation = float3(currBubble.x, currBubble.y, currBubble.z);
	//float radius = currBubble.w;
	//sdfVal = distance(worldPos, bubbleLocation) - radius;
	
	return sign(sdfVal)*sqrt(abs(sdfVal));
}

float getMargin() {
	return 0.5;
}

#endif /* SPEECH_BUBBLE */
