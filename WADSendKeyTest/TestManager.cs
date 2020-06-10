using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public string _categoryName = "";
        public string _subclassName = "";

        public bool _test_result = false;
        int _retry_counter = 0;
        int _success_counter = 0;

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
            do
            {
                try
                {
                    //Below is exception test code
                    //int tData = 100;
                    //int sum = tData / 0;
                    //_test_result = true;

                    //SendKey Test with notepad
                    //Just focusing for issue generation.
                    //var element = _deskTopSession.FindElementByAccessibilityId("4101");
                    //element.Click();

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
                    var notepad_element = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//Image[@AutomationId=\"suggestionsList\"]//child::ListItem[1]")));
                    notepad_element.Click();


                    //ClassName = "Edit"
                    var edit_element = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("Edit")));
                    edit_element.Click();
                    edit_element.SendKeys("Hello WAD");
                    edit_element.SendKeys(OpenQA.Selenium.Keys.Enter);

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

                    //Calculate Current Time with using Utility Class
                    Thread.Sleep(1000); //for saving power consumption
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
                    _test_result = false;
                }
            } while (_success_counter < 10 && _test_result != false);


            //Terminate while loop for
            if(_test_result==false)
            {
                //TO DO Memory Dump
                //URL참조: http://blog.naver.com/PostView.nhn?blogId=techshare&logNo=100194859982
                //File은 Filezilla로 전송.
            }
        }


    }
}
