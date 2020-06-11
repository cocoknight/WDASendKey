using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


////C# process dump남기기
////http://blog.naver.com/PostView.nhn?blogId=techshare&logNo=100194859982



namespace WADSendKeyTest
{
    public partial class Form1 : Form
    {
        public KeyList _keyList;
        TestManager _testManager;
        List<string> _testresult_columninfos;

        public WindowsDriver<WindowsElement> _deskTopSession;
        public WebDriverWait _wait;
        public int _notepad_repeat_number = 5;
        public int _print_repeat_number = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            _keyList = KeyList.Instance;
            _testManager = TestManager.Instance;
            _testManager.connectUI(this);

            _testresult_columninfos = new List<string>();
            //txtBox_Exception.Text = "abc";

            try
            {
                txtNotePad_num.Text = _notepad_repeat_number.ToString();
                txtPrint_num.Text = _print_repeat_number.ToString();

                this.initTestResultList();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
            }

        }


        public void initTestResultList()
        {

            if (grpTestResult.Controls.ContainsKey("ResultListView"))
            {
                ListView resultList = (ListView)grpTestResult.Controls["ResultListView"];

                resultList.View = View.Details;
                resultList.GridLines = true;
                resultList.FullRowSelect = true;
                resultList.CheckBoxes = false;

                resultList.Columns.Add(_keyList.k_test_result, "Result", 120);  //pass, fail
                resultList.Columns.Add(_keyList.k_test_scenario, "Test Scenario", 400);
                resultList.Columns.Add(_keyList.k_end_time, "Finish Time", 170);

                //_testresult_columninfos
                _testresult_columninfos.Add(_keyList.k_test_result);
                _testresult_columninfos.Add(_keyList.k_test_scenario);
                _testresult_columninfos.Add(_keyList.k_end_time);
              

            }

        }




        public void HeyConnect()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Hey Connect"));
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {

            cmdStart.Enabled = false;

            Dictionary<string, string> sendInfo = new Dictionary<string, string>();


            string categoryName = EnumSet.CATEGORY.WAD_SENDKEY_TEST.ToString();
            string workerMode = EnumSet.ActionMode.STORE_AUTOMATION_TEST.ToString();

            //k_app_repeat_number = "k_app_repeat_number";
            //k_operation_repeat_number = "k_operation_repeat_number";
            sendInfo.Add(_keyList.k_app_repeat_number, txtNotePad_num.Text);
            sendInfo.Add(_keyList.k_operation_repeat_number, txtPrint_num.Text);
            sendInfo.Add(_keyList.k_store_category, categoryName);
            sendInfo.Add(_keyList.k_worker_mode, workerMode);
            _testManager.worker.RunWorkerAsync(sendInfo);
        }

        private void TxtBox_Exception_TextChanged(object sender, EventArgs e)
        {

        }


        //Data Update to ListView
        public void TestResultToListView(List<Dictionary<string, object>> testResult)
        {
            //ListView의 마지막 항목만을 신규로 update한다.
            //현재 WDASendKeyTest의 usecase는 이렇게 design했다.
            ListView itemListView = (ListView)grpTestResult.Controls["ResultListView"];
            string[] row = { "", "", ""};

            //1번에 하나씩만 업데이트 하기
            var currDic = testResult.LastOrDefault();
            ListViewItem cItem = new ListViewItem(row);
            cItem.UseItemStyleForSubItems = false;

            foreach (string name in _testresult_columninfos)
            {

                if (currDic.ContainsKey(name))
                {
                    int columnIndex = itemListView.Columns.IndexOfKey(name);
                    cItem.SubItems[columnIndex].Text = currDic[name].ToString(); //columninfo에 해당하는 키의 값은 string이다.
                }
            }

            itemListView.Items.Add(cItem);

            //foreach (var currDic in testResult)
            //{
            //    ListViewItem cItem = new ListViewItem(row);
            //    cItem.UseItemStyleForSubItems = false;  //이 설정이 없으면 subitem의 색상이 변경되지 않는다.

            //    foreach (string name in _testresult_columninfos)
            //    {

            //        if (currDic.ContainsKey(name))
            //        {
            //            int columnIndex = itemListView.Columns.IndexOfKey(name);
            //            cItem.SubItems[columnIndex].Text = currDic[name].ToString(); //columninfo에 해당하는 키의 값은 string이다.
            //        }
            //    }

            //    itemListView.Items.Add(cItem);
            //}


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Close NotePad(NotePad 닫기)
            //    "/Pane[@ClassName=\"#32769\"][@Name=\"데스크톱 1\"]/Window[@ClassName=\"Notepad\"][@Name=\"*제목 없음 - Windows 메모장\"]/TitleBar[@AutomationId=\"TitleBar\"]/Button[@Name=\"닫기\"]"




            ////    //var gameElement = _deskTopSessoin.FindElementsByXPath("//ListItem[@ClassName=\"GridViewItem\"]/Button[@AutomationId=\"_rootGrid\"]/Image[@AutomationId=\"_image\"]");

            this.initDeskTopSession_Explicit();

            try
            {
                //아래 코드 테스트 문제 없음...
                //var element = _deskTopSession.FindElementByXPath("//Window[@Name=\"전원 관리 옵션 설정 편집\"]/TitleBar[@AutomationId=\"TitleBar\"]/Button[@Name=\"닫기\"]");
                //element.Click();

                //below is okay
                //var element = _deskTopSession.FindElementByXPath("//Window[@Name=\"*제목 없음 - Windows 메모장\"]/TitleBar[@AutomationId=\"TitleBar\"]/Button[@Name=\"닫기\"]");
                //element.Click();

                //below is Okay
                var find_element = _deskTopSession.FindElementByXPath("//Window[@ClassName=\"Notepad\"]/TitleBar[@AutomationId=\"TitleBar\"]/Button[@Name=\"닫기\"]");
                var notepad_close_button = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(find_element));
                notepad_close_button.Click();

                var save_ignore_button = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByAccessibilityId.AccessibilityId("CommandButton_7")));
                save_ignore_button.Click();
                
                //element.Click();


                //var element = _deskTopSession.FindElementByXPath("//Window[@ClassName=\"Notepad\"]/TitleBar[@AutomationId=\"TitleBar\"]/Button[@AutomationId=\"Close\"]");
                //element.Click();



                //var element = _deskTopSession.FindElementByXPath("//Window[@Name=\"*제목 없음 - Windows 메모장\"]/TitleBar[@AutomationId=\"TitleBar\"]/Button[@AutomationId=\"Close\"]");
                //element.Click();

                //var find_element = _deskTopSession.FindElementByXPath("//Window[@ClassName=\"NotePad\"]/TitleBar[@AutomationId=\"TitleBar\"]/Button[@AutomationId=\"Close\"]");
                //var find_element = _deskTopSession.FindElementByXPath("//Window[@Name=\"*제목 없음 - Windows 메모장\"]/TitleBar[@AutomationId=\"TitleBar\"]/Button[@Name=\"닫기\"]");
                //var notepad_close_button = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(find_element));
                //notepad_close_button.Click();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
            }

        }


        public void initDeskTopSession_Explicit()
        {

            System.Diagnostics.Debug.WriteLine(string.Format("InitDeskTop Session(BaseManager)"));
            string platformName = "Windows";
            string deviceName = "WindowsPC";
            string app_id = "Root";

            if (_deskTopSession == null)
            {
                try
                {
                    OpenQA.Selenium.Appium.AppiumOptions ao = new AppiumOptions();
                    ao.AddAdditionalCapability("app", app_id);
                    ao.AddAdditionalCapability("platformName", platformName);
                    ao.AddAdditionalCapability("deviceName", deviceName);

                    _deskTopSession = new WindowsDriver<WindowsElement>(new Uri(@"http://127.0.0.1:4723"), ao, TimeSpan.FromMinutes(10));
                    _wait = new WebDriverWait(_deskTopSession, new TimeSpan(0, 5, 0));

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
                }
            }

        }



    }
}
