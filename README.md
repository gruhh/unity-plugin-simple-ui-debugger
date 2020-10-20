# Simple UI Debugger for Unity

This is a simple UI Debugger connecting Unity Debug to a Text UI object, as an implementation of https://docs.unity3d.com/ScriptReference/Application-logMessageReceivedThreaded.html

This is a **DEVELOPMENT TOOL** and should not be used in production.

IMPORTANT: Debug.Log can impact performance, [read more](https://github.com/JetBrains/resharper-unity/wiki/Avoid-usage-of-Debug.Log-methods-in-performance-critical-context).

**Tested with:**

-   Unity 2020.1

## How to Install

-   Download the last plugin-simple-ui-debugger package on releases
-   Open your project in Unity
-   Click Assets/Import Package/Custom Package
-   Select the package you downloaded
-   Click Import

## How to Use

1. If you _don't have a Canvas object_ in your scene, create one;
2. Open the plugin prefabs folder: Plugins/Simple UI Debugger/Prefabs
3. Add the prefab "DebugPanel" inside (as a child) of the Canvas object, preferably as the last element.
