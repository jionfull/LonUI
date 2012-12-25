using System;
using System.Collections.Generic;
using System.Text;

namespace Lon.UI
{
    class UIOut
    {
        public static UIOutDelegate MessageOut = null;
        public static void OutMessage(String txt)
        {
            UIOutDelegate tempDelegate = MessageOut;
            if(tempDelegate!=null)
            {
                tempDelegate(txt);
            }
        }
    }
}
