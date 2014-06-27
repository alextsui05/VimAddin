using System;
using MonoDevelop.Ide.Gui.Content;
using MonoDevelop.SourceEditor;
using MonoDevelop.Core;
using MonoDevelop.Ide;

namespace VimAddin
{
	public class VimTextEditorExtension : TextEditorExtension
	{
		bool isEnabled;

		public bool IsEnabled {
			get { return isEnabled; }
		}

		public VimTextEditorExtension ()
		{
			PropertyService.PropertyChanged += UpdatePreferences;
			isEnabled = PropertyService.Get("UseViModes", false);
		}

		public void UpdatePreferences( object sender, PropertyChangedEventArgs args )
		{
			isEnabled = PropertyService.Get("UseViModes", false);
			SetupMode ();
		}

		public void SetupMode( )
		{
			var doc = this.Document;
			var sourceEditorView = doc.GetContent<SourceEditorView> ();
			var textEditor = sourceEditorView.TextEditor;
			if (IsEnabled) {
				textEditor.CurrentMode = new VimAddin.IdeViMode (textEditor, doc);
				IdeApp.Workbench.StatusBar.ShowMessage ("VimAddin activated");
			} else {
				//Console.WriteLine ("Currently VimAddin is disabled");
				IdeApp.Workbench.StatusBar.ShowMessage ("VimAddin deactivated");
			}
		}

		public override void Initialize( )
		{
			base.Initialize ();
			Console.WriteLine ("VimAddin.VimTextEditorExtension.Initialize");
			SetupMode ();
		}

		public override void Dispose( )
		{
			PropertyService.PropertyChanged -= UpdatePreferences;
			base.Dispose ();
		}
	}
}
