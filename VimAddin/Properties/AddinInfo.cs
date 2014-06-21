using System;
using Mono.Addins;
using Mono.Addins.Description;

[assembly:Addin (
	"VimAddin", 
	Namespace = "VimAddin",
	Version = "1.0"
)]

[assembly:AddinName ("VimAddin")]
[assembly:AddinCategory ("IDE extensions")]
[assembly:AddinDescription ("A fork of the core vi modes in MonoDevelop.")]
[assembly:AddinAuthor ("atsui")]

[assembly:AddinDependency ("::MonoDevelop.Core", MonoDevelop.BuildInfo.Version)]
[assembly:AddinDependency ("::MonoDevelop.Ide", MonoDevelop.BuildInfo.Version)]
