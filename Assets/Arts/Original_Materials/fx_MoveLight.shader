// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-5542-OUT,emission-7817-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32126,y:32812,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.9341785,c3:0.5661765,c4:1;n:type:ShaderForge.SFN_Time,id:9607,x:31167,y:33148,varname:node_9607,prsc:2;n:type:ShaderForge.SFN_Slider,id:8894,x:31256,y:33301,ptovrint:False,ptlb:Water_Speed,ptin:_Water_Speed,varname:node_2733,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:1,max:10;n:type:ShaderForge.SFN_Multiply,id:3275,x:31378,y:33148,varname:node_3275,prsc:2|A-9607-TSL,B-8894-OUT;n:type:ShaderForge.SFN_TexCoord,id:9599,x:30960,y:32957,varname:node_9599,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ComponentMask,id:3702,x:31167,y:32957,varname:node_3702,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-9599-U;n:type:ShaderForge.SFN_Add,id:2055,x:31615,y:33055,varname:node_2055,prsc:2|A-9236-OUT,B-3275-OUT;n:type:ShaderForge.SFN_Multiply,id:4162,x:31837,y:33035,varname:node_4162,prsc:2|A-7739-OUT,B-2055-OUT;n:type:ShaderForge.SFN_Slider,id:5067,x:31605,y:32766,ptovrint:False,ptlb:WaveNumber,ptin:_WaveNumber,varname:node_7920,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:5,max:50;n:type:ShaderForge.SFN_Tau,id:5937,x:31809,y:33337,varname:node_5937,prsc:2;n:type:ShaderForge.SFN_Sin,id:1866,x:32019,y:33035,varname:node_1866,prsc:2|IN-4162-OUT;n:type:ShaderForge.SFN_RemapRange,id:7384,x:32200,y:33035,varname:node_7384,prsc:2,frmn:0,frmx:1,tomn:0,tomx:1|IN-1866-OUT;n:type:ShaderForge.SFN_Clamp01,id:1524,x:32381,y:33035,varname:node_1524,prsc:2|IN-7384-OUT;n:type:ShaderForge.SFN_Multiply,id:7817,x:32381,y:32812,varname:node_7817,prsc:2|A-1304-RGB,B-1524-OUT,C-1853-OUT;n:type:ShaderForge.SFN_Floor,id:7739,x:31748,y:32860,varname:node_7739,prsc:2|IN-5067-OUT;n:type:ShaderForge.SFN_Slider,id:1853,x:32224,y:33269,ptovrint:False,ptlb:Emission,ptin:_Emission,varname:node_1853,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:10;n:type:ShaderForge.SFN_Vector1,id:5542,x:32469,y:32710,varname:node_5542,prsc:2,v1:0.2;n:type:ShaderForge.SFN_RemapRange,id:9236,x:31378,y:32930,varname:node_9236,prsc:2,frmn:0,frmx:1,tomn:0,tomx:1|IN-3702-OUT;proporder:1304-8894-5067-1853;pass:END;sub:END;*/

Shader "Shader Forge/fx_MoveLight" {
    Properties {
        _Color ("Color", Color) = (1,0.9341785,0.5661765,1)
        _Water_Speed ("Water_Speed", Range(-10, 10)) = 1
        _WaveNumber ("WaveNumber", Range(0, 50)) = 5
        _Emission ("Emission", Range(0, 10)) = 2
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
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _Water_Speed;
            uniform float _WaveNumber;
            uniform float _Emission;
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
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_5542 = 0.2;
                float3 diffuseColor = float3(node_5542,node_5542,node_5542);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_9607 = _Time + _TimeEditor;
                float3 emissive = (_Color.rgb*saturate((sin((floor(_WaveNumber)*((i.uv0.r.r*1.0+0.0)+(node_9607.r*_Water_Speed))))*1.0+0.0))*_Emission);
/// Final Color:
                float3 finalColor = diffuse + emissive;
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _Water_Speed;
            uniform float _WaveNumber;
            uniform float _Emission;
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
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float node_5542 = 0.2;
                float3 diffuseColor = float3(node_5542,node_5542,node_5542);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
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
