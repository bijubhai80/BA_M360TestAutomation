// -----------------------------------------------------------------------
// <copyright file="Log.cs" company="Jardine Lloyd Thompson Group">
// Copyright 2013 Jardine Lloyd Thompson Group plc
// </copyright>
// -----------------------------------------------------------------------

namespace Log
{
    using LogNotify;
    using M360TestAutomation.Tests;
    using System;
    using System.Diagnostics;
    using System.Threading;

    /// <summary>
    /// Logging Class for Fusion CodedUI tests
    /// </summary>
    public class Log
    {
        public static event EventHandler<string> WriteLogMessage;

        /// <summary>
        /// Initialize lock
        /// See http://stackoverflow.com/questions/2463822/threading-errors-with-application-loadcomponent-key-already-exists
        /// </summary>
        /// <history>SA 12/11/2013 - Initial Version</history>
        private static object initializeLock = new object();

        /// <summary>
        /// Notify window
        /// </summary>
        private static LogNotify.NotifyWindow logWindow;

        /// <summary>
        /// Folder depth
        /// </summary>
        private static int folderDepth = 0;

        /// <summary>
        /// Stopwatch for timing purposes
        /// </summary>
        /// <history>SA 26/07/2013 - Initial version.</history>
        private static Stopwatch stopWatch;

        /// <summary>
        /// Enumeration of various states to put stopwatch into.
        /// </summary>

        public enum StopWatchState
        {
            /// <summary>
            /// The 'Start' state of a stopwatch
            /// </summary>
            /// <history>SA 30/08/2013 - Initial Version</history>
            Start,

            /// <summary>
            /// The restart state of a stopwatch
            /// </summary>
            /// <history>SA 30/08/2013 - Initial Version</history>
            Restart,

            /// <summary>
            /// The stop state of a stopwatch
            /// </summary>
            /// <history>SA 30/08/2013 - Initial Version</history>
            Stop,

            /// <summary>
            /// The continue state of a stopwatch
            /// </summary>
            /// <history>SA 30/08/2013 - Initial Version</history>
            Continue
        }

        /// <summary>
        /// Gets or sets the folder depth.
        /// </summary>
        /// <value>
        /// The folder depth.
        /// </value>
        /// <history>SA 30/08/2013 - Initial Version</history>
        public static int FolderDepth
        {
            get { return Log.folderDepth; }
            set { Log.folderDepth = value; }
        }

        /// <summary>
        /// Gets a stopwatch for timing purposes
        /// </summary>
        /// <history>SA 26/07/2013 - Initial version.</history>
        public static Stopwatch StopWatch
        {
            get
            {
                if (stopWatch == null)
                {
                    Log.Message("Initialising Stopwatch");
                    stopWatch = new Stopwatch();
                }

                return stopWatch;
            }
        }

        /// <summary>
        /// Logs the elapsed time recorded on the stopwatch object.
        /// By default stopwatch will be reset each time this method is called although this
        /// behaviour can be changed to Continue or Stop if required.
        /// </summary>
        /// <param name="message">The message to write to the log.</param>
        /// <param name="stopwatchState">State of the stopwatch.</param>
        /// <history>SA 26/07/2013 - Initial version.</history>
        public static void ElapsedTime(string message = "Time Elapsed: {0}", StopWatchState stopwatchState = StopWatchState.Restart)
        {
            if (!message.Contains("{0}"))
            {
                message += " : {0}";
            }

            Log.Message(message, StopWatch.Elapsed);

            if (stopwatchState == StopWatchState.Restart)
            {
                StopWatch.Restart();
            }
            else if (stopwatchState == StopWatchState.Stop)
            {
                StopWatch.Stop();
            }
        }

        /// <summary>
        /// Writes the given message to the log
        /// </summary>
        /// <param name="message">Message text</param>
        /// <param name="type">Message type</param>
        /// <remarks>
        /// Currently using Console.Write however this is likely to change
        /// in the future.
        /// </remarks>
        /// <history>SA 14/06/2013 - Updated to maintain tabbing for multiline log messages</history>
        public static void Message(string message, MessageType type = MessageType.Message)
        {
            // Experimental but used to provide similar information to TestComplete execution panel
            Notify(message, type);

            string time = DateTime.Now.ToLongTimeString();
            string tabs = string.Empty;
            for (int i = 0; i < FolderDepth; i++)
            {
                tabs = tabs + "\t";
            }

            // Ensure tabbing is maintained
            message = message.Replace("\r\n", "\r\n" + "\t".PadLeft(time.Length) + tabs);

            tabs = time + "\t" + tabs;

            WriteMessage(tabs + message);
        }

        private static void WriteMessage(string message)
        {
            Console.WriteLine(message);
            WriteLogMessage?.Invoke(null, message);
            BaseTest.test.Info(message);
        }

        /// <summary>
        /// Writes the given message to the log
        /// </summary>
        /// <param name="message">Message text</param>
        /// <param name="args">Message parameters</param>
        /// <remarks>
        /// Allows a message to be passed in the format:
        /// Log.Message("This is the first: {0} parameter and this is the second {1} parameter, parameter1, parameter2);
        /// </remarks>
        /// <history>
        /// SA 14/06/2013 - Added overload to permit multi-paramert messages to be passed 
        /// to Message (as per Console.WriteLine)
        /// </history>
        public static void Message(string message, params object[] args)
        {
            message = string.Format(message, args);

            Message(message);
        }

        /// <summary>
        /// Writes the given error to the log
        /// </summary>
        /// <param name="message">Message text</param>
        /// <remarks>
        /// Currently using Console.Write however this is likely to change
        /// in the future.
        /// </remarks>
        /// <history>SA 14/06/2013 - Updated to maintain tabbing for multiline log messages</history>
        public static void Error(string message)
        {
            Log.Message("**********************ERROR OCCURRED*********************");
            Log.Message("ERROR: " + message);
            Log.Message("**************************************************************");
        }

        /// <summary>
        /// Writes the given error to the log
        /// </summary>
        /// <param name="message">Message text</param>
        /// <param name="args">Message parameters</param>
        /// <remarks>
        /// Allows a message to be passed in the format:
        /// Log.Message("This is the first: {0} parameter and this is the second {1} parameter, parameter1, parameter2);
        /// </remarks>
        /// <history>
        /// SA 14/06/2013 - Added overload to permit multi-paramert messages to be passed 
        /// to Message (as per Console.WriteLine)
        /// </history>
        public static void Error(string message, params object[] args)
        {
            message = string.Format(message, args);

            Log.Error(message);
        }

        /// <summary>
        /// Writes the given exception to the log
        /// </summary>
        /// <param name="message">Message text</param>
        /// <param name="exception">The exception</param>
        /// <remarks>
        /// Allows a message to be passed with the exception.
        /// </remarks>
        /// <history>
        /// SA 14/06/2013 - Added overload to permit multi-paramert messages to be passed 
        /// to Message (as per Console.WriteLine)
        /// </history>
        public static void Error(string message, Exception exception)
        {
            message = message + Environment.NewLine + exception.ToString();

            Log.Error(message);
        }

        /// <summary>
        /// Writes the given warning to the log
        /// </summary>
        /// <param name="message">Message text</param>
        /// <remarks>
        /// Currently using Console.Write however this is likely to change
        /// in the future.
        /// </remarks>
        /// <history>SA 14/06/2013 - Updated to maintain tabbing for multiline log messages</history>
        public static void Warning(string message)
        {
            Log.Message("**************************WARNING*************************");
            Log.Message("WARNING: " + message);
            Log.Message("**************************************************************");

        }

        /// <summary>
        /// Writes the given warning to the log
        /// </summary>
        /// <param name="message">Message text</param>
        /// <param name="args">Message parameters</param>
        /// <remarks>
        /// Allows a message to be passed in the format:
        /// Log.Message("This is the first: {0} parameter and this is the second {1} parameter, parameter1, parameter2);
        /// </remarks>
        /// <history>
        /// SA 14/06/2013 - Added overload to permit multi-paramert messages to be passed 
        /// to Message (as per Console.WriteLine)
        /// </history>
        public static void Warning(string message, params object[] args)
        {
            message = string.Format(message, args);

            Log.Warning(message);
        }

        /// <summary>
        /// Writes the given folder to the log
        /// </summary>
        /// <param name="folderName">Folder name</param>
        /// <remarks>
        /// Currently using Console.Write however this is likely to change
        /// in the future.
        /// </remarks>
        /// <history>SA 1/5/2013 - Initial Version</history>
        public static void AppendFolder(string folderName)
        {
            Notify(folderName, MessageType.Title);

            Log.Message(folderName);
            FolderDepth++;
        }

        /// <summary>
        /// Writes the given folder to the log
        /// </summary>
        /// <param name="folderName">Folder name</param>
        /// <param name="args">Folder parameters</param>
        /// <remarks>
        /// Currently using Console.Write however this is likely to change
        /// in the future.
        /// </remarks>
        /// <history>SA 1/5/2013 - Initial Version</history>
        public static void AppendFolder(string folderName, params object[] args)
        {
            AppendFolder(string.Format(folderName, args));
        }

        /// <summary>
        /// Writes the given folder to the log
        /// </summary>
        public static void PopLogFolder()
        {
            if (FolderDepth > 0)
            {
                --FolderDepth;
            }
        }

        /// <summary>
        /// Writes the given folder to the log
        /// </summary>
        /// <param name="message">Message text</param>
        /// <param name="args">Message parameters</param>
        /// <history>SA 1/5/2013 - Initial Version</history>
        public static void PopLogFolder(string message, params object[] args)
        {
            PopLogFolder(string.Format(message, args));
        }

        /// <summary>
        /// Writes the given folder to the log
        /// </summary>
        /// <param name="message">Message text</param>
        /// <history>SA 1/5/2013 - Initial Version</history>
        public static void PopLogFolder(string message)
        {
            Log.Message(message);

            if (FolderDepth > 0)
            {
                --FolderDepth;
            }
        }

        /// <summary>
        /// Displays a tooltip of the given message
        /// </summary>
        /// <param name="message">Message text</param>
        /// <param name="type">Message type</param>
        /// <history>SA 25/06/2013 - Initial version</history>
        /// <history>SA 04/10/2013 - Updated to use NotifyWindow and added try/catch</history>
        /// <history>SA 12/11/2013 - Check that logWindow is generated before continuing.</history>
        public static void Notify(string message, MessageType type)
        {
            try
            {
                // Added to prevent threading issues with WPF.
                lock (Log.initializeLock)
                {
                    if (logWindow == null)
                    {
                        Thread thread = new Thread(NotifyThreadStartingPoint);
                        thread.SetApartmentState(ApartmentState.STA);
                        thread.IsBackground = true;
                        thread.Start();

                        // Delay this thread to give time to logWindow to spool up
                        // If after 20 seconds it still isn't created then throw exception
                        Stopwatch watch = new Stopwatch();
                        watch.Start();
                        while (logWindow == null)
                        {
                            Thread.Sleep(250);
                            if (watch.ElapsedMilliseconds > 20000)
                            {
                                throw new TimeoutException("LogWindow has not instantiated.");
                            }
                        }

                        logWindow.Dispatcher.Invoke(new Action(() => { logWindow.SetText(message, type); }));
                    }
                    else
                    {
                        logWindow.Dispatcher.BeginInvoke(new Action(() => { logWindow.SetText(message, type); }));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// Inserts specified text between '*' symbols and write into log 
        /// </summary>
        /// <param name="headerText">Inserting text</param>
        /// <history>OL 17/02/2014 - Initial version</history>
        public static void AddHeader(string headerText = "")
        {
            Log.Message(GetHeader(headerText));
        }

        /// <summary>
        /// Inserts specified text between '*' symbols 
        /// </summary>
        /// <param name="headerText">Inserting text</param>
        /// <returns>Log splitter (?)</returns>
        /// <history>OL 17/02/2014 - Initial version</history>
        public static string GetHeader(string headerText = "")
        {
            string logSplitter = string.Empty;
            for (int i = 0; i < 100; i++)
            {
                logSplitter += "*";
            }

            if (headerText != string.Empty)
            {
                string newLogSplitter = logSplitter.Insert(logSplitter.Length / 2, " " + headerText + " ");

                while (newLogSplitter.Length > logSplitter.Length)
                {
                    newLogSplitter = newLogSplitter.Remove(newLogSplitter.IndexOf("*"), 1);
                    newLogSplitter = newLogSplitter.Remove(newLogSplitter.LastIndexOf("*"), 1);
                }

                return newLogSplitter;
            }
            else return logSplitter;
        }


        #region "Private Members"

        /// <summary>
        /// Starts the Notify Window
        /// </summary>
        /// <history>SA 16/10/2013 - Added try/catch</history>
        private static void NotifyThreadStartingPoint()
        {
            try
            {
                logWindow = new NotifyWindow();
                logWindow.Show();
                System.Windows.Threading.Dispatcher.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing to notify window: " + e.Message);
            }
        }
        #endregion //Private Methods
    }
}
