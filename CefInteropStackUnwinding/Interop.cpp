#include "pch.h"
#include "CefProxy.h"
extern "C"
{
void InitializeCef()
{
	// init handler storage
	struct sigaction* dotnet_sigs = new struct sigaction[31];
	struct sigaction* cef_sigs = new struct sigaction[31];
	// store dotnet handlers
	for(int i=0; i<31; i++)
	{
		memset(&dotnet_sigs[i], 0, sizeof(dotnet_sigs[i]));
		memset(&cef_sigs[i], 0, sizeof(cef_sigs[i]));
		sigaction(i, 0, &dotnet_sigs[i]);
	}
	// get current dir
	char buff[FILENAME_MAX]; //create string buffer to hold path
	getcwd(buff, FILENAME_MAX);
	string dir = std::string(buff);
	// determine locales path
	std::stringstream locales_stream;
	locales_stream << dir.c_str() << "/resources";
	// determine subprocess path
	std::stringstream subprocess_stream;
	subprocess_stream << dir.c_str() << "/Cefsubprocess";
	// apply settigs
	CefMainArgs args;
	CefSettings cef_settings;
	cef_settings.windowless_rendering_enabled = true;
	cef_settings.multi_threaded_message_loop = true;
	cef_settings.no_sandbox = true;
	CefString(&cef_settings.locales_dir_path).FromString(locales_stream.str().c_str());
	CefString(&cef_settings.resources_dir_path).FromString(dir.c_str());
	CefString(&cef_settings.browser_subprocess_path).FromString(subprocess_stream.str().c_str());
	CefString(&cef_settings.cache_path).FromASCII("");
	CefString(&cef_settings.root_cache_path).FromASCII("");
	// initialize!
	CefProxy proxy;
    CefInitialize(args, cef_settings, &proxy, NULL);
	// restore dotnet handlers (and store cef handlers)
	for (int i = 0; i < 31; i++)
	{
		sigaction(i, &dotnet_sigs[i], &cef_sigs[i]);
	}
}
}