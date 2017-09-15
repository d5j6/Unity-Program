﻿using UnityEngine;
using ParadoxNotion;
using ParadoxNotion.Design;
using NodeCanvas.Framework;

namespace FlowCanvas.Nodes{

	[DoNotList]
	///Wraps a SimplexNode
	public class SimplexNodeWrapper<T> : FlowNode where T:SimplexNode {

		private T _simplexNode;
		private T simplexNode{
			get
			{
				if (_simplexNode == null){
					_simplexNode = (T)System.Activator.CreateInstance(typeof(T));
					if (_simplexNode != null){
						base.GatherPorts();
					}
				}
				return _simplexNode;
			}
		}

		public override string name{
			get {return simplexNode != null? simplexNode.name : "NULL";}
		}

		public override string description{
			get {return simplexNode != null? simplexNode.description : "NULL";}
		}

		public override void OnGraphStarted(){
			if (simplexNode != null){
				simplexNode.OnGraphStarted();
			}
		}

		public override void OnGraphPaused(){
			if (simplexNode != null){
				simplexNode.OnGraphPaused();
			}
		}

		public override void OnGraphUnpaused(){
			if (simplexNode != null){
				simplexNode.OnGraphUnpaused();
			}			
		}

		public override void OnGraphStoped(){
			if (simplexNode != null){
				simplexNode.OnGraphStoped();
			}
		}

		protected override void RegisterPorts(){
			if (simplexNode != null){
				simplexNode.RegisterPorts(this);
			}
		}


		////////////////////////////////////////
		///////////GUI AND EDITOR STUFF/////////
		////////////////////////////////////////
		#if UNITY_EDITOR
			
		//Override of right click node context menu for ability to change type
		protected override UnityEditor.GenericMenu OnContextMenu(UnityEditor.GenericMenu menu){
			
			base.OnContextMenu(menu);
			if (simplexNode == null){
				return menu;
			}

			var type = simplexNode.GetType();
			if (type.IsGenericType){
				var infos = EditorUtils.GetScriptInfosOfType( type.GetGenericTypeDefinition() );
				foreach(var _info in infos){
					var info = _info;
					menu.AddItem(new GUIContent("Change Type/" + info.name), false, ()=>
					{
						var newType = typeof(SimplexNodeWrapper<>).MakeGenericType(new System.Type[]{info.type});
						var newNode = ReplaceWith(newType);
						newNode.GatherPorts();
					});
				}
			}

			return menu;
		}		

		#endif
		
	}
}