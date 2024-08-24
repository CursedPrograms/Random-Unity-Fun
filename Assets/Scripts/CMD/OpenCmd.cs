using UnityEngine;
using System.Diagnostics;

public class OpenCmd : MonoBehaviour
{
    // This function will be called when you want to open CMD
    public void OpenCommandPrompt()
    {
        try
        {
            // Create a new process start info for CMD
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe", // Command to open CMD
                UseShellExecute = true // Use the OS shell to execute the command
            };

            // Start the process
            Process.Start(startInfo);
        }
        catch (System.Exception ex)
        {
            // Handle exceptions if needed
            UnityEngine.Debug.LogError($"Failed to open CMD: {ex.Message}");
        }
    }
}
