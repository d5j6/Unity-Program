// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.9558824,fgcg:0.8012543,fgcb:0.5693123,fgca:1,fgde:0.025,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32761,y:32653,varname:node_2865,prsc:2|emission-2989-OUT,alpha-1309-OUT,clip-1309-OUT;n:type:ShaderForge.SFN_TexCoord,id:3995,x:31486,y:32623,varname:node_3995,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:6008,x:31729,y:32751,varname:node_6008,prsc:2,spu:1,spv:0|UVIN-3995-UVOUT,DIST-9292-OUT;n:type:ShaderForge.SFN_Slider,id:9292,x:31344,y:32943,ptovrint:False,ptlb:EclipseProgress,ptin:_EclipseProgress,varname:node_9292,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:-1,max:1;n:type:ShaderForge.SFN_Tex2d,id:613,x:31900,y:32751,ptovrint:False,ptlb:MoonTex,ptin:_MoonTex,varname:node_613,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1e79df652d1f739488a65ad469083f8f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4073,x:31894,y:33022,ptovrint:False,ptlb:CutMask,ptin:_CutMask,varname:node_4073,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4d1dec98f1bcf5a408b89c3002360497,ntxv:1,isnm:False|UVIN-6008-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2989,x:32210,y:32731,varname:node_2989,prsc:2|A-613-RGB,B-4073-RGB;n:type:ShaderForge.SFN_Multiply,id:1309,x:32419,y:32995,varname:node_1309,prsc:2|A-613-A,B-4073-R;proporder:9292-613-4073;pass:END;sub:END;*/

Shader "Shader Forge/PBRShader_Default_UV_Ani" {
    Properties {
        _EclipseProgress ("EclipseProgress", Range(-1, 1)) = -1
        _MoonTex ("MoonTex", 2D) = "white" {}
        _CutMask ("CutMask", 2D) = "gray" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d11 gles3 
            #pragma target 3.0
            uniform float _EclipseProgress;
            uniform sampler2D _MoonTex; uniform float4 _MoonTex_ST;
            uniform sampler2D _CutMask; uniform float4 _CutMask_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _MoonTex_var = tex2D(_MoonTex,TRANSFORM_TEX(i.uv0, _MoonTex));
                float2 node_6008 = (i.uv0+_EclipseProgress*float2(1,0));
                float4 _CutMask_var = tex2D(_CutMask,TRANSFORM_TEX(node_6008, _CutMask));
                float node_1309 = (_MoonTex_var.a*_CutMask_var.r);
                clip(node_1309 - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = (_MoonTex_var.rgb*_CutMask_var.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,node_1309);
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
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d11 gles3 
            #pragma target 3.0
            uniform float _EclipseProgress;
            uniform sampler2D _MoonTex; uniform float4 _MoonTex_ST;
            uniform sampler2D _CutMask; uniform float4 _CutMask_ST;
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
                float4 _MoonTex_var = tex2D(_MoonTex,TRANSFORM_TEX(i.uv0, _MoonTex));
                float2 node_6008 = (i.uv0+_EclipseProgress*float2(1,0));
                float4 _CutMask_var = tex2D(_CutMask,TRANSFORM_TEX(node_6008, _CutMask));
                float node_1309 = (_MoonTex_var.a*_CutMask_var.r);
                clip(node_1309 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d11 gles3 
            #pragma target 3.0
            uniform float _EclipseProgress;
            uniform sampler2D _MoonTex; uniform float4 _MoonTex_ST;
            uniform sampler2D _CutMask; uniform float4 _CutMask_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _MoonTex_var = tex2D(_MoonTex,TRANSFORM_TEX(i.uv0, _MoonTex));
                float2 node_6008 = (i.uv0+_EclipseProgress*float2(1,0));
                float4 _CutMask_var = tex2D(_CutMask,TRANSFORM_TEX(node_6008, _CutMask));
                o.Emission = (_MoonTex_var.rgb*_CutMask_var.rgb);
                
                float3 diffColor = float3(0,0,0);
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, 0, specColor, specularMonochrome );
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
