// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33610,y:32744,varname:node_4013,prsc:2|emission-9447-OUT,clip-1072-OUT;n:type:ShaderForge.SFN_Slider,id:7042,x:32022,y:33308,ptovrint:False,ptlb:Dissolve Amount,ptin:_DissolveAmount,varname:node_7042,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:0,max:0;n:type:ShaderForge.SFN_RemapRange,id:3094,x:32212,y:33048,varname:node_3094,prsc:2,frmn:0,frmx:1,tomn:-0.7,tomx:0.7|IN-6323-OUT;n:type:ShaderForge.SFN_Tex2d,id:2544,x:32435,y:33204,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_2544,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bb7dc8f428510f34d98ae58c51445a70,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:1072,x:32404,y:33048,varname:node_1072,prsc:2|A-3094-OUT,B-2544-R;n:type:ShaderForge.SFN_RemapRange,id:4466,x:32140,y:32664,varname:node_4466,prsc:2,frmn:0,frmx:1,tomn:-5,tomx:5|IN-1072-OUT;n:type:ShaderForge.SFN_Clamp01,id:8423,x:32313,y:32664,varname:node_8423,prsc:2|IN-4466-OUT;n:type:ShaderForge.SFN_Append,id:1089,x:32655,y:32663,varname:node_1089,prsc:2|A-6187-OUT,B-9628-OUT;n:type:ShaderForge.SFN_Vector1,id:9628,x:32451,y:32864,varname:node_9628,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2dAsset,id:9216,x:32637,y:32877,ptovrint:False,ptlb:RampMap,ptin:_RampMap,varname:node_9216,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3f77ff2d3ad31c242b18de5cdf3555b0,ntxv:0,isnm:False;n:type:ShaderForge.SFN_OneMinus,id:6187,x:32483,y:32663,varname:node_6187,prsc:2|IN-8423-OUT;n:type:ShaderForge.SFN_Tex2d,id:1023,x:32820,y:32826,varname:node_1023,prsc:2,tex:3f77ff2d3ad31c242b18de5cdf3555b0,ntxv:0,isnm:False|UVIN-1089-OUT,TEX-9216-TEX;n:type:ShaderForge.SFN_Tex2d,id:5427,x:33116,y:32618,ptovrint:False,ptlb:Diff,ptin:_Diff,varname:node_5427,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_OneMinus,id:6323,x:32047,y:33048,varname:node_6323,prsc:2|IN-7042-OUT;n:type:ShaderForge.SFN_RemapRange,id:1821,x:33002,y:32826,varname:node_1821,prsc:2,frmn:0,frmx:1,tomn:0,tomx:20|IN-1023-RGB;n:type:ShaderForge.SFN_Clamp01,id:9177,x:33164,y:32826,varname:node_9177,prsc:2|IN-1821-OUT;n:type:ShaderForge.SFN_Add,id:9447,x:33378,y:32771,varname:node_9447,prsc:2|A-5427-RGB,B-9177-OUT;proporder:7042-2544-9216-5427;pass:END;sub:END;*/

Shader "Shader Forge/fx_Appear_Diffuse" {
    Properties {
        _DissolveAmount ("Dissolve Amount", Range(1, 0)) = 0
        _Noise ("Noise", 2D) = "white" {}
        _RampMap ("RampMap", 2D) = "white" {}
        _Diff ("Diff", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d11 gles3 
            #pragma target 3.0
            uniform float _DissolveAmount;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform sampler2D _RampMap; uniform float4 _RampMap_ST;
            uniform sampler2D _Diff; uniform float4 _Diff_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_1072 = (((1.0 - _DissolveAmount)*1.4+-0.7)+_Noise_var.r);
                clip(node_1072 - 0.5);
////// Lighting:
////// Emissive:
                float4 _Diff_var = tex2D(_Diff,TRANSFORM_TEX(i.uv0, _Diff));
                float2 node_1089 = float2((1.0 - saturate((node_1072*10.0+-5.0))),0.0);
                float4 node_1023 = tex2D(_RampMap,TRANSFORM_TEX(node_1089, _RampMap));
                float3 emissive = (_Diff_var.rgb+saturate((node_1023.rgb*20.0+0.0)));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d11 gles3 
            #pragma target 3.0
            uniform float _DissolveAmount;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_1072 = (((1.0 - _DissolveAmount)*1.4+-0.7)+_Noise_var.r);
                clip(node_1072 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
