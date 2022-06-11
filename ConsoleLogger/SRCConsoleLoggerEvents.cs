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
    // delegates
    public delegate void SyncFileErrorEventHandler(object sender, string message);

    public partial class SRCConsoleLogger : UserControl
    {
        // events
        [Description("Occurs when an error was encountered while reading/writing to sync file.")]
        public event SyncFileErrorEventHandler SyncFileError;

        // mappers
        protected virtual void OnSyncFileError(string message)
        {
            if (SyncFileError != null) SyncFileError(this, message);
        }
    }
}
