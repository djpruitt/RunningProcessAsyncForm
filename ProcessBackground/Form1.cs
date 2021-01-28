using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProcessBackground
{
    public partial class Form1 : Form
    {
        public delegate void SafeCallDelegate(string text);

        public SafeCallDelegate myDelegate;

        public Form1()
        {
            InitializeComponent();


            myDelegate = new SafeCallDelegate(WriteTextThreadSafe);
        }

        private void RunProcessAsync_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                var worker = new BackgroundWorker();
                worker.WorkerReportsProgress = false;
                worker.WorkerSupportsCancellation = false;
                worker.DoWork += worker_DoWork;
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                worker.RunWorkerAsync();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.RunProcess();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.WriteTextThreadSafe("process complete");
        }

        private void RunProcess()
        {
            using (Process process = new Process())
            {
                var processInfo = new ProcessStartInfo("cmd.exe", $"/c timeout 5 & echo 1 & echo 2 &  timeout 5 & echo 3 & echo 4 &  timeout 6");
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                processInfo.RedirectStandardError = true;
                processInfo.RedirectStandardOutput = true;

                process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
                process.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);

                process.StartInfo = processInfo;
                process.Start();

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                process.WaitForExit();

                process.Close();
            }
        }

        void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {

            this.WriteTextThreadSafe(outLine.Data);
        }

        private void WriteTextThreadSafe(string text)
        {
            this.BeginInvoke(
                ((MethodInvoker)delegate
            {
                this.textOutput.Text += text + Environment.NewLine;
            }));
        }
    }
}
