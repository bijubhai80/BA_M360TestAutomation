// -----------------------------------------------------------------------
// <copyright file="NotifyWindow.xaml.cs" company="Jardine Lloyd Thompson Group">
// Copyright 2013 Jardine Lloyd Thompson Group plc
// </copyright>
// -----------------------------------------------------------------------

namespace LogNotify
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Interop;

    /// <summary>
    /// A list of message types that can be used by NotifyWindow
    /// </summary>
    /// <history>SA 02/10/2013 - Initial Version</history>
    public enum MessageType
    {
        /// <summary>
        /// Message type
        /// </summary>
        Message,

        /// <summary>
        /// Title type
        /// </summary>
        Title,

        /// <summary>
        /// Header type
        /// </summary>
        Header,

        /// <summary>
        /// Error type
        /// </summary>
        Error,

        /// <summary>
        /// Warning type
        /// </summary>
        Warning
    }

    /// <summary>
    /// Class to provide a window for Log notifications whilst a test is ongoing
    /// </summary>
    public partial class NotifyWindow : Window
    {
        /// <summary>
        /// TO DO
        /// </summary>
        public const int WsExTransparent = 0x00000020;

        /// <summary>
        /// TO DO
        /// </summary>
        public const int GwlExstyle = -20;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotifyWindow"/> class.
        /// </summary>
        /// <history>SA 02/10/2013 - Initial Version</history>
        /// <history>SA 12/11/2013 - Added additional info to exception output</history>
        public NotifyWindow()
        {
            try
            {
                this.InitializeComponent();

                // Set location to bottom right - this includes a 25 pixel gap for displaying Fusion status info
                int taskBarHeight = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;
                this.Left = SystemParameters.PrimaryScreenWidth - this.Width;
                this.Top = SystemParameters.PrimaryScreenHeight - this.Height - taskBarHeight - 25;
                this.Height = this.Height;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in NotifyWindow Initialization - " + e.Message + Environment.NewLine + e.StackTrace);
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        /// <history>SA 02/10/2013 - Initial Version</history>
        public string Text
        {
            get
            {
                return this.textBlock1.Text;
            }

            set
            {
                this.textBlock1.Text = value + "\n" + this.textBlock1.Text;
            }
        }

        /// <summary>
        /// Sets the text on this control.
        /// ------- Title
        /// ------- Header
        /// Message ------
        /// </summary>
        /// <param name="value">The text.</param>
        /// <param name="type">Message type</param>
        /// <history>
        /// SA 02/10/2013 - Initial Version
        /// SA 11/10/2013 - Added try catch to prevent agent process being terminated by this window
        /// SA 11/11/2013 - Added stacktrace to exception output.
        /// SA 12/11/2013 - Added check for whether textblock1 is null or not
        /// </history>
        public void SetText(string value, MessageType type)
        {
            try
            {
                if (type == MessageType.Title)
                {
                    this.labelTitle.Content = value + "\n" + this.textBlock1.Text;
                }
                else if (type == MessageType.Header)
                {
                    this.labelHeader.Content = value + "\n" + this.textBlock1.Text;
                }
                else
                {
                    try
                    {
                        this.textBlock1.Text = value + "\n" + this.textBlock1.Text;
                    }
                    catch (Exception e)
                    {
                        if (this.textBlock1 == null)
                        {
                            Console.WriteLine("Exception in Notify.SetText - textBlock1 is null/not set to reference of an object!");
                        }
                        else
                        {
                            Console.WriteLine("Exception in Notify.SetText - " + e.Message + Environment.NewLine + e.StackTrace.ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in Notify.SetText - " + e.Message + Environment.NewLine + e.StackTrace.ToString());
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Window.SourceInitialized" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        /// <history>SA 02/10/2013 - Initial Version</history>
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            IntPtr windowHandle = new WindowInteropHelper(this).Handle;

            int extendedStyle = GetWindowLong(windowHandle, GwlExstyle);
            SetWindowLong(windowHandle, GwlExstyle, extendedStyle | WsExTransparent);
        }

        /// <summary>
        /// Changes an attribute of the specified window. 
        /// </summary>
        /// <param name="handleWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="index">The zero-based offset to the value to be set.</param>
        /// <param name="newStyle">The replacement value.</param>
        /// <returns>If the function succeeds, the return value is the previous value of the specified 32-bit integer.</returns>
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr handleWnd, int index, int newStyle);

        /// <summary>
        /// Retrieves information about the specified window. 
        /// </summary>
        /// <param name="handleWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="index">The zero-based offset to the value to be set.</param>
        /// <returns>If the function succeeds, the return value is the requested value.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr handleWnd, int index);
    }
}
