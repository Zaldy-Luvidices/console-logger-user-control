using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleLogger
{
    public partial class SRCConsoleLogger : UserControl
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);

        // scrolling data
        private bool scIsFocused = false;
        private int scSelStart = -1;
        private int scSelLength = -1;
        private bool scAutoScroll = false;

        private int lastWriteOffset = 0;
        private bool hasTimeStamp = false;
        private DateTime customTimeStamp = DateTime.Now;

        private const int WM_USER = 0x400;
        private const int EM_HIDESELECTION = WM_USER + 63;

        public SRCConsoleLogger()
        {
            InitializeComponent();

            AutoScrollContent = true;
            InsertLineFeed = true;
            AddTimeStamp = true;
            WordWrap = false;
            NoteWriteOffset = false;
            TimeStampForeColor = rtbConsole.ForeColor;
            TimeStampBackColor = rtbConsole.BackColor;
            TimeStampFont = new Font(rtbConsole.Font, FontStyle.Bold);
            KeyValueSeparator = ": ";
            TextPadding = new Padding(2);
            SyncFilePath = "";
        }
    }
}
