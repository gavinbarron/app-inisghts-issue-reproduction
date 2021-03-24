# Minimal repro of debugging issues with App Insights TraceListener

## Background

We have a .NET Framework 4.7.2 WebAPI project that we have been keeping our project with `Microsoft.ApplicationInsights` at v2.15.0 to avoid the issue with [System.Diagnostics.DiagnosticSource Causing Error Evaluating the function timedout](https://github.com/microsoft/ApplicationInsights-dotnet/issues/2161)  
When adding  Azure Key Vault + Microsoft.Configuration.ConfigurationBuilders.Azure the same behavior as the above issue was observed using Visual Studio 2019 Version 16.9.2 when attempting to start a debugging session.

To rule out other sources of the issue a new .NET Framework WebApi Project was created and the ApplicationInsights dependencies + the TraceListener package @v2.15.0 were added after verifying that the project worked with the Key Vault connection and could be debugged.  
After adding these dependenices the issue was again observed.
The Application Insights packages were then downgraded to see if a lower version combination could be found where debugging would launch as expected.

## Repo summary

This repo has three branches

* `main`: This shows the Azure Key Vault + Microsoft.Configuration.ConfigurationBuilders.Azure + Application Insights with TraceListener being able to launch a debugging session. It's not strictly necessary to have a Key Vault to connect to, having the app fail with the yellow screen of death is enough to demonstrate a successfully started debugging session.
* `bug/app-insights-2.3.0`: Using nuget package manager `Microsoft.ApplicationInsights` was upgraded to v 2.3.0, this fails to launch a debuggging session successfully and is the lowest version number to exhibit this behavior.
* `bug/app-insights-2.15.0`: Using nuget package manager `Microsoft.ApplicationInsights` was upgraded to v 2.15.0, this fails to launch a debuggging session successfully and is the version number that I observed this behavior.
* `feature/app-insights-2.15.0-no-trace`: Removed `Microsoft.ApplicationInsights.TraceListener` and upgraded `System.Diagnostics.DiagnosticSource` to 5.0.1 and Visual Studio is able to launch a debugging session.
