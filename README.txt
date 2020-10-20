# UI DEBUGGER

This is a simple UI Debugger connecting Unity Debug to a Text UI object,
as an implementation of https://docs.unity3d.com/ScriptReference/Application-logMessageReceivedThreaded.html

This is a DEVELOPMENT TOOL and should not be used in production.

IMPORTANT: Debug.Log can impact performance, read more:
https://github.com/JetBrains/resharper-unity/wiki/Avoid-usage-of-Debug.Log-methods-in-performance-critical-context 


## HOW TO USE

1. If you don't have a Canvas object in your scene, create one;

2. Open the plugin prefabs folder: Plugins/Simple UI Debugger/Prefabs

3. Add the prefab "DebugPanel" inside (as a child) of the Canvas object, preferably as the last element.



