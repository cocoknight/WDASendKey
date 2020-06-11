using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WADSendKeyTest
{
    class TestManager : BaseManager
    {

        private static readonly TestManager instance = new TestManager();
        public System.ComponentModel.BackgroundWorker worker;

        //public List<Dictionary<string, object>> _store_test_list;
        public CUtility _myUtility;
        public KeyList _keyList;
        public List<Dictionary<string, object>> _sendkey_test_list;
        protected DateTime _taskEndTime;

        public string _categoryName = "";
        public string _subclassName = "";
        protected string s_endTime;


        public bool _test_result = false;
        int _retry_counter = 0;
        int _notepad_counter = 0;
        int _success_counter = 0;
        int _testpass_number = 10;
        int _notepad_loop = 5;

        private TestManager() : base()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("CInstallManager Constructor(SingleTone)"));
            _sendkey_test_list = new List<Dictionary<string, object>>();
            _myUtility = CUtility.Instance;
            _keyList = KeyList.Instance;


            //Related with Background Worker
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

        }

        public static TestManager Instance
        {
            get
            {
                return instance;
            }
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Worker DoWork"));
            Dictionary<string, string> argument = e.Argument as Dictionary<string, string>;

            string operation = argument[_keyList.k_worker_mode];

            System.Diagnostics.Debug.WriteLine(string.Format("Work Mode:{0}", operation));

            _notepad_loop = Int32.Parse(argument[_keyList.k_app_repeat_number]);
            _testpass_number = Int32.Parse(argument[_keyList.k_operation_repeat_number]);
           


            try
            {
                _categoryName = argument[_keyList.k_store_category];
                //_subclassName = argument[_keyList.k_store_subclass];

                switch (operation)
                {
                    case "STORE_AUTOMATION_TEST":
                        {
                            System.Diagnostics.Debug.WriteLine(string.Format("Run STORE_AUTOMATION_TEST"));
                            System.Diagnostics.Debug.WriteLine(string.Format("Category Name:{0}, Sub Class Name:{1}", _categoryName, _subclassName));
                            this.initDeskTopSession_Explicit();
                            this.do_automation_parsing(_categoryName);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
            }

        }



        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Progressed Changed"));
            _uiManager.TestResultToListView(_sendkey_test_list);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Run Completed"));
            //TOAN : 04/22/2020. update test
            //_uiManager.TestResultToListView(_store_test_list);
        }



        void do_automation_parsing(string category)
        {
            try
            {
                switch (category)
                {
                    case "WAD_SENDKEY_TEST":
                        {
                            System.Diagnostics.Debug.WriteLine(string.Format("SendKey Test Verification Start"));
                            this.do_sendkey_verification();
                            break;
                        }
                    case "WAD_MOUSE":
                        {
                            System.Diagnostics.Debug.WriteLine(string.Format("MOUSE Test Verification Start"));
                            break;
                        }
                    case "WAD_TOUCH":
                        {
                            System.Diagnostics.Debug.WriteLine(string.Format("MOUSE Test Verification Start"));
                            break;
                        }
                    default:
                        break;
                }

            }catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
            }
        }


        void do_sendkey_verification()
        {
            //Faile이 날때 까지는 계속 수행
            //notepad app은 1번만 수행 시킨다.
            bool b_notepad_running = false;
            
            //Main Program Loop
            //Notice : SendKey Test에서 _test_result가 false가 되면, retry handling을 해도
            //복구가 안되기 때문에 전체 루틴을 종료 시킨다.

            do
            {
                //NotePad Loop
                try
                {
                   //exception test code
                   // int sum = 100;
                   // int tmp_value = sum / 0;

                    var element_search_area = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByAccessibilityId.AccessibilityId("4101")));
                    element_search_area.Click();

                    var element_search_textbox = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByAccessibilityId.AccessibilityId("SearchTextBox")));
                    element_search_textbox.Clear();
                    element_search_textbox.Click();
                    element_search_textbox.SendKeys(@"notepad");

                    //var element1 = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("검색하려면 여기에 입력하십시오.")));

                    //suggestionsList
                    //var find_element = _deskTopSession.FindElementByXPath("//Image[@AutomationId=\"suggestionsList\"]//child::ListItem[1]");
                    //var notepad_element = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(find_element));
                    var notepad_element = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//List[@AutomationId=\"suggestionsList\"]//child::ListItem[1]")));
                    notepad_element.Click();

                    b_notepad_running = true;
                    _notepad_counter = _notepad_counter + 1;


                    Dictionary<string, object> item_info = new Dictionary<string, object>();
                    item_info.Add(_keyList.k_test_result, "pass");
                    item_info.Add(_keyList.k_test_scenario, "run notepad application");

                    //시간 업데이트
                    _taskEndTime = System.DateTime.Now;
                    s_endTime = string.Format("{0:hh:mm:ss tt}", _taskEndTime);
                    item_info.Add(_keyList.k_end_time, s_endTime);

                    _sendkey_test_list.Add(item_info);

                    //여기서 UI Update
                    //worker.ReportProgress(10, update_info);
                    worker.ReportProgress(1); //여기서 1의 의미는 progress bar퍼세트용도가 아니라, 단순히 worker_ProgressChanged을 호출하기 위한 용도

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));

                    Dictionary<string, object> item_info = new Dictionary<string, object>();
                    item_info.Add(_keyList.k_test_result, "fail");
                    item_info.Add(_keyList.k_test_scenario, "run notepad application");

                    //시간 업데이트
                    _taskEndTime = System.DateTime.Now;
                    s_endTime = string.Format("{0:hh:mm:ss tt}", _taskEndTime);
                    item_info.Add(_keyList.k_end_time, s_endTime);

                    _sendkey_test_list.Add(item_info);

                    _test_result = false;
                    _uiManager.txtBox_Exception.Text = ex.ToString();

                    //여기서 UI Update
                    worker.ReportProgress(1);


                    break; //이 브레이크를 사용하면 전체 루프가 종료 된다.
                }

                

                if (b_notepad_running)
                {
                    var edit_element = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("Edit")));
                    edit_element.Click();

                    _success_counter = 0;
                    _test_result = false;
                    do
                    {

                        try
                        {
                            //var edit_element = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("Edit")));
                            //edit_element.Click();
                            //Thread.Sleep(1000); //키처리 시간 예상

                            edit_element.SendKeys("Hello WAD");
                            Thread.Sleep(2000); //키처리 시간 예상

                            edit_element.SendKeys(OpenQA.Selenium.Keys.Enter);
                            Thread.Sleep(2000); //키처리 시간 예상

                            //UI-Update진행할 것(현재 진행 결과를 데이터 구성해서 view로 업데이트)
                            //List는 모든것을 가지고 있다하더라도, View에서 업데이트할 때, 전체 List를 모두 갱신하는 것이 아니라,
                            //List의 최종 항목만 업데이트 하도록 변경하면 된다.

                            //에러가 없었으면 view에 업데이트할 항목을 구성하고 업데이트 한다.
                            //_testresult_columninfos.Add(_keyList.k_test_result);
                            //_testresult_columninfos.Add(_keyList.k_test_scenario);
                            //_testresult_columninfos.Add(_keyList.k_end_time);

                            Dictionary<string, object> item_info = new Dictionary<string, object>();
                            item_info.Add(_keyList.k_test_result, "pass");
                            item_info.Add(_keyList.k_test_scenario, "send string to notepad application");

                            //시간 업데이트
                            _taskEndTime = System.DateTime.Now;
                            s_endTime = string.Format("{0:hh:mm:ss tt}", _taskEndTime);
                            item_info.Add(_keyList.k_end_time, s_endTime);

                            _sendkey_test_list.Add(item_info);

                            worker.ReportProgress(1);  //ui update


                            _test_result = true;
                            _success_counter = _success_counter + 1;

                            //현재 Test결과 ListView로 업데이트.

                            //Calculate Current Time with using Utility Class
                            Thread.Sleep(1000); //for saving power consumption
                        }
                        catch (Exception ex)
                        {

                            System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
                            Dictionary<string, object> item_info = new Dictionary<string, object>();
                            item_info.Add(_keyList.k_test_result, "fail");
                            item_info.Add(_keyList.k_test_scenario, "send string to notepad application");

                            //시간 업데이트
                            _taskEndTime = System.DateTime.Now;
                            s_endTime = string.Format("{0:hh:mm:ss tt}", _taskEndTime);
                            item_info.Add(_keyList.k_end_time, s_endTime);

                            _sendkey_test_list.Add(item_info);

                            worker.ReportProgress(1); //ui update
                            _test_result = false;
                            _uiManager.txtBox_Exception.Text = ex.ToString();
                        }
                    } while (_success_counter < _testpass_number && _test_result != false);


                    //notepad종료(결과 상관없이 종료)
                    var find_element = _deskTopSession.FindElementByXPath("//Window[@ClassName=\"Notepad\"]/TitleBar[@AutomationId=\"TitleBar\"]/Button[@Name=\"닫기\"]");
                    var notepad_close_button = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(find_element));
                    notepad_close_button.Click();

                    var save_ignore_button = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByAccessibilityId.AccessibilityId("CommandButton_7")));
                    save_ignore_button.Click();

                }




            } while(_notepad_counter < _notepad_loop && _test_result!=false);
            

            //Terminate while loop for
            if(_test_result==false)
            {
                //TO DO : Save Screen Shot
                string dirName = @"C:\testautomation";
                DirectoryInfo di = new DirectoryInfo(dirName);

                if (di.Exists == false)
                {
                    di.Create();
                }

                Screenshot screenshot = _deskTopSession.GetScreenshot();
                screenshot.SaveAsFile(@"C:\testautomation\screenshot.png");

                //TO DO : Memory Dump
                //URL참조: http://blog.naver.com/PostView.nhn?blogId=techshare&logNo=100194859982
                //File은 Filezilla로 전송.
                System.Diagnostics.Debug.WriteLine(string.Format("Current Test is Fail"));
            }


        } //end of sendKey verification


    }
}
