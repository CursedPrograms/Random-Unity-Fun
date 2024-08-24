using UnityEngine;
using System.Diagnostics;

public class ExecuteCmd : MonoBehaviour
{
    public string command = "echo Hello, World!";

    public void ExecuteCommand()
    {
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",     
                Arguments = $"/C {command}",           
                RedirectStandardOutput = true,       
                RedirectStandardError = true,        
                UseShellExecute = false,    
                CreateNoWindow = true      
            };

            Process process = new Process
            {
                StartInfo = startInfo
            };

            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string errorOutput = process.StandardError.ReadToEnd();
            process.WaitForExit();

            UnityEngine.Debug.Log($"Command Output: {output}");
            if (!string.IsNullOrEmpty(errorOutput))
            {
                UnityEngine.Debug.LogError($"Command Error: {errorOutput}");
            }
        }
        catch (System.Exception ex)
        {
            UnityEngine.Debug.LogError($"Failed to execute CMD command: {ex.Message}");
        }
    }
}
