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
using howto_listview_display_subitem_icons;

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

            lvwBooks.Groups.Add(new ListViewGroup("1", HorizontalAlignment.Left));
            lvwBooks.Groups.Add(new ListViewGroup("2", HorizontalAlignment.Left));
            lvwBooks.Groups.Add(new ListViewGroup("3", HorizontalAlignment.Left));
            // Start with the last View (Details) selected.
            lvwBooks.SmallImageList = Lol_heros;
            lvwBooks.ShowSubItemIcons(true);
            // Make the column headers.
            lvwBooks.MakeColumnHeaders(
                "Title", 55, HorizontalAlignment.Right,
                "URL", 55, HorizontalAlignment.Left,
                "ISBN", 55, HorizontalAlignment.Left,
                "Picture", 55, HorizontalAlignment.Left,
                "Pages", 55, HorizontalAlignment.Right);

            // Add data rows.
            lvwBooks.AddRow("", "", "", "", "");
            lvwBooks.AddRow("", "", "", "", "");
            lvwBooks.AddRow("", "", "", "", ""); // empty
            lvwBooks.AddRow("", "", "", "", "");
            lvwBooks.AddRow("", "", "", "", "");
            lvwBooks.AddRow("", "", "", "", ""); // empty

            int k = 0;
            // Add icons to the sub-items.
            for (int r = 0; r < lvwBooks.Items.Count; r++)
            {
                // Set the main item's image index.
                lvwBooks.Items[r].ImageIndex = r;
                lvwBooks.Items[r].Group = lvwBooks.Groups[k];
                // Set the sub-item indices.
                for (int c = 1; c < lvwBooks.Columns.Count; c++)
                {
                    lvwBooks.AddIconToSubitem(r, c, c);
                }

                if (r % 2 == 1) k++;
            }

        
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
            // Create an instance of the open file dialog box.
            FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();

            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                //string file = openFileDialog1.SelectedPath;
                try
                {
                    //string text = File.ReadAllText(file);
                    string path = openFileDialog1.SelectedPath;
                    tbResults.Text = path;
                }
                catch (IOException)
                {
                }
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
               // sw.WriteLine(@"E:");
                sw.WriteLine(@"cd C:\Program Files (x86)\GarenaLoLTW\GameData\Apps\LoLTW");
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


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox51_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.BackColor = pictureBox1.BackColor;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox105_Click(object sender, EventArgs e)
        {

        }

        private void lvwBooks_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvwBooks.SelectedItems[0] != null) MessageBox.Show(lvwBooks.SelectedItems[0].Group.ToString());

        }

        private void tbResults_TextChanged(object sender, EventArgs e)
        {

        }


 
    }
}
