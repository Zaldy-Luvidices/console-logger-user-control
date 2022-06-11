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
        public void ResetContent()
        {
            rtbConsole.Clear();
        }

        public string GetContent()
        {
            return rtbConsole.Text;
        }

        public int GetTotalContentLines()
        {
            int ret = rtbConsole.Lines.Length;
            if (rtbConsole.Text.EndsWith("\n")) ret--;
            return ret;
        }

        public void SetTimeStamp(DateTime timeStamp)
        {
            customTimeStamp = timeStamp;
            hasTimeStamp = true;
        }

        public void ResetToOffset()
        {
            if (!String.IsNullOrEmpty(rtbConsole.Text))
            {
                rtbConsole.SelectionStart = lastWriteOffset;
                rtbConsole.SelectionLength = rtbConsole.TextLength - lastWriteOffset;
                rtbConsole.ReadOnly = false;
                rtbConsole.Cut();
                rtbConsole.ReadOnly = true;
            }         
        }

        public bool SetSelection(int offset, int len)
        {
            try
            {
                rtbConsole.SelectionStart = offset;
                rtbConsole.SelectionLength = len;
                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return false;
            }
        }

        public void ExportContent(string outputPath, bool formatted = true)
        {
            rtbConsole.SaveFile(outputPath,
                formatted ? RichTextBoxStreamType.RichText : RichTextBoxStreamType.PlainText);
        }

        #region General Logs

        public void WriteLogNormal(string text, bool bold = false)
        {
            WriteLog(text, this.ForeColor, this.BackColor, bold);
        }

        public void WriteLogWarning(string text, bool bold = false)
        {
            WriteLog(text, Color.Orange, this.BackColor, bold);
        }

        public void WriteLogError(string text, bool bold = false)
        {
            WriteLog(text, Color.Red, this.BackColor, bold);
        }

        public void WriteLogInformation(string text, bool bold = false)
        {
            WriteLog(text, Color.Cyan, this.BackColor, bold);
        }

        public void WriteLog(string text, Color foreColor, Color backColor, bool bold = false)
        { // log text with no time stamp
            if (NoteWriteOffset) lastWriteOffset = rtbConsole.TextLength;

            if (!AutoScrollContent) saveScrollData();
            if (AddTimeStamp) writeTimeStamp();

            int indStart = rtbConsole.Text.Length;
            rtbConsole.AppendText(text);
            writeLogFile(text);
            // apply formatting
            rtbConsole.SelectionStart = indStart;
            rtbConsole.SelectionLength = text.Length;
            rtbConsole.SelectionColor = foreColor;
            rtbConsole.SelectionBackColor = backColor;
            rtbConsole.SelectionFont = new Font(rtbConsole.Font, (bold ? FontStyle.Bold : FontStyle.Regular));

            if (InsertLineFeed)
            {
                rtbConsole.AppendText(Environment.NewLine);
                writeLogFile(Environment.NewLine);
            }

            if (!AutoScrollContent) restoreScrollData();
            scrollToEnd();
        }

        #endregion

        #region Key-Value Logs

        public void WriteKeyValue(string key, string value, bool isKeyBold = true, bool isValueBold = false)
        {
            WriteKeyValue(key, value, ForeColor, BackColor, ForeColor, BackColor, isKeyBold, isValueBold);
        }

        public void WriteKeyValue(string key, string value, Color keyForeColor, Color keyBackColor,
            bool isKeyBold = true, bool isValueBold = false)
        {
            WriteKeyValue(key, value, keyForeColor, keyBackColor, ForeColor, BackColor, isKeyBold, isValueBold);
        }

        public void WriteKeyValue(string key, string value, Color keyForeColor, Color keyBackColor,
            Color valueForeColor, Color valueBackColor, bool isKeyBold = true, bool isValueBold = false)
        {
            if (NoteWriteOffset) lastWriteOffset = rtbConsole.TextLength;

            if (!AutoScrollContent) saveScrollData();
            if (AddTimeStamp) writeTimeStamp();
            
            // write key
            int indStart = rtbConsole.Text.Length;
            rtbConsole.AppendText(key);
            writeLogFile(key);
            // apply formatting
            rtbConsole.SelectionStart = indStart;
            rtbConsole.SelectionLength = key.Length;
            rtbConsole.SelectionColor = keyForeColor;
            rtbConsole.SelectionBackColor = keyBackColor;
            rtbConsole.SelectionFont = new Font(rtbConsole.Font, (isKeyBold ? FontStyle.Bold : FontStyle.Regular));
            
            // write separator
            indStart = rtbConsole.Text.Length;
            rtbConsole.AppendText(KeyValueSeparator);
            writeLogFile(KeyValueSeparator);
            // apply formatting
            rtbConsole.SelectionStart = indStart;
            rtbConsole.SelectionLength = KeyValueSeparator.Length;
            rtbConsole.SelectionColor = ForeColor;
            rtbConsole.SelectionBackColor = BackColor;

            // write value
            indStart = rtbConsole.Text.Length;
            rtbConsole.AppendText(value);
            writeLogFile(value);
            // apply formatting
            rtbConsole.SelectionStart = indStart;
            rtbConsole.SelectionLength = value.Length;
            rtbConsole.SelectionColor = valueForeColor;
            rtbConsole.SelectionBackColor = valueBackColor;
            rtbConsole.SelectionFont = new Font(rtbConsole.Font, (isValueBold ? FontStyle.Bold : FontStyle.Regular));

            if (InsertLineFeed)
            {
                rtbConsole.AppendText(Environment.NewLine);
                writeLogFile(Environment.NewLine);
            }
            if (!AutoScrollContent) restoreScrollData();
            scrollToEnd();
        }

        #endregion
    }
}
