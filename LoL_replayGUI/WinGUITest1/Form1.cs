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
using System.IO;
using System.Threading;

namespace WinGUITest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e) //play video
        {
            Thread sample = new Thread(startLoLReplay);
            sample.Start();
            Thread.Sleep(1000 * 20);
            Process[] pArr = new Process[20];
            pArr = Process.GetProcessesByName("League of Legends");
            MessageBox.Show(pArr.Length.ToString());
            while (pArr.Length > 0) {
                pArr = Process.GetProcessesByName("League of Legends");
            };
            sample.Abort();
            MessageBox.Show("abort LoL replay thread");
            pArr = Process.GetProcessesByName("launcher");
            MessageBox.Show(pArr.Length.ToString()+" exe files");
            for(int i = 0 ; i < pArr.Length ; i++){
                pArr[i].Kill();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // get LoL Replay Application
            /*Process[] pArr = new Process[20];
            pArr = Process.GetProcessesByName("League of Legends");
            MessageBox.Show(pArr.Length.ToString());*/
            Process[] pArr = new Process[20];
            pArr = Process.GetProcessesByName("launcher");
            MessageBox.Show(pArr.Length.ToString() + " exe files");
            for (int i = 0; i < pArr.Length; i++)
            {
                pArr[i].Kill();
            }
        }

        void startLoLReplay() {
            Process p = new Process();
            // FileName 是要執行的檔案
            //playprocess.StartInfo.FileName = @"C:\Users\Blurry\Desktop\testscript.sh";
            //playprocess.Start();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true; //不跳出cmd視窗
            string strOutput = null;

            try
            {
                p.Start();
                StreamWriter sw = p.StandardInput;
                //sw.WriteLine("dir /w");
                sw.WriteLine(@"E:");
                sw.WriteLine(@"cd E:\GarenaLoLTW\GameData\Apps\LoLTW");
                sw.WriteLine(@"launcher.exe -f 1_1868885635.ob");
                p.StandardInput.WriteLine("exit");
                strOutput = p.StandardOutput.ReadToEnd();//匯出整個執行過程
                MessageBox.Show(strOutput);
                p.WaitForExit();
                p.Close();
                

            }
            catch (Exception ex)
            {
                strOutput = ex.Message;
            }
        
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
