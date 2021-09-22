// -----------------------------------------------------------------------
// <copyright file="Processes.cs" company="Jardine Lloyd Thompson Group">
// Copyright 2013 Jardine Lloyd Thompson Group plc
// </copyright>
// -----------------------------------------------------------------------

namespace Processes
{
    using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.Management;
    using System.Runtime.InteropServices;
    using System.Threading;
    using ConnectionOptions = System.Management.ConnectionOptions;

    /// <summary>
    /// Processes class
    /// </summary>
    public class Processes
    {
        /// <summary>
        /// Checks if specified process exists
        /// </summary>
        /// <param name="processName">Process name</param>
        /// <returns>True - if process exists, false - otherwise</returns>
        /// <history>
        /// OL 25/06/2013 - Initial version
        /// </history>
        public static bool CheckProcessExist(string processName)
        {
            Process[] process = Process.GetProcessesByName(processName);
            if ((process != null) && (process.Length > 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets 'User Objects' value for the all processes
        /// </summary>
        /// <returns>Sum of 'User Objects' values</returns>
        /// <history>OL 10/04/2014 - Initial version</history>
        public static int GetUserObjects()
        {
            Process[] processes = Process.GetProcesses();
            int userObjects = 0;

            for (int i = 0; i < processes.Length; i++)
            {
                try
                {
                    userObjects = userObjects + GetGuiResources(processes[i].Handle, 1);
                }
                catch (System.ComponentModel.Win32Exception)
                {
                }
            }

            return userObjects;
        }

        /// <summary>
        /// Checks that specified process is not running
        /// </summary>
        /// <param name="processName">Process name</param>
        /// <returns>True - if process is not running, false - otherwise</returns>
        /// <history>
        /// OL 25/06/2013 - Initial version
        /// </history>
        public static bool IsNotProcessExist(string processName)
        {
            for (int i = 0; i < 10; i++)
            {
                if (!CheckProcessExist(processName))
                {
                    Log.Log.Message("'" + processName + "' process doesn't exist");
                    return true;
                }

                Thread.Sleep(1000);
            }

            Log.Log.Error("Error: '" + processName + "' process exists!");
            KillApplicationProcesses(processName);
            return false;
        }

        /// <summary>
        /// Checks if specified process is running
        /// </summary>
        /// <param name="processName">Process name</param>
        /// <param name="timeout">Wait timeout (number of seconds)</param>
        /// <returns>True - if process is running, false - otherwise</returns>
        /// <history>VV 29/04/2014 - Added timeout parameter</history>
        public static bool IsProcessExist(string processName, int timeout = 10)
        {
            for (int i = 0; i < timeout; i++)
            {
                if (CheckProcessExist(processName))
                {
                    Log.Log.Message("'" + processName + "' process exists");
                    return true;
                }

                Thread.Sleep(1000);
            }

            Log.Log.Message("Error: '" + processName + "' process doesn't exist!");
            return false;
        }

        /// <summary>
        /// Kills all specified and currently running processes
        /// </summary>
        /// <history>
        /// JS 20/9/2017 - Removed case sensitive comparision
        /// </history>
        public static void KillApplicationProcesses()
        {
            string[] arrProcesses = { "WinAppDriver", "JBS", "WINWORD", "AcroRd32", "EXCEL"};


            foreach (string process in arrProcesses)
            {
                KillApplicationProcesses(process);
            }            

            ////KillHangingApps();
        }

        /// <summary>
        /// Kills the given process name
        /// </summary>
        /// <param name="name">Process name</param>
        public static void KillApplicationProcesses(string name)
        {
            Log.Log.Message("Kill process " + name);

            foreach (Process p in Process.GetProcessesByName(name))
            {  try
                {
                    p.Kill();
                    p.WaitForExit(); // possibly with a timeout             
                }
                catch(Exception e)
                {

                }
            }
        }

        public static void StartWinAppDriver (string workingDir)
        {
            Process process = new Process();
            process.StartInfo.FileName = "WinAppDriver.exe";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            process.StartInfo.WorkingDirectory = workingDir;
            process.Start();
        }

        /// <summary>
        /// Gets 'User Objects' value for the given process
        /// </summary>
        /// <param name="handleProcess">Native Handle of the process</param>
        /// <param name="userInterfaceFlags">Integer flag</param>
        /// <returns>User Objects value</returns>
        /// <history>OL 10/04/2014 - Initial version</history>
        [DllImport("User32")]
        private static extern int GetGuiResources(IntPtr handleProcess, int userInterfaceFlags);
    }
}
