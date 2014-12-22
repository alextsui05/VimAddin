using System;

using MonoDevelop.Ide.Gui.Dialogs; // for OptionsPanel
using MonoDevelop.Core; // for PropertyService

namespace VimAddin
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class VimAddinOptionsPanelWidget : Gtk.Bin
	{
		public VimAddinOptionsPanelWidget ()
		{
			this.Build ();
			this.checkbutton1.Active = (bool)PropertyService.Get ("UseViModes", false);
		}

		public void Store()
		{
			PropertyService.Set ("UseViModes", this.checkbutton1.Active);
		}
	}

	public class VimAddinOptionsPanel : OptionsPanel
	{
		VimAddinOptionsPanelWidget w;
		public override Gtk.Widget CreatePanelWidget()
		{
			w = new VimAddinOptionsPanelWidget ();
			return w;
		}

		public override void ApplyChanges()
		{
			w.Store ();
		}
	}
}

