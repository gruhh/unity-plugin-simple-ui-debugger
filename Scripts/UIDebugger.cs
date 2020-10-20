using System;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a simple UI Debugger connecting Unity Debug to a Text UI object,
/// as an implementation of https://docs.unity3d.com/ScriptReference/Application-logMessageReceivedThreaded.html
///
/// This is a DEVELOPMENT TOOL and should not be used in production.
///
/// IMPORTANT: Debug.Log can impact performance, read more:
/// https://github.com/JetBrains/resharper-unity/wiki/Avoid-usage-of-Debug.Log-methods-in-performance-critical-context 
/// </summary>
public class UIDebugger : MonoBehaviour
{
    private Text _text;
    private Button _closeButton;
    private RectTransform _debugPanel;
    
    private StringBuilder _builder;
    private string _typeToLog;
    
    [Min(1)]
    public int numberOfLines = 10;

    private void OnValidate()
    {
        if (numberOfLines < 1)
        {
            numberOfLines = 1;
        }
    }

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
        _closeButton = GetComponentInChildren<Button>();
        _debugPanel = GetComponentInParent<RectTransform>();
        _builder = new StringBuilder();
        
        _closeButton.onClick.AddListener(() =>
        {
            int y = (int) _debugPanel.sizeDelta.y;
            _debugPanel.sizeDelta = y == 100 ? new Vector2(0, 500) : new Vector2(0, 100);
        });
    }

    private void OnEnable()
    {
        Application.logMessageReceivedThreaded += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceivedThreaded -= HandleLog;
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Error)
            _typeToLog = $"<color=red>{type}</color>";
        else if (type == LogType.Warning)
            _typeToLog = $"<color=yellow>{type}</color>";
        else
            _typeToLog = type.ToString();
        
        _builder.Insert(0, $"<b>{_typeToLog}</b> | {DateTime.Now:HH:mm:ss} | {logString}\n");

        _text.text = _builder.ToString();
        
        if (Regex.Matches(_builder.ToString(), "\n").Count > numberOfLines)
            _builder.Clear();
    }
}
