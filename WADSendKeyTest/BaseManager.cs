using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WADSendKeyTest
{
    class BaseManager
    {
        public Form1 _uiManager;
        public WindowsDriver<WindowsElement> _deskTopSession;
        public WebDriverWait _wait;


        public BaseManager()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Default Constructor(BaseManager)"));
        }

        public BaseManager(EnumSet.CATEGORY category)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Constructor(BaseManager)"));
        }

        public void connectUI(Form1 conn)
        {
            _uiManager = conn;
            System.Diagnostics.Debug.WriteLine(string.Format("connectUI(BaseManager)"));
            conn.HeyConnect();
        }


        public void initDeskTopSession_Implicit()
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

                    _deskTopSession = new WindowsDriver<WindowsElement>(new Uri(@"http://127.0.0.1:4723"), ao, TimeSpan.FromMinutes(/*2*/4)); //2분 응답 Timer설정
                                                                                                                                              // _deskTopSessoin = new WindowsDriver<WindowsElement>(new Uri(@"http://127.0.0.1:4723"), ao); //시간을 주지 않으면, Default 1분 응답 Timer
                                                                                                                                              //_deskTopSessoin.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                    _deskTopSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(/*30*/200);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
                }
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
