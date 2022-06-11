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
        #region Added Properties

        [Browsable(true)]
        [Description("Indicates whether to automatically scroll contents to bottom after adding new log entry.")]
        public bool AutoScrollContent
        {
            get;
            set;
        }

        [Browsable(true)]
        [Description("Indicates whether to append newline character after each log entry.")]
        public bool InsertLineFeed
        {
            get;
            set;
        }

        [Browsable(true)]
        [Description("Indicates whether to pre-prend time stamp in each log entry.")]
        public bool AddTimeStamp
        {
            get;
            set;
        }

        [Browsable(true)]
        [Description("Indicates whether to wrap text in control.")]
        public bool WordWrap
        {
            get { return rtbConsole.WordWrap; }
            set { rtbConsole.WordWrap = value; }
        }

        [Browsable(true)]
        [Description("Time stamp foreground color.")]
        public Color TimeStampForeColor
        {
            get;
            set;
        }

        [Browsable(true)]
        [Description("Time stamp background color.")]
        public Color TimeStampBackColor
        {
            get;
            set;
        }

        [Browsable(true)]
        [Description("Time stamp font.")]
        public Font TimeStampFont
        {
            get;
            set;
        }

        [Browsable(true)]
        [Description("Separator string to be written between key and value log.")]
        public string KeyValueSeparator
        {
            get;
            set;
        }

        [Browsable(true)]
        [Description("Whether to remember control's last writing offset.")]
        public bool NoteWriteOffset
        {
            get;
            set;
        }

        [Browsable(true)]
        [Description("Padding between text content and borders.")]
        public Padding TextPadding
        {
            get { return this.Padding; }
            set { this.Padding = value; }
        }

        [Browsable(true)]
        [Description("Full path of the file associated with the logger.")]
        public string SyncFilePath
        {
            get;
            set;
        }
        
        #endregion

        #region Overriden Properties

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                rtbConsole.Font = value;
                TimeStampFont = value;
            }
        }

        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                rtbConsole.ForeColor = value;
            }
        }

        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                rtbConsole.BackColor = value;
            }
        }

        #endregion
    }
}
