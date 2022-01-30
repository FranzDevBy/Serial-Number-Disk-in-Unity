using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Runtime.InteropServices;

namespace SerialNumberDisk
{

    public class Class1
{

        [DllExport("Add", CallingConvention.Cdecl)]
        public static string Add(string s)
        {
        ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
        foreach (ManagementObject wmi_HD in moSearcher.Get())
        {
            HardDrive hd = new HardDrive();  // User Defined Class
            hd.SerialNo = wmi_HD["SerialNumber"].ToString();
            s = hd.SerialNo;
            break; //прерываем процесс
        }

        return s;
        }
        class HardDrive
        {
            private string serialNo = null;
            public string SerialNo
            {
            get { return serialNo; }
            set { serialNo = value; }
            }
        }

    }

}