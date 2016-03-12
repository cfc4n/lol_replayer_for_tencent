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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

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

            #region ListViewLeft
            lvwBooks.Groups.Add(new ListViewGroup("1", HorizontalAlignment.Left));
            lvwBooks.Groups.Add(new ListViewGroup("2", HorizontalAlignment.Left));
            lvwBooks.Groups.Add(new ListViewGroup("3", HorizontalAlignment.Left));
            // Start with the last View (Details) selected.
            lvwBooks.SmallImageList = Lol_heros;
            lvwBooks.ShowSubItemIcons(true);
            // Make the column headers.
            lvwBooks.MakeColumnHeaders(
                "Hero1", 55, HorizontalAlignment.Right,
                "Hero2", 55, HorizontalAlignment.Left,
                "Hero3", 55, HorizontalAlignment.Left,
                "Hero4", 55, HorizontalAlignment.Left,
                "Hero5", 55, HorizontalAlignment.Right);

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
                lvwBooks.Items[r].ImageKey = "Annie.png";
                lvwBooks.Items[r].Group = lvwBooks.Groups[k];
                // Set the sub-item indices.
                for (int c = 1; c < lvwBooks.Columns.Count; c++)
                {
                    lvwBooks.AddIconToSubitem(r, c, c);
                }

                if (r % 2 == 1) k++;
            }
            #endregion



#region ListViewRight


            ControlTrans(ListViewRight, ListViewRight.BackgroundImage);
            ListViewRight.SmallImageList = Lol_heros;
            ListViewRight.ShowSubItemIcons(true);
            // Make the column headers.

            // header, 設定欄位
            ListViewRight.MakeColumnHeaders(
                "Empty", 15, HorizontalAlignment.Right,
                "HeroPic", 50, HorizontalAlignment.Right,
                "Level", 30, HorizontalAlignment.Center,
                "Name", 138, HorizontalAlignment.Left,
                "Killed", 60, HorizontalAlignment.Left,
                "Talent1", 56, HorizontalAlignment.Center,
                "Talent2", 53, HorizontalAlignment.Center,
                "Accessories1", 49, HorizontalAlignment.Center,
                "Accessories2", 49, HorizontalAlignment.Center,
                "Accessories3", 49, HorizontalAlignment.Center,
                "Accessories4", 49, HorizontalAlignment.Center,
                "Accessories5", 49, HorizontalAlignment.Center,
                "Accessories6", 49, HorizontalAlignment.Center,
                "Accessories7", 49, HorizontalAlignment.Center,
                "Money", 60, HorizontalAlignment.Left,
                "Value", 30, HorizontalAlignment.Left);

            // 新增資料部分, empty為強制換行(符合背景格式)
            ListViewRight.AddRow("", "", "", "", ""); // empty
            ListViewRight.AddRow("", "", "18", "我很厲害會發光優\n你好", "10", "", "", "", "", "", "", "", "", "", "150000", "50");
            ListViewRight.AddRow("", "", "18", "我很厲害會發光優\n你好", "10", "", "", "", "", "", "", "", "", "", "150000", "50");
            ListViewRight.AddRow("", "", "18", "我很厲害會發光優\n你好", "10", "", "", "", "", "", "", "", "", "", "150000", "50");
            ListViewRight.AddRow("", "", "18", "我很厲害會發光優\n你好", "10", "", "", "", "", "", "", "", "", "", "150000", "50");
            ListViewRight.AddRow("", "", "18", "我很厲害會發光優\n你好", "10", "", "", "", "", "", "", "", "", "", "150000", "50");
            ListViewRight.AddRow("", "", "", "", ""); // empty
            ListViewRight.AddRow("", "", "", "", ""); // empty
            ListViewRight.AddRow("", "", "18", "我很厲害會發光優\n你好", "10", "", "", "", "", "", "", "", "", "", "150000", "50");
            ListViewRight.AddRow("", "", "18", "我很厲害會發光優\n你好", "10", "", "", "", "", "", "", "", "", "", "150000", "50");
            ListViewRight.AddRow("", "", "18", "我很厲害會發光優\n你好", "10", "", "", "", "", "", "", "", "", "", "150000", "50");
            ListViewRight.AddRow("", "", "18", "我很厲害會發光優\n你好", "10", "", "", "", "", "", "", "", "", "", "150000", "50");
            ListViewRight.AddRow("", "", "18", "我很厲害會發光優\n你好", "10", "", "", "", "", "", "", "", "", "", "150000", "50");

            // Add icons to the sub-items.
            for (int r = 0; r < ListViewRight.Items.Count; r++)
            {

                ListViewRight.Items[r].ImageIndex = -1;
                if (r > 0 && r != 7 && r != 6)
                {
                    // Set the sub-item indices.
                    for (int c = 1; c < ListViewRight.Columns.Count; c++)
                    {
                        // 加圖片在這行 表示在 (r,c)加上圖片, 
                        // 注意第三個參數要是imageList裡面的index, 可以透過名稱去找, 但名稱要記得加上.png (圖片完整名稱)
                        if ((c > 4 && c < 14) || c == 1) ListViewRight.AddIconToSubitem(r, c, SearchImageFromList("Annie.png"));
                    }
                }
            }
            
#endregion

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

       /* private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.BackColor = pictureBox1.BackColor;
        }*/

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

        private unsafe static GraphicsPath subGraphicsPath(Image img)
        {

            if (img == null) return null;

            GraphicsPath g = new GraphicsPath(FillMode.Alternate);
            Bitmap bitmap = new Bitmap(img);
            int width = bitmap.Width;
            int height = bitmap.Height;
            BitmapData bmData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte* p = (byte*)bmData.Scan0;
            int offset = bmData.Stride - width * 3;
            int p0, p1, p2; // 记录左上角0，0座标的颜色值
            p0 = p[0];
            p1 = p[1];
            p2 = p[2];
            int start = -1;

            for (int Y = 0; Y < height; Y++)
            {

                for (int X = 0; X < width; X++)

                {

                    if (start == -1 && (p[0] != p0 || p[1] != p1 || p[2] != p2) ) //如果 之前的点没有不透明 且 不透明
                    { 
                        start = X; //记录这个点

                    }
                    else if (start > -1 && (p[0] == p0 && p[1] == p1 && p[2] == p2)) //如果 之前的点是不透明 且 透明
                    {
                        g.AddRectangle(new Rectangle(start, Y, X - start, 1)); //添加之前的矩形到
                        start = -1;
                    }

                    if (X == width - 1 && start > -1) //如果 之前的点是不透明 且 是最后一个点
                    {
                        g.AddRectangle(new Rectangle(start, Y, X - start + 1, 1)); //添加之前的矩形到
                        start = -1;
                    }
                    p += 3; //下一个内存地址

                }

                p += offset;

            }

            bitmap.UnlockBits(bmData);
            bitmap.Dispose();

            // 返回计算出来的不透明图片路径
            return g;

        }

        /// <summary>
        /// 调用此函数后使图片透明
        /// </summary>
        /// <param name="control">需要处理的控件</param>
        /// <param name="img">控件的背景或图片，如PictureBox.Image
        /// 或PictureBox.BackgroundImage</param>
        public static void ControlTrans(Control control, Image img)
        {
            GraphicsPath g;
            g = subGraphicsPath(img);
            if (g == null)
                return;
            control.Region = new Region(g);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void ListViewRight_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private int SearchImageFromList(string HeroName) 
        {
            for (int i = 0; i < Lol_heros.Images.Count; i++)
                if (Lol_heros.Images.Keys[i] == HeroName)
                    return i;

            return -1;
        }
 
    }
}
