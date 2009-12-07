// JScript source code

//contains calls to silverlight.js, example below loads Page.xaml
function createSilverlight()
{
	Sys.Silverlight.createObjectEx({
		source: "FacebookSilverlight.xaml",
		parentElement: document.getElementById("SilverlightControlHost"),
		id: "SilverlightControl",
		properties: {
			width: "100%",
			height: "100%",
			version: "0.95",
			enableHtmlAccess: true
		},
		events: {}
	});
}
