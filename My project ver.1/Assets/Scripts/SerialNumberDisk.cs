using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.InteropServices;

public class SerialNumberDisk : MonoBehaviour
{
    [DllImportAttribute("SerialNumberDisk.dll")] //����������� ����������
    public static extern String Add(string s); //��������� ����������
    public Text myText;

    void Start()
    {
        Debug.Log(Add(null));
        myText.text = Add(null);
    }

}
