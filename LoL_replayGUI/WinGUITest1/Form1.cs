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

using WinGUITest1.Service;

namespace WinGUITest1
{
    public partial class Form1 : Form
    {
      //  public string path;
        public string[] files;
        public String groupName;
        private string lolPath;
        private string lolReplayPath;
        private int tmp_cnt;    //计数器


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
                "Empty", 10, HorizontalAlignment.Right,
                "Money", 65, HorizontalAlignment.Left,
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

        /// <summary>
        /// pop-out input box to get user's cookie in order to acquire game information
        /// <summary>
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), /*form.ClientSize.Height*/500);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
        /// <summary> Play Replay Video
        /// /// </summary>
        private void button1_Click_1(object sender, EventArgs e) //play video
        {
            /*
             *  TO_DO: (v) 加入try-catch，不然cookie過期或是沒cookie之類的程式就crash了。還要加個UI讓user log in不然沒cookie，該class就無法作用。
             *  最後是將這段code移到正確位置，暫時放在這裡是因為比較好測試，只要按下撥放鍵，就能在output看到輸出。要把output出來的資訊正確接到view上。
             */
            MyRepository<Battle> battleRepository = new MyRepository<Battle>();
            MyRepository<Record> recordRepository = new MyRepository<Record>();
            MyRepository<ChampionInfo> championInfoRepository = new MyRepository<ChampionInfo>();
            MyRepository<SnapShot> snapShotRepository = new MyRepository<SnapShot>();
            MyRepository<Setting> settingRepository = new MyRepository<Setting>();

            SettingService settingService = new SettingService(settingRepository);

            Setting setting = new Setting();
            setting.Name = "lolCookie";
            setting.Value = "pgv_pvid=5100574670; pgv_info=pgvReferrer=&ssid=s5305104254";

            Battle test;
            try
            {
                settingService.AddSetting(setting);
                LolDataSpider spider = new LolDataSpider(battleRepository, recordRepository, championInfoRepository, snapShotRepository, settingService);
                test = spider.GetDataById(1917183753, 1);
                Debug.WriteLine(test.GameId);
                Debug.WriteLine(test.Duration);
                Debug.WriteLine(test.BattleType);
            }
            catch
            {
                Debug.WriteLine("There is something wrong, please check again.");
                /*
                 *  TO_DO : 輸出一些簡單的說明，協助使用者登入QQ後取得cookie。
                 * 
                 */
                string value = "cookie~~~";
                string explanation = "In order to acquite game information, we need your cookie after log in QQ.\nPlease follow these steps : \n1. open your browser and go to the website : http://lol.qq.com/comm-htdocs/pay/new_index.htm?t=lol or any website which you can log in QQ";
                if (InputBox("type in cookie", /*explanation*/ "test", ref value) == DialogResult.OK)
                {
                    Debug.WriteLine(value);
                }
            }
            


            if (lolPath == null || groupName == null) return;
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
                char [] tmp = lolPath.ToCharArray();
                //sw.WriteLine("dir /w");
                if (tmp[0] != 'C') sw.WriteLine(@"" + tmp[0] + ":");
                //sw.WriteLine(@"E:");
                sw.WriteLine(@"cd " + lolPath);
                string name = "replays\\" + groupName;
                sw.WriteLine(@"launcher.exe -f " + name + ".ob");
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
        private void chooseFolderOnclick(object sender, EventArgs e) 
        {
            // Create an instance of the open file dialog box.
            FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
            openFileDialog1.Description = "請輸入LOL所在目錄";
            openFileDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;



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
                    //根据选择的文件夹路径，设置LOL根目录
                    lolPath = openFileDialog1.SelectedPath;
                    //Debug.WriteLine(lolPath);
                    //设置replays录像所在目录
                    lolReplayPath = openFileDialog1.SelectedPath + "\\replays";
                    //Debug.WriteLine(lolReplayPath);
                    tbResults.Text = lolPath;

                    //获取replays 目录下文件列表
                    files = Directory.GetFiles(lolReplayPath);
                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        string isOb = Path.GetExtension(file);
                        //Debug.WriteLine(isOb);
                        
                        if (String.Compare(isOb, ".ob") != 0)
                        {
                            //若拓展名不是.ob ，则直接读取下一个
                            continue;
                        }

                        /*
                         TODO :: Parse from .ob file
                         */

                        String label = fileName;
                        lvwBooks.Groups.Add(new ListViewGroup(label, HorizontalAlignment.Left));

                        //根據文件名，獲取對應文件名的json內數據
                        String jsonFile = fileName + 'A';
                        getJsonByObName(jsonFile);

                        jsonFile = fileName + 'B';
                        getJsonByObName(jsonFile);

                    }
                    // if 目录下文件为空
                    if (tmp_cnt <=0)
                    {
                        // 请先下载录像文件到replays目录下
                    }
                    
                }
                catch (IOException)
                {
                }
            }

        }

        private void getJsonByObName(string fileName)
        {

            string jsonFileName = lolReplayPath + "\\db\\" + fileName + ".json";
            Debug.WriteLine(jsonFileName);
            /*
             *TODO :: 若json不存在，则重新从网络抓取。 参考 Lol\LolService.cs  GetDataById() 函数。需要COOKIE。
             *      预览方式：http://lol.qq.com 登录QQ ，然后 直接访问 http://api.pallas.tgp.qq.com/core/tcall?callback=getGameDetailCallback&dtag=profile&p=%5B%5B4%2C%7B%22area_id%22%3A%221%22%2C%22game_id%22%3A%221917183753%22%7D%5D%5D&t=1458284672949
             *      参数说明：原参数为：tcall?callback=getGameDetailCallback&dtag=profile&p=[[4,{"area_id":"7","game_id":"897455227"}]]&t=1458284672949 ，其中p参数为重点，area_id为大区ID，即OB文件1_1111111.ob中的_线前部分，后面是game_id。
             *      可以根据现有的OB文件，更改 http://api.pallas.tgp.qq.com/core/tcall?callback=getGameDetailCallback&dtag=profile&p=%5B%5B4%2C%7B%22area_id%22%3A%221%22%2C%22game_id%22%3A%221917183753%22%7D%5D%5D&t=1458284672949 对应的area_id、game_id的参数，浏览器打开访问即可。（这里p参数为URL编码后的形式）
             *      若使用LolService.cs，则参考LolService.cs的 GetJsonResponse函数中 request.Headers.Add(HttpRequestHeader.Cookie, settingService.GetValueByName("lolCookie")); 这部分代码。
             */
            
            using (StreamReader r = new StreamReader(jsonFileName))
            {
                string json = r.ReadToEnd();
                 Debug.Write(json);
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
            
            //获取A队详情
            String jsonName = groupName + 'A';
            getDetailInfo(jsonName);

            //获取B队详情
            jsonName = groupName + 'B';
            getDetailInfo(jsonName,true);
         
        }

        private void getDetailInfo(string fileName,bool teamB = false)
        {
            string jsonFileName = lolReplayPath + "\\db\\" + fileName + ".json";
            int row;
            int step = 0;
            if (teamB)
            {
                step = 7;   //此处是根据你们代码理解计算出来的，我也不知道为什么 Team B的初始化时，是row = 8
            }
            using (StreamReader r = new StreamReader(jsonFileName))
            {
                string json = r.ReadToEnd();
                Team perTeam = JsonConvert.DeserializeObject<Team>(json);


                for (row = (1 + step); row < (6+ step); row++)
                {
                    String roleName = perTeam.player_list[row - (1+step)].role + ".png";
                    Debug.Write(roleName);
                    ListViewRight.AddIconToSubitem(row, 1, SearchImageFromList(roleName));
                    ListViewRight.Items[row].SubItems[2].Text = perTeam.player_list[row - (1 + step)].name + '\n' + perTeam.player_list[row - (1 + step)].role;
                    ListViewRight.Items[row].SubItems[3].Text = perTeam.player_list[row - (1 + step)].KDA;
                    for (int j = 0; j < perTeam.player_list[row - (1+step)].equipments.Count; j++)
                        ListViewRight.AddIconToSubitem(row, 5 + j, SearchImageFromList(perTeam.player_list[row - (1 + step)].equipments[j] + ".png"));
                    ListViewRight.Items[row].SubItems[13].Text = perTeam.player_list[row - (1 + step)].incoming + 'k';
                    ListViewRight.Items[row].SubItems[14].Text = perTeam.player_list[row - (1 + step)].farm;
                    //ListViewRight.AddToSubitem(row, 1, SearchImageFromList(roleName));
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
