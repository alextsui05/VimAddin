
// This file has been generated by the GUI designer. Do not modify.
namespace VimAddin
{
	public partial class VimAddinOptionsPanelWidget
	{
		private global::Gtk.Fixed fixed1;
		
		private global::Gtk.CheckButton checkbutton1;
		
		private global::Gtk.Label label1;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget VimAddin.VimAddinOptionsPanelWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "VimAddin.VimAddinOptionsPanelWidget";
			// Container child VimAddin.VimAddinOptionsPanelWidget.Gtk.Container+ContainerChild
			this.fixed1 = new global::Gtk.Fixed ();
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.checkbutton1 = new global::Gtk.CheckButton ();
			this.checkbutton1.CanFocus = true;
			this.checkbutton1.Name = "checkbutton1";
			this.checkbutton1.Label = global::Mono.Unix.Catalog.GetString ("Use vi modes");
			this.checkbutton1.Active = true;
			this.checkbutton1.DrawIndicator = true;
			this.checkbutton1.UseUnderline = true;
			this.fixed1.Add (this.checkbutton1);
			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.checkbutton1]));
			w1.X = 14;
			w1.Y = 41;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("label1");
			this.fixed1.Add (this.label1);
			global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.label1]));
			w2.X = 13;
			w2.Y = 10;
			this.Add (this.fixed1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}