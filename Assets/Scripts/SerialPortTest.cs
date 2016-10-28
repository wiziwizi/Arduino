﻿using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class SerialPortTest : MonoBehaviour 
{
	//Setup parameters to connect to Arduino
	public static SerialPort sp = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
	public static string strIn;        

	// Use this for initialization
	void Start () 
	{
		OpenConnection();
	}

	void Update()
	{
		//Read incoming data
		strIn = sp.ReadLine();
		print(strIn);
		//You can also send data like this
		//sp.Write("1");

	}

	//Function connecting to Arduino
	public void OpenConnection() 
	{
		if (sp != null) 
		{
			if (sp.IsOpen) 
			{
				sp.Close();
				//message = "Closing port, because it was already open!";
			}
			else 
			{
				sp.Open();  // opens the connection
				sp.ReadTimeout = 50;  // sets the timeout value before reporting error
				//message = "Port Opened!";
			}
		}
		else 
		{
			if (sp.IsOpen)
			{
				print("Port is already open");
			}
			else 
			{
				print("Port == null");
			}
		}
	}

	void OnApplicationQuit() 
	{
		sp.Close();
	}
}