using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace PROJE
{
    class Message
    {
        public static void Show(string msg, int wdth, int hght, bool isError)
        {
            BoxMessage.message = msg;
            BoxMessage.width = wdth;
            BoxMessage.height = hght;

            if (isError)
            {
                SystemSounds.Hand.Play();
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }

            BoxMessage messageBox = new BoxMessage();
            messageBox.ShowDialog();
        } //büyük message box

        public static void Show(string msg, bool isError)
        {
            BoxMessage.message = msg;
            BoxMessage.width = 400;
            BoxMessage.height = 166;

            if (isError)
            {
                SystemSounds.Hand.Play();
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }

            BoxMessage messageBox = new BoxMessage();
            messageBox.ShowDialog();
        } // normal message box

        public static bool Show(string msg)
        {
            SystemSounds.Hand.Play();
            YesNoMessage.message = msg;
            YesNoMessage.width = 400;
            YesNoMessage.height = 166;

            YesNoMessage yesNoMessage = new YesNoMessage();
            yesNoMessage.ShowDialog();
            return YesNoMessage.isYes;
        } // yes no message box

        public static bool Show(string msg, int wdth, int hght)
        {
            SystemSounds.Hand.Play();
            YesNoMessage.message = msg;
            YesNoMessage.width = wdth;
            YesNoMessage.height = hght;

            YesNoMessage yesNoMessage = new YesNoMessage();
            yesNoMessage.ShowDialog();
            return YesNoMessage.isYes;
        } // normal yes no büyük message box
    }
}
