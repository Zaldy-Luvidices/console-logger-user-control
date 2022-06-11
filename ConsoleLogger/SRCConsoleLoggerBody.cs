using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ConsoleLogger
{
    public partial class SRCConsoleLogger : UserControl
    {
        private void writeTimeStamp()
        {
            string text = DateTime.Now.ToString("[HH:mm:ss.fff]") + " ";
            if (hasTimeStamp)
            {
                text = customTimeStamp.ToString("[HH:mm:ss.fff]") + " ";
                hasTimeStamp = false;
            }
            int indStart = rtbConsole.Text.Length;
            rtbConsole.AppendText(text);
            writeLogFile(text);

            // apply formatting
            rtbConsole.SelectionStart = indStart;
            rtbConsole.SelectionLength = text.Length;
            rtbConsole.SelectionColor = TimeStampForeColor;
            rtbConsole.SelectionBackColor = TimeStampBackColor;
            rtbConsole.SelectionFont = TimeStampFont;

            scrollToEnd();
        }

        private void saveScrollData()
        {
            scIsFocused = rtbConsole.Focused;
            scSelStart = rtbConsole.SelectionStart;
            scSelLength = rtbConsole.SelectionLength;
            scAutoScroll = (scSelStart == rtbConsole.Text.Length);
            if (!scAutoScroll)
            {
                lblFocusPatcher.Focus();
                SendMessage(rtbConsole.Handle, EM_HIDESELECTION, 1, 0);
            }
        }

        private void restoreScrollData()
        {
            if (!scAutoScroll)
            {
                rtbConsole.SelectionStart = scSelStart;
                rtbConsole.SelectionLength = scSelLength;
                SendMessage(rtbConsole.Handle, EM_HIDESELECTION, 0, 0);
                if (scIsFocused) rtbConsole.Focus();
            }
        }

        private void writeLogFile(string log)
        {
            if (String.IsNullOrEmpty(this.SyncFilePath)) return;
            try
            {
                File.AppendAllText(this.SyncFilePath, log);
            }
            catch (Exception ex)
            {
                this.OnSyncFileError(ex.Message);
            }
        }

        private void scrollToEnd()
        {
            if (AutoScrollContent)
            {
                rtbConsole.SelectionStart = rtbConsole.TextLength;
                rtbConsole.ScrollToCaret();
            }
        }
    }
}
