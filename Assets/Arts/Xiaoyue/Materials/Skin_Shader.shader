// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5514706,fgcg:0.8144016,fgcb:1,fgca:1,fgde:0.005,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32841,y:32703,varname:node_4013,prsc:2|diff-6165-OUT,spec-4097-OUT,gloss-5495-OUT,emission-5172-OUT;n:type:ShaderForge.SFN_Tex2d,id:3659,x:31488,y:32401,ptovrint:False,ptlb:Diff,ptin:_Diff,varname:node_3659,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e521588a1d3b5d84cacd99e67181e939,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Fresnel,id:4380,x:31819,y:32882,varname:node_4380,prsc:2|NRM-7176-OUT,EXP-8806-OUT;n:type:ShaderForge.SFN_Slider,id:8806,x:31460,y:33070,ptovrint:False,ptlb:Emiss,ptin:_Emiss,varname:node_8806,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.5,max:5;n:type:ShaderForge.SFN_NormalVector,id:7176,x:31539,y:32882,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:7663,x:31954,y:32153,varname:node_7663,prsc:2|A-3659-RGB,B-1673-OUT;n:type:ShaderForge.SFN_Slider,id:1673,x:31815,y:32353,ptovrint:False,ptlb:diff_level,ptin:_diff_level,varname:node_1673,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Multiply,id:5172,x:32480,y:33006,varname:node_5172,prsc:2|A-3659-RGB,B-6476-OUT;n:type:ShaderForge.SFN_Slider,id:9989,x:32186,y:33447,ptovrint:False,ptlb:Outline,ptin:_Outline,varname:node_9989,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1,max:5;n:type:ShaderForge.SFN_Color,id:8187,x:32369,y:33552,ptovrint:False,ptlb:Outline_Color,ptin:_Outline_Color,varname:node_8187,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:3134,x:31819,y:33099,ptovrint:False,ptlb:Fresnel_Color,ptin:_Fresnel_Color,varname:node_3134,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:4097,x:32222,y:32652,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_4097,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Slider,id:5495,x:32222,y:32768,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_5495,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Add,id:6165,x:32547,y:32320,varname:node_6165,prsc:2|A-258-OUT,B-9858-RGB,C-4380-OUT;n:type:ShaderForge.SFN_Color,id:9858,x:32547,y:32496,ptovrint:False,ptlb:ColorLight,ptin:_ColorLight,varname:node_9858,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:6476,x:32027,y:33023,varname:node_6476,prsc:2|A-4380-OUT,B-3134-RGB;n:type:ShaderForge.SFN_RemapRange,id:258,x:32327,y:32246,varname:node_258,prsc:2,frmn:0,frmx:1,tomn:-1.5,tomx:1.35|IN-7663-OUT;proporder:3659-8806-1673-9989-8187-5495-4097-9858-3134;pass:END;sub:END;*/

Shader "Shader Forge/Skin_Shader" {
    Properties {
        _Diff ("Diff", 2D) = "white" {}
        _Emiss ("Emiss", Range(0, 5)) = 1.5
        _diff_level ("diff_level", Range(0, 5)) = 1
        _Outline ("Outline", Range(0, 5)) = 0.1
        _Outline_Color ("Outline_Color", Color) = (0.5,0.5,0.5,1)
        _Gloss ("Gloss", Range(0, 1)) = 0.5
        _Specular ("Specular", Range(0, 1)) = 0.5
        _ColorLight ("ColorLight", Color) = (0.5,0.5,0.5,1)
        _Fresnel_Color ("Fresnel_Color", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d11 glcore gles3 metal 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Diff; uniform float4 _Diff_ST;
            uniform float _Emiss;
            uniform float _diff_level;
            uniform float4 _Fresnel_Color;
            uniform float _Specular;
            uniform float _Gloss;
            uniform float4 _ColorLight;
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
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Diff_var = tex2D(_Diff,TRANSFORM_TEX(i.uv0, _Diff));
                float node_4380 = pow(1.0-max(0,dot(i.normalDir, viewDirection)),_Emiss);
                float3 diffuseColor = (((_Diff_var.rgb*_diff_level)*2.85+-1.5)+_ColorLight.rgb+node_4380);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = (_Diff_var.rgb*(node_4380+_Fresnel_Color.rgb));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d11 glcore gles3 metal 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Diff; uniform float4 _Diff_ST;
            uniform float _Emiss;
            uniform float _diff_level;
            uniform float4 _Fresnel_Color;
            uniform float _Specular;
            uniform float _Gloss;
            uniform float4 _ColorLight;
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
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Diff_var = tex2D(_Diff,TRANSFORM_TEX(i.uv0, _Diff));
                float node_4380 = pow(1.0-max(0,dot(i.normalDir, viewDirection)),_Emiss);
                float3 diffuseColor = (((_Diff_var.rgb*_diff_level)*2.85+-1.5)+_ColorLight.rgb+node_4380);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
