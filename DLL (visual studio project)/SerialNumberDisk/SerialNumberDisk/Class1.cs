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

            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive where index = 0");
            foreach (ManagementObject wmi_HD in moSearcher.Get())
            {
                HardDrive hd = new HardDrive();  // User Defined Class
                hd.SerialNo = wmi_HD["SerialNumber"].ToString();
                s = hd.SerialNo;
                //break; //прерываем процесс
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

//примеры команд

//все диски
//ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

//все диски типа USB
//ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive where interfaceType='USB'");

//все диски типа IDE
//ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive where interfaceType='IDE'");

//диск с индексом 0
//ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive where index = 0");

//все диски со стокой 'ATA Device' в поле 'Model'
//ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive where Model like '%ATA Device%'");

//диск со стокой 'PHYSICALDRIVE0' в поле 'Name'
//ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive where Name like '%PHYSICALDRIVE0%'");