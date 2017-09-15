using UnityEngine;
using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Cutscene = Slate.Cutscene;
using SlateSection = Slate.Section;

namespace FlowCanvas.Nodes.Slate{

	[Name("Cutscene")]
	[Category("Extensions/SLATE")]
	[Description("Wraps the most common functionalities of a SLATE Cutscene, along with outputs for Sections and Cutscene Events which are send through the GlobalMessage Action Clip.")]
	public class CutsceneWrapperNode : FlowNode {

		[RequiredField]
		public BBParameter<Cutscene> cutscene;

		private FlowOutput startFlow;
		private FlowOutput finishedFlow;
		private FlowOutput eventSend;

		private string eventName;
		private object eventValue;
		private Dictionary<string, FlowOutput> sections = new Dictionary<string, FlowOutput>();

		public override string name{
			get {return string.Format("Cutscene '{0}'", cutscene.ToString());}
		}

		protected override void RegisterPorts(){

			AddFlowInput("Play", Start);
			AddFlowInput("Stop", (f)=>{ if (cutscene.value != null) cutscene.value.Stop(); });
			AddFlowInput("Skip", (f)=>{ if (cutscene.value != null) cutscene.value.SkipCurrentSection(); });

			startFlow = AddFlowOutput("Start");

			if (cutscene.value != null){
				foreach(var section in cutscene.value.GetSections()){
					sections[section.UID] = AddFlowOutput(section.name, section.UID);
				}
			}

			finishedFlow = AddFlowOutput("Finish");

			eventSend = AddFlowOutput("On Cutscene Event");
			AddValueOutput("Event Name", ()=>{ return eventName; });
			AddValueOutput("Event Value", ()=>{ return eventValue; });
		}

		void Start(Flow f){
			if (cutscene.value != null && !cutscene.value.isActive){
				cutscene.value.OnSectionReached += OnSectionReached;
				cutscene.value.OnGlobalMessageSend += OnGlobalMessageSend;
				cutscene.value.Play(0, Finish);
				startFlow.Call(f);
			}
		}

		void Finish(){
			if (cutscene.value != null){
				cutscene.value.OnSectionReached -= OnSectionReached;
				cutscene.value.OnGlobalMessageSend -= OnGlobalMessageSend;
				finishedFlow.Call(new Flow());
			}
		}

		void OnSectionReached(SlateSection section){
			sections[section.UID].Call(new Flow());
		}

		void OnGlobalMessageSend(string name, object value){
			eventName = name;
			eventValue = value;
			eventSend.Call(new Flow());
		}



		////////////////////////////////////////
		///////////GUI AND EDITOR STUFF/////////
		////////////////////////////////////////
		#if UNITY_EDITOR
		
		protected override void OnNodeInspectorGUI(){
			base.OnNodeInspectorGUI();
			if (!cutscene.isNull && GUILayout.Button("Refresh")){
				GatherPorts();
			}
		}

		#endif
		
	}
}