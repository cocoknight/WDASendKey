using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WADSendKeyTest
{
    class EnumSet
    {
        public enum CATEGORY
        {
            WAD_SENDKEY_TEST = 0,
            WAD_MOUSE,
            WAD_TOUCH,
            WAD_ETC
        }

        public enum ActionMode
        {
            STORE_AUTOMATION_TEST,
            STORE_AUTOMATION_REPORT,
            TEST_MAX
        }

    }
}
