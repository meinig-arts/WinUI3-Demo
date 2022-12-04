# WinUI3-Demo
Very simple sample of a WinUI 3 in Desktop app. Taken from windows.developer magazine 2021-09.

Takes a look at some technical details of WinUI 3 in Desktop apps.
* Shows that the current working directory and the current domain's base directory (where assemblies are loaded from) are different. While the former points to C:\Windows\SysWOW64, the latter points to the executable directory of the project.
* Shows that the app is not being restricted to sandboxing like a classical UWP app are: We are able to load another assembly from the file system and may inspect its types.

