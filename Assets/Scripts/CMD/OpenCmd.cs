using UnityEngine;
using System.Diagnostics;

public class OpenCmd : MonoBehaviour
{
    void Start()
    {
        OpenCommandPrompt();
    }

    public void OpenCommandPrompt()
    {
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",     
                UseShellExecute = true         
            };

            Process.Start(startInfo);
        }
        catch (System.Exception ex)
        {
            UnityEngine.Debug.LogError($"Failed to open CMD: {ex.Message}");
        }
    }
}
