// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Blur_Shader"
{
	Properties
	{
		_MainSample("Main Sample", 2D) = "white" {}
		_X_Value("X_Value", Range( -0.01 , 0.01)) = 0
		_Y_Value("Y_Value", Range( -0.01 , 0.01)) = 0
		_BlurValue("Blur Value", Range( -0.02 , 0.02)) = 0
		_X_Move_Speed("X_Move_Speed", Float) = 30
		_Y_Move_Speed("Y_Move_Speed", Float) = 30
		_dir("dir", Range( 0 , 1)) = 0.3333333
		_dir2("dir2", Range( 0 , 1)) = 0.3333333
		_constract("constract", Range( -10 , 10)) = 0
		_light("light", Color) = (0.1509434,0.1509434,0.1509434,0)
		_light_value("light_value", Range( 0 , 3)) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Unlit keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float _constract;
		uniform sampler2D _MainSample;
		uniform float _X_Move_Speed;
		uniform float _X_Value;
		uniform float _Y_Value;
		uniform float _Y_Move_Speed;
		uniform float _BlurValue;
		uniform float _dir;
		uniform float _dir2;
		uniform float4 _light;
		uniform float _light_value;


		float4 CalculateContrast( float contrastValue, float4 colorTarget )
		{
			float t = 0.5 * ( 1.0 - contrastValue );
			return mul( float4x4( contrastValue,0,0,t, 0,contrastValue,0,t, 0,0,contrastValue,t, 0,0,0,1 ), colorTarget );
		}

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float2 appendResult3 = (float2(( sin( ( _Time.y * _X_Move_Speed ) ) * _X_Value ) , ( _Y_Value * sin( ( _Y_Move_Speed * _Time.y ) ) )));
			float2 appendResult11 = (float2(_BlurValue , 0.0));
			float2 appendResult16 = (float2(0.0 , _BlurValue));
			float2 appendResult43 = (float2(( sin( ( _dir * UNITY_PI ) ) * _BlurValue ) , 0.0));
			float2 appendResult44 = (float2(0.0 , ( cos( ( _dir * UNITY_PI ) ) * _BlurValue )));
			float2 appendResult66 = (float2(0.0 , ( sin( ( _dir2 * UNITY_PI ) ) * _BlurValue )));
			float2 appendResult67 = (float2(( cos( ( _dir2 * UNITY_PI ) ) * _BlurValue ) , 0.0));
			o.Emission = ( CalculateContrast(_constract,( ( tex2D( _MainSample, ( i.uv_texcoord + appendResult3 ) ) * 0.2 ) + ( tex2D( _MainSample, ( i.uv_texcoord + appendResult11 ) ) * 0.1 ) + ( tex2D( _MainSample, ( i.uv_texcoord + appendResult16 ) ) * 0.1 ) + ( tex2D( _MainSample, i.uv_texcoord ) * 0.2 ) + ( tex2D( _MainSample, ( i.uv_texcoord + appendResult43 ) ) * 0.1 ) + ( tex2D( _MainSample, ( i.uv_texcoord + appendResult44 ) ) * 0.1 ) + ( tex2D( _MainSample, ( i.uv_texcoord + appendResult66 ) ) * 0.1 ) + ( tex2D( _MainSample, ( i.uv_texcoord + appendResult67 ) ) * 0.1 ) )) * ( _light * _light_value ) ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18935
2048;0;1920;1019;-547.1582;429.6863;1;True;True
Node;AmplifyShaderEditor.RangedFloatNode;33;-1307.459,180.1663;Inherit;False;Property;_Y_Move_Speed;Y_Move_Speed;5;0;Create;True;0;0;0;False;0;False;30;60;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;79;-1616.514,2202.994;Inherit;False;Property;_dir2;dir2;7;0;Create;True;0;0;0;False;0;False;0.3333333;0.73;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;29;-1407.825,-71.02283;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;32;-1346.444,-405.299;Inherit;False;Property;_X_Move_Speed;X_Move_Speed;4;0;Create;True;0;0;0;False;0;False;30;60;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;58;-1618.904,1708.554;Inherit;False;Property;_dir;dir;6;0;Create;True;0;0;0;False;0;False;0.3333333;0.554;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.PiNode;57;-1249.604,1223.954;Inherit;True;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;31;-886.4187,-447.9629;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;35;-845.0317,196.1928;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.PiNode;59;-1257.748,2269.708;Inherit;True;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;7;-955.1021,2.074089;Inherit;False;Property;_Y_Value;Y_Value;2;0;Create;True;0;0;0;False;0;False;0;0;-0.01;0.01;0;1;FLOAT;0
Node;AmplifyShaderEditor.SinOpNode;30;-743.9843,-409.1779;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;15;-1085.889,602.3891;Inherit;False;Property;_BlurValue;Blur Value;3;0;Create;True;0;0;0;False;0;False;0;0.0121;-0.02;0.02;0;1;FLOAT;0
Node;AmplifyShaderEditor.CosOpNode;62;-961.3602,2448.826;Inherit;True;1;0;FLOAT;60;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;5;-963.5613,-121.2118;Inherit;False;Property;_X_Value;X_Value;1;0;Create;True;0;0;0;False;0;False;0;0;-0.01;0.01;0;1;FLOAT;0
Node;AmplifyShaderEditor.SinOpNode;36;-699.0856,193.0726;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SinOpNode;53;-929.0706,1035.741;Inherit;True;1;0;FLOAT;60;False;1;FLOAT;0
Node;AmplifyShaderEditor.CosOpNode;54;-878.8998,1585.799;Inherit;True;1;0;FLOAT;60;False;1;FLOAT;0
Node;AmplifyShaderEditor.SinOpNode;78;-1005.538,1972.208;Inherit;True;1;0;FLOAT;60;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;28;-637.3272,-86.81779;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;34;-628.9957,46.59969;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;64;-733.5392,2008.615;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;55;-607.8777,1169.588;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;56;-649.3007,1472.976;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;63;-731.7614,2336.003;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;66;-471.2864,2094.034;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;11;-283.3476,391.2952;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;3;-360.1035,-92.73599;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;2;-488.5,-288.5;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;16;-496.8198,765.2026;Inherit;True;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;43;-388.826,1231.007;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;10;-304.7648,222.1714;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;68;-501.3426,1907.462;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;65;-506.6034,2247.052;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;17;-349.437,544.2784;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;44;-390.7256,1656.149;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;67;-473.186,2519.176;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;41;-424.1429,1384.025;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;42;-418.8821,1044.434;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;45;-83.50402,1120.808;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;6;-191.3328,-149.255;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;9;-8.798342,281.0616;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;18;-41.47055,706.1687;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;46;-116.1762,1545.916;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;40;-203.4655,-569.7354;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;69;-198.6366,2408.943;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;70;-165.9644,1983.835;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;74;-50.41723,2368.655;Inherit;True;Property;_TextureSample6;Texture Sample 4;0;0;Create;True;0;0;0;False;0;False;-1;None;5cd11a9a9d044fe4991f355e96dbd8d2;True;0;False;white;Auto;False;Instance;1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;39;453.3052,-303.9819;Inherit;False;Constant;_Float3;Float 3;4;0;Create;True;0;0;0;False;0;False;0.2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;1;1.655229,-47.92694;Inherit;True;Property;_MainSample;Main Sample;0;0;Create;True;0;0;0;False;0;False;-1;None;68718b007b3e15249ba6c9c4e31c045f;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;13;386.9173,463.745;Inherit;False;Constant;_Float0;Float 0;4;0;Create;True;0;0;0;False;0;False;0.1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;50;32.04327,1505.628;Inherit;True;Property;_TextureSample4;Texture Sample 4;0;0;Create;True;0;0;0;False;0;False;-1;None;5cd11a9a9d044fe4991f355e96dbd8d2;True;0;False;white;Auto;False;Instance;1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;71;229.7512,2166.519;Inherit;False;Constant;_Float6;Float 5;4;0;Create;True;0;0;0;False;0;False;0.1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;19;106.749,665.8813;Inherit;True;Property;_TextureSample0;Texture Sample 0;0;0;Create;True;0;0;0;False;0;False;-1;None;5cd11a9a9d044fe4991f355e96dbd8d2;True;0;False;white;Auto;False;Instance;1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;47;279.5395,1725.553;Inherit;False;Constant;_Float4;Float 4;4;0;Create;True;0;0;0;False;0;False;0.1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;23;430.4654,129.6234;Inherit;False;Constant;_Float2;Float 2;4;0;Create;True;0;0;0;False;0;False;0.2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;20;392.2711,806.8295;Inherit;False;Constant;_Float1;Float 1;4;0;Create;True;0;0;0;False;0;False;0.1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;37;128.0913,-560.8307;Inherit;True;Property;_TextureSample2;Texture Sample 2;0;0;Create;True;0;0;0;False;0;False;-1;None;5cd11a9a9d044fe4991f355e96dbd8d2;True;0;False;white;Auto;False;Instance;1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;73;-17.74504,1943.549;Inherit;True;Property;_TextureSample5;Texture Sample 3;0;0;Create;True;0;0;0;False;0;False;-1;None;5cd11a9a9d044fe4991f355e96dbd8d2;True;0;False;white;Auto;False;Instance;1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;8;139.4212,240.7742;Inherit;True;Property;_TextureSample1;Texture Sample 1;0;0;Create;True;0;0;0;False;0;False;-1;None;5cd11a9a9d044fe4991f355e96dbd8d2;True;0;False;white;Auto;False;Instance;1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;49;64.71545,1080.521;Inherit;True;Property;_TextureSample3;Texture Sample 3;0;0;Create;True;0;0;0;False;0;False;-1;None;5cd11a9a9d044fe4991f355e96dbd8d2;True;0;False;white;Auto;False;Instance;1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;48;312.2117,1303.492;Inherit;False;Constant;_Float5;Float 5;4;0;Create;True;0;0;0;False;0;False;0.1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;72;197.079,2588.58;Inherit;False;Constant;_Float7;Float 4;4;0;Create;True;0;0;0;False;0;False;0.1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;21;544.0752,715.784;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;52;469.3697,1555.531;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;576.7474,290.6769;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;76;386.9092,2418.558;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;75;419.5813,1993.451;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;51;502.0418,1130.424;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;22;588.1823,23.44086;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;38;614.1371,-413.2794;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;14;1132.963,-146.7569;Inherit;False;8;8;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;84;1504.778,171.4012;Inherit;False;Property;_light;light;9;0;Create;True;0;0;0;False;0;False;0.1509434,0.1509434,0.1509434,0;1,1,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;87;1307.778,422.4012;Inherit;False;Property;_light_value;light_value;10;0;Create;True;0;0;0;False;0;False;1;1.55;0;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;81;1183.276,146.6483;Inherit;False;Property;_constract;constract;8;0;Create;True;0;0;0;False;0;False;0;1;-10;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleContrastOpNode;80;1497.276,-85.35168;Inherit;True;2;1;COLOR;0,0,0,0;False;0;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;86;1657.778,394.4012;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;85;1748.778,52.40121;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;77;-1737.94,2164.147;Inherit;False;Constant;_Float9;Float 8;8;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;61;-874.0237,1303.441;Inherit;False;Constant;_Float8;Float 8;8;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1942.291,-115.0199;Float;False;True;-1;2;ASEMaterialInspector;0;0;Unlit;Blur_Shader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;18;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;57;0;58;0
WireConnection;31;0;29;0
WireConnection;31;1;32;0
WireConnection;35;0;33;0
WireConnection;35;1;29;0
WireConnection;59;0;79;0
WireConnection;30;0;31;0
WireConnection;62;0;59;0
WireConnection;36;0;35;0
WireConnection;53;0;57;0
WireConnection;54;0;57;0
WireConnection;78;0;59;0
WireConnection;28;0;30;0
WireConnection;28;1;5;0
WireConnection;34;0;7;0
WireConnection;34;1;36;0
WireConnection;64;0;78;0
WireConnection;64;1;15;0
WireConnection;55;0;53;0
WireConnection;55;1;15;0
WireConnection;56;0;54;0
WireConnection;56;1;15;0
WireConnection;63;0;62;0
WireConnection;63;1;15;0
WireConnection;66;1;64;0
WireConnection;11;0;15;0
WireConnection;3;0;28;0
WireConnection;3;1;34;0
WireConnection;16;1;15;0
WireConnection;43;0;55;0
WireConnection;44;1;56;0
WireConnection;67;0;63;0
WireConnection;45;0;42;0
WireConnection;45;1;43;0
WireConnection;6;0;2;0
WireConnection;6;1;3;0
WireConnection;9;0;10;0
WireConnection;9;1;11;0
WireConnection;18;0;17;0
WireConnection;18;1;16;0
WireConnection;46;0;41;0
WireConnection;46;1;44;0
WireConnection;69;0;65;0
WireConnection;69;1;67;0
WireConnection;70;0;68;0
WireConnection;70;1;66;0
WireConnection;74;1;69;0
WireConnection;1;1;6;0
WireConnection;50;1;46;0
WireConnection;19;1;18;0
WireConnection;37;1;40;0
WireConnection;73;1;70;0
WireConnection;8;1;9;0
WireConnection;49;1;45;0
WireConnection;21;0;19;0
WireConnection;21;1;20;0
WireConnection;52;0;50;0
WireConnection;52;1;47;0
WireConnection;12;0;8;0
WireConnection;12;1;13;0
WireConnection;76;0;74;0
WireConnection;76;1;72;0
WireConnection;75;0;73;0
WireConnection;75;1;71;0
WireConnection;51;0;49;0
WireConnection;51;1;48;0
WireConnection;22;0;1;0
WireConnection;22;1;23;0
WireConnection;38;0;37;0
WireConnection;38;1;39;0
WireConnection;14;0;22;0
WireConnection;14;1;12;0
WireConnection;14;2;21;0
WireConnection;14;3;38;0
WireConnection;14;4;51;0
WireConnection;14;5;52;0
WireConnection;14;6;75;0
WireConnection;14;7;76;0
WireConnection;80;1;14;0
WireConnection;80;0;81;0
WireConnection;86;0;84;0
WireConnection;86;1;87;0
WireConnection;85;0;80;0
WireConnection;85;1;86;0
WireConnection;0;2;85;0
ASEEND*/
//CHKSM=C820CAACDA876D6416F189180AB9E4EADC70F9F4