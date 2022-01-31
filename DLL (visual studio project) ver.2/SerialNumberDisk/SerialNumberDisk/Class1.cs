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

        [DllExport("GetModelFromDrive", CallingConvention.Cdecl)]
        public static string GetModelFromDrive(string driveLetter)
        {
            // Must be 2 characters long.
            // Function expects "C:" or "D:" etc...
            if (driveLetter.Length != 2)
                return "";

            try
            {
                using (var partitions = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_LogicalDisk.DeviceID='" + driveLetter +
                                                 "'} WHERE ResultClass=Win32_DiskPartition"))
                {
                    foreach (var partition in partitions.Get())
                    {
                        using (var drives = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" +
                                                             partition["DeviceID"] +
                                                             "'} WHERE ResultClass=Win32_DiskDrive"))
                        {
                            foreach (var drive in drives.Get())
                            {
                                return (string)drive["SerialNumber"];
                            }
                        }
                    }
                }
            }
            catch
            {
                return "<unknown>";
            }

            // Not Found
            return "<unknown>";
        }


    }

}

//код взят из https://stackoverflow.com/questions/27628965/get-drive-model-from-drive-letter