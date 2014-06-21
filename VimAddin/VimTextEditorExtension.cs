using System;
using MonoDevelop.Ide.Gui.Content;

namespace VimAddin
{
	public class VimTextEditorExtension : TextEditorExtension
	{
		public VimTextEditorExtension ()
		{

		}

		public override void Initialize( )
		{
			base.Initialize ();
			Console.WriteLine ("VimAddin.VimTextEditorExtension.Initialize");
		}
	}
}
