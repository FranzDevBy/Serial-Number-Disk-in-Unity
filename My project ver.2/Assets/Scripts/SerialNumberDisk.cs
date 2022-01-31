using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.InteropServices;

public class SerialNumberDisk : MonoBehaviour
{
    [DllImportAttribute("SerialNumberDisk.dll")] //����������� ����������
    public static extern String GetModelFromDrive(string drive); //��������� ����������
    public Text myText;

    void Start()
    {
        const string drive = "C:";
        Debug.Log(GetModelFromDrive(drive));
        myText.text = GetModelFromDrive(drive);
    }

}