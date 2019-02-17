using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefMultipleWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitializeChromium();
        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);

            var browser = new ChromiumWebBrowser("https://stackoverflow.com/questions/39032447/load-2-urls-at-the-same-time-in-different-instances-cefsharp");
            browser.Dock = DockStyle.Left;
            browser.Height = 400;
            browser.Width = 400;
            Controls.Add(browser);

            var browser2 = new ChromiumWebBrowser("https://github.com/cefsharp/CefSharp.MinimalExample/blob/master/CefSharp.MinimalExample.WinForms/Program.cs#L16");
            browser2.Dock = DockStyle.Left;
            browser2.Height = 400;
            browser2.Width = 400;
            Controls.Add(browser2);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
