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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            _keyList = KeyList.Instance;
            _testManager = TestManager.Instance;
            

            _testresult_columninfos = new List<string>();

            try
            {
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

            sendInfo.Add(_keyList.k_store_category, categoryName);
            sendInfo.Add(_keyList.k_worker_mode, workerMode);
            _testManager.worker.RunWorkerAsync(sendInfo);
        }


    }
}
