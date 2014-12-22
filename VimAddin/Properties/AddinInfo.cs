using System;
using Mono.Addins;
using Mono.Addins.Description;

[assembly:Addin (
	"VimAddin", 
	Namespace = "VimAddin",
	Version = "1.1.9"
)]

[assembly:AddinName ("VimAddin")]
[assembly:AddinCategory ("IDE extensions")]
[assembly:AddinDescription ("A fork of MonoDevelop vi modes. See https://github.com/alextsui05/VimAddin")]
[assembly:AddinAuthor ("atsui")]

[assembly:AddinDependency ("::MonoDevelop.Core", MonoDevelop.BuildInfo.Version)]
[assembly:AddinDependency ("::MonoDevelop.Ide", MonoDevelop.BuildInfo.Version)]
