using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Video
{
    public partial class Form1 : Form
    {
        private string[] shell;
        private int length;
        public Form1()
        {
            InitializeComponent();
        }
        private void Render()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("ffmpeg -i \"" + listBox1.Items[0] + "\" tmp.mp4");
            //cmd.StandardInput.Flush();
            //cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            for (int x = 1; x < length; x++) {
                
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult file = openFileDialog1.ShowDialog();
            if (file == DialogResult.OK) // Test result.
            {
                string filename = openFileDialog1.FileName;
                listBox1.Items.Add(filename);
                
            }
        }
        private void RenderButton_Click(object sender, EventArgs e)
        {
            Render();
        }
    }
}
