using System;
using MonoDevelop.Ide.Gui.Content;
using MonoDevelop.SourceEditor;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Components.Commands;
using Mono.TextEditor;

namespace VimAddin
{
	public enum VimAddinCommands
	{
		PageDown,
	}

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

	public class NullHandler : CommandHandler
	{
		protected bool VimAddinIsEnabled()
		{
			MonoDevelop.Ide.Gui.Document doc = IdeApp.Workbench.ActiveDocument;
			if (doc != null && doc.GetContent<ITextEditorDataProvider> () != null)
			{
				var editorView = doc.GetContent<SourceEditorView> ();
				var textEditor = editorView.TextEditor;
				return textEditor.CurrentMode.GetType () == typeof(VimAddin.IdeViMode);
			}
			return false;
		}

		protected override void Run()
		{
			MonoDevelop.Ide.Gui.Document doc = IdeApp.Workbench.ActiveDocument;

			var textEditorData = doc.GetContent<ITextEditorDataProvider> ().GetTextEditorData ();
			var editorView = doc.GetContent<SourceEditorView> ();
			if (textEditorData.GetType () == typeof(TextEditorData)) {
				Console.WriteLine ("textEditorData is the expected type");
			}

			var textEditor = editorView.TextEditor;
//			textEditor.CurrentMode.InternalHandleKeypress (textEditor, textEditorData,
//				Gdk.Key.f,
//				(char)'f',
//				Gdk.ModifierType.ControlMask);
			var vimEditor = (VimAddin.IdeViMode) textEditorData.CurrentMode;
			if (vimEditor.HasTextEditorData ()) {
				Console.WriteLine ("Has textEditorData");
			} else {
				Console.WriteLine ("Has no textEditorData");
			}
			if (vimEditor.HasData ()) {
				vimEditor.SendKeys (Gdk.Key.f, 'f', Gdk.ModifierType.ControlMask);
			} else {
				Console.WriteLine ("Data is null");
				Console.WriteLine(vimEditor.ToString ());
			}
			if (textEditorData == null) {
				Console.WriteLine ("textEditorData is null");
			} else {
				Console.WriteLine ("textEditorData is not null");
			}
			vimEditor.InternalHandleKeypress (null, textEditorData, Gdk.Key.d, (uint)'d', Gdk.ModifierType.ControlMask);
		}

		protected override void Update (CommandInfo info)
		{
//			Console.WriteLine ("Update");
//			MonoDevelop.Ide.Gui.Document doc = IdeApp.Workbench.ActiveDocument;
//			info.Enabled = doc != null && doc.GetContent<ITextEditorDataProvider> () != null;
//			if (info.Enabled) {
//				var editorView = doc.GetContent<SourceEditorView> ();
//				var textEditor = editorView.TextEditor;
//				info.Enabled = textEditor.CurrentMode.GetType () == typeof(VimAddin.IdeViMode);
//				Console.WriteLine (info.Enabled);
//			}
			info.Enabled = VimAddinIsEnabled ();
		}
	}
}
