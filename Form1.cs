using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIA;
using WIAVIDEOLib;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        string DeviceID;
        WiaVideo mVid;

        public Form1()
        {
            InitializeComponent();
            DeviceID = null;
            //mVid = new WiaVideo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommonDialogClass cdcMine = new CommonDialogClass();
            Device d = cdcMine.ShowSelectDevice(WiaDeviceType.UnspecifiedDeviceType, true, false);

            if (d != null)
            {
                //get the devide ID
                this.DeviceID = d.DeviceID;
            }
            else
            {
                //no scanner chosen
                return;
            }
            CommonDialogClass WiaCommonDialog = new CommonDialogClass();
            DeviceManager manager = new DeviceManagerClass();
            Device WiaDev = null;
            foreach (WIA.DeviceInfo info in manager.DeviceInfos)
            {
                if (info.DeviceID == this.DeviceID)
                {
                    WIA.Properties infoprop = null;
                    infoprop = info.Properties;
                    //connect to scanner
                    WiaDev = info.Connect();
                    MessageBox.Show("GOOD");
                    //not very good coding practice. exit the IF when connected
                    break;
                }
            }
            //mVid.ImagesDirectory = "D:\\Downloads\\";
            //mVid.CreateVideoByWiaDevID(this.DeviceID, ref pictureBox1.Handle, 1, 1);  
        }
        
    }
}
