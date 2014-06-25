using System;
using MonoDevelop.Ide.Gui.Content;
using MonoDevelop.SourceEditor;

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
			var doc = this.Document;
			var sourceEditorView = doc.GetContent<SourceEditorView> ();
			var textEditor = sourceEditorView.TextEditor;
			textEditor.CurrentMode = new VimAddin.IdeViMode (textEditor, doc);
		}
	}
}
