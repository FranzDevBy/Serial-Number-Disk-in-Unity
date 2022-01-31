using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.InteropServices;

public class SerialNumberDisk : MonoBehaviour
{
    [DllImportAttribute("SerialNumberDisk.dll")] //импортируем библиотеку
    public static extern String GetModelFromDrive(string drive); //объ€вл€ем переменную
    public Text myText;

    void Start()
    {
        const string drive = "C:";
        Debug.Log(GetModelFromDrive(drive));
        myText.text = GetModelFromDrive(drive);
    }

}