Shader "Bursting Brains/Outlined Toon Shader"
{
	Properties {
		_MainTex		("Base (RGB)",		2D)						= "white" { }
		_Color			("Main Color",		Color)					= (.5,.5,.5,1)
	}

	SubShader {
		Tags { "RenderType"="Opaque" }

		CGPROGRAM
		#pragma surface surf Toon

		sampler2D _MainTex;
		float4 _Color;

		struct Input {
			float2 uv_MainTex;
		};
		
		half4 LightingToon (SurfaceOutput s, half3 lightDir, half atten) {
          half NdotL = dot (s.Normal, lightDir);
          half4 c;
          
          // This does the "Toon" shading part
          if (NdotL > 0.95) NdotL = 1.0;
    	  else if (NdotL > 0.5) NdotL = 0.7;
    	  else if (NdotL > 0.05) NdotL = 0.35;
    	  else NdotL = 0.1;
 
          c.rgb = s.Albedo * _LightColor0.rgb * (NdotL * 2);
          c.a = s.Alpha;
          return c;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG

		//ouline pass
		Pass {
			Blend SrcAlpha OneMinusSrcAlpha
			Cull Front
			Offset -1, -1
			Lighting Off
			ZWrite Off
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			struct appdata {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f {
				float4 pos : SV_POSITION; // project view position
				float4 wPos : TEXCOORD0; // world-based position
				float4 wNor : TEXCOORD1; // world-based normal
			};

			v2f vert(appdata v) {
				v2f o;
				// Outline width is 0.056
				v.vertex.xyz += 0.056 * v.normal;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.wPos = mul(_Object2World, v.vertex);
				o.wNor = mul(_Object2World, float4(v.normal.xyz, 0));
				return o;
			}

			half4 frag(v2f i) : COLOR {
				// Color is BLACK and it's always fully saturated
				half4 answer = half4(0,0,0,1);
				answer.a = 1.0;
				return answer;
			}

			ENDCG
		}
	}
}