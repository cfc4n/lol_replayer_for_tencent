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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WinGUITest1
{
    public partial class Form1 : Form
    {
        public string path;
        public string[] files;
        public String groupName;

        public class Player
        {
            public string __module__ { get; set; }
            public string incoming { get; set; }
            public string name { get; set; }
            public string farm { get; set; }
            public string __class__ { get; set; }
            public string KDA { get; set; }
            public List<string> equipments { get; set; }
            public string role { get; set; }
            public string img_src { get; set; }
        }
        public class Team
        {
            public string __module__ { get; set; }
            public string __class__ { get; set; }
            public List<Player> player_list { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
#region ListViewLeft
            lvwBooks.SmallImageList = Lol_heros;
            lvwBooks.ShowSubItemIcons(true);
            // Make the column headers.
            lvwBooks.MakeColumnHeaders(
                "Hero1", 55, HorizontalAlignment.Right,
                "Hero2", 55, HorizontalAlignment.Left,
                "Hero3", 55, HorizontalAlignment.Left,
                "Hero4", 55, HorizontalAlignment.Left,
                "Hero5", 55, HorizontalAlignment.Right);
            /*lvwBooks.Groups.Add(new ListViewGroup("1", HorizontalAlignment.Left));
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
            }*/
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
                "Name", 155, HorizontalAlignment.Left,
                "Killed", 65, HorizontalAlignment.Center,
                "Empty", 15, HorizontalAlignment.Right,
                "Accessories1", 47, HorizontalAlignment.Center,
                "Accessories2", 47, HorizontalAlignment.Center,
                "Accessories3", 47, HorizontalAlignment.Center,
                "Accessories4", 47, HorizontalAlignment.Center,
                "Accessories5", 47, HorizontalAlignment.Center,
                "Accessories6", 47, HorizontalAlignment.Center,
                "Accessories7", 47, HorizontalAlignment.Center,
                "Empty", 15, HorizontalAlignment.Right,
                "Money", 60, HorizontalAlignment.Left,
                "Value", 30, HorizontalAlignment.Left);
            
            // 新增資料部分, empty為強制換行(符合背景格式)
            ListViewRight.AddRow("", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); // empty
            ListViewRight.AddRow("", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); // empty
            ListViewRight.AddRow("", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); // empty
            ListViewRight.AddRow("", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); // empty
            ListViewRight.AddRow("", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); // empty
            ListViewRight.AddRow("", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); // empty
            ListViewRight.AddRow("", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); // empty
            ListViewRight.AddRow("", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); // empty
            ListViewRight.AddRow("", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); // empty
            ListViewRight.AddRow("", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); // empty
            ListViewRight.AddRow("", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); // empty
            ListViewRight.AddRow("", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); // empty
            ListViewRight.AddRow("", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); // empty

            for (int i = 0; i < 13; i++) ListViewRight.Items[i].ImageIndex = -1;

#endregion

        }

        /// <summary> Play Replay Video
        /// /// </summary>
        private void button1_Click_1(object sender, EventArgs e) //play video
        {
            if (path == null) return;
            Thread sample = new Thread(startLoLReplay);
            sample.Start();
            Thread.Sleep(1000 * 20);
            Process[] pArr = new Process[20];
            pArr = Process.GetProcessesByName("League of Legends");
            //MessageBox.Show(pArr.Length.ToString());
            while (pArr.Length > 0) {
                pArr = Process.GetProcessesByName("League of Legends");
            };
            sample.Abort();
            //MessageBox.Show("abort LoL replay thread");
            pArr = Process.GetProcessesByName("launcher");
            //MessageBox.Show(pArr.Length.ToString()+" exe files");
            for(int i = 0 ; i < pArr.Length ; i++){
                pArr[i].Kill();
            }

            
        }

        /// <summary> Lol replay thread
        /// </summary>
        void startLoLReplay()
        {
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
                char [] tmp = path.ToCharArray();
                //sw.WriteLine("dir /w");
                if (tmp[0] != 'C') sw.WriteLine(@"" + tmp[0] + ":");
                //sw.WriteLine(@"E:");
                sw.WriteLine(@"cd " + path);
                sw.WriteLine(@"launcher.exe -f " + groupName + ".ob");
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

        /// <summary> Choose folder and set left listview
        /// </summary>
        private void button2_Click(object sender, EventArgs e) 
        {
            // Create an instance of the open file dialog box.
            FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();

            
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {

                // clean listview first
                foreach (ListViewItem eachItem in lvwBooks.Items)
                {
                    lvwBooks.Items.Remove(eachItem);
                }

                //string file = openFileDialog1.SelectedPath;
                try
                {
                    //string text = File.ReadAllText(file);
                    path = openFileDialog1.SelectedPath;
                    tbResults.Text = path;

                    files = Directory.GetFiles(openFileDialog1.SelectedPath);
                    int tmp_cnt = 0;
                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        string isOb = Path.GetExtension(file);
                        //Debug.WriteLine(isOb);
                        
                        if (String.Compare(isOb, ".ob") == 0)
                        {
                            /*
                             TODO :: Parse from .ob file
                             */

                            String label = fileName;
                            lvwBooks.Groups.Add(new ListViewGroup(label, HorizontalAlignment.Left));
                            String jsonFile = fileName + 'A';
                           // Debug.Write(jsonFile);
                            foreach (string f in files)
                            {
                                string jsonFileName=Path.GetFileNameWithoutExtension(f);
                                if(String.Compare(jsonFileName,jsonFile)==0){
                                    using (StreamReader r = new StreamReader(f))
                                    {
                                        string json = r.ReadToEnd();
                                       // Debug.Write(json);
                                        Team perTeam = JsonConvert.DeserializeObject<Team>(json);

                                        lvwBooks.AddRow("", "", "", "", ""); // empty

                                        // Add icons to the sub-items.
                                        for (int i = tmp_cnt; i < lvwBooks.Items.Count; i++)
                                        {
                                            // Set the main item's image index.
                                            int index = SearchImageFromList(perTeam.player_list[0].role + ".png");
                                            lvwBooks.Items[i].ImageIndex = index;
                                            lvwBooks.Items[i].Group = lvwBooks.Groups[tmp_cnt / 2];

                                            for (int c = 1; c < lvwBooks.Columns.Count; c++)
                                            {
                                                index = SearchImageFromList(perTeam.player_list[c].role + ".png");
                                                lvwBooks.AddIconToSubitem(i, c, index);

                                            }
                                        }
                                        tmp_cnt++;
                                    }
                                }
                            }
                            jsonFile = fileName + 'B';
                            //Debug.Write(jsonFile);
                            foreach (string f in files)
                            {
                                string jsonFileName = Path.GetFileNameWithoutExtension(f);
                                if (String.Compare(jsonFileName, jsonFile) == 0)
                                {
                                    using (StreamReader r = new StreamReader(f))
                                    {
                                        string json = r.ReadToEnd();
                                        //Debug.Write(json);
                                        Team perTeam = JsonConvert.DeserializeObject<Team>(json);

                                        lvwBooks.AddRow("", "", "", "", ""); // empty

                                        // Add icons to the sub-items.
                                        for (int i = tmp_cnt; i < lvwBooks.Items.Count; i++)
                                        {
                                            // Set the main item's image index.
                                            int index = SearchImageFromList(perTeam.player_list[0].role + ".png");
                                            lvwBooks.Items[i].ImageIndex = index;
                                            lvwBooks.Items[i].Group = lvwBooks.Groups[tmp_cnt / 2];

                                            for (int c = 1; c < lvwBooks.Columns.Count; c++)
                                            {
                                                index = SearchImageFromList(perTeam.player_list[c].role + ".png");
                                                lvwBooks.AddIconToSubitem(i, c, index);

                                            }
                                        }
                                        tmp_cnt++;
                                    }
                                }
                            }
                                
                                
                            
                        }
                    }
                }
                catch (IOException)
                {
                }
            }

        }

        /// <summary> Test for ID parser
        /// </summary>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //string name = "龙珠TV丶黑骨";
            string name = "最初你想要什么";
            string strPath = @"C:\Users\Blurry\Documents\lol_replayer_for_tencent\IDParser\dist";
            //System.IO.File.WriteAllText(strPath + strUser + ".txt", text);
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = Path.GetFileName(strPath + @"\IDParser.exe");
            psi.WorkingDirectory = Path.GetDirectoryName(strPath + @"\IDParser.exe");
            psi.Arguments = " " + name;
            Process.Start(psi);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary> Left ListView loading, take data from .ob and .json file
        /// </summary>
        private void lvwBooks_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (lvwBooks.SelectedItems.Count < 1) return; 

            //ListViewRight.Clear();
            //if (lvwBooks.SelectedItems[0] != null) MessageBox.Show(lvwBooks.SelectedItems[0].Group.ToString());
            groupName=lvwBooks.SelectedItems[0].Group.ToString();
            // 新增資料部分, empty為強制換行(符合背景格式)

            // Debug.Write(groupName);
            int row;
            String jsonName = groupName + 'A';
            foreach (string f in files)
            {
                string jsonFileName = Path.GetFileNameWithoutExtension(f);
              // Debug.Write(jsonFileName);
               // Debug.Write(groupName);

                if (String.Compare(jsonFileName, jsonName) == 0)
                {
 
                    //Debug.Write(jsonFileName);
                    using (StreamReader r = new StreamReader(f))
                    {
                        string json = r.ReadToEnd();
                        //Debug.Write(json);
                        Team perTeam = JsonConvert.DeserializeObject<Team>(json);


                        for (row = 1; row < 6; row++)
                        {
                            String roleName = perTeam.player_list[row-1].role + ".png";
                            Debug.Write(roleName);
                            ListViewRight.AddIconToSubitem(row, 1, SearchImageFromList(roleName));
                            ListViewRight.Items[row].SubItems[2].Text = perTeam.player_list[row - 1].name + '\n' + perTeam.player_list[row - 1].role;
                            ListViewRight.Items[row].SubItems[3].Text = perTeam.player_list[row - 1].KDA;
                            for(int j=0;j<perTeam.player_list[row-1].equipments.Count;j++)
                                ListViewRight.AddIconToSubitem(row, 5+j, SearchImageFromList(perTeam.player_list[row - 1].equipments[j]+".png"));
                            ListViewRight.Items[row].SubItems[13].Text = perTeam.player_list[row - 1].incoming;
                            ListViewRight.Items[row].SubItems[14].Text = perTeam.player_list[row - 1].farm;
                            //ListViewRight.AddToSubitem(row, 1, SearchImageFromList(roleName));

                        }
                    }
                }
            }

            jsonName = groupName + 'B';
            foreach (string f in files)
            {
                string jsonFileName = Path.GetFileNameWithoutExtension(f);
                // Debug.Write(jsonFileName);
                // Debug.Write(groupName);

                if (String.Compare(jsonFileName, jsonName) == 0)
                {

                    //Debug.Write(jsonFileName);
                    using (StreamReader r = new StreamReader(f))
                    {
                        string json = r.ReadToEnd();
                        //Debug.Write(json);
                        Team perTeam = JsonConvert.DeserializeObject<Team>(json);

                        for (row = 8; row < 13; row++)
                        {
                            String roleName = perTeam.player_list[row - 8].role + ".png";
                            Debug.Write(roleName);
                            ListViewRight.AddIconToSubitem(row, 1, SearchImageFromList(roleName));
                            ListViewRight.Items[row].SubItems[2].Text = perTeam.player_list[row - 8].name + '\n' + perTeam.player_list[row - 8].role;
                            ListViewRight.Items[row].SubItems[3].Text = perTeam.player_list[row - 8].KDA;
                            for (int j = 0; j < perTeam.player_list[row - 8].equipments.Count; j++)
                                ListViewRight.AddIconToSubitem(row, 5 + j, SearchImageFromList(perTeam.player_list[row - 8].equipments[j] + ".png"));
                            ListViewRight.Items[row].SubItems[13].Text = perTeam.player_list[row - 8].incoming;
                            ListViewRight.Items[row].SubItems[14].Text = perTeam.player_list[row - 8].farm;
                            

                        }
                    }
                }
            }
         
        }

        private void tbResults_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary> Set Background transparent 
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
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

        /// <summary> 调用此函数后使图片透明
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
        
        /// <summary> Right ListView EventHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ListViewRight.SelectedItems.Count> 0) ListViewRight.Items[ListViewRight.SelectedItems[0].Index].SubItems[14].Text = "hello world";
        }

        /// <summary> Search image from imagelist (Lol_heros)
        /// </summary>
        /// <param name="HeroName"></param>
        /// <returns></returns>
        private int SearchImageFromList(string Name) 
        {
            for (int i = 0; i < Lol_heros.Images.Count; i++)
                if (Lol_heros.Images.Keys[i] == Name)
                    return i;

            return -1;
        }
 
    }
}
