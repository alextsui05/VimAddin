using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;

using MonoDevelop.Ide.Gui.Dialogs; // for OptionsPanel
using MonoDevelop.Core; // for PropertyService

using Mono.Addins;

namespace VimAddin
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class VimAddinOptionsPanelWidget : Gtk.Bin
	{
		public VimAddinOptionsPanelWidget ()
		{
			this.Build ();
			Assembly assembly = Assembly.GetExecutingAssembly ();
			AddinAttribute addinAttr = assembly.GetCustomAttribute<AddinAttribute> ();
			string labelText = String.Format ("VimAddin version {0}",
				                   addinAttr.Version);
			this.label1.Text = labelText;
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

