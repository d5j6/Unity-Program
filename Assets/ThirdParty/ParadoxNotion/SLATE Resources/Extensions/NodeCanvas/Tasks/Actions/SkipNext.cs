using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Cutscene = Slate.Cutscene;

namespace NodeCanvas.Tasks.Slate
{

    [Category("SLATE")]
	[Icon("SLATE")]
	[Description("Skip the cutscene to the next section immediately")]
	public class SkipNext : ActionTask{

		[RequiredField]
		public BBParameter<Cutscene> cutscene;

		protected override void OnExecute(){
			cutscene.value.SkipCurrentSection();
			EndAction();
		}
	}
}