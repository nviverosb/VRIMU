﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.IO;

public class Transmitter : MonoBehaviour {

	public static Vector3 accelerometer;
	public static Vector3 Gaccel;
	public static Vector3 gyroscope;
	public static Vector3 magnetometer;

	private float LSB = 131;//LEAST SIGNIFICATN BIT
	private int range = 8;
	private Thread client;
	private HighRateTerminal server;
	private static object syncRoot = new Object();
	private static volatile Transmitter instance;


	private Transmitter(){}

	public static Transmitter Instance
	{
		get 
		{
			if (instance == null)
			{
				lock (syncRoot) 
				{
					if (instance == null) 
						instance = new Transmitter();
				}
			}
			return instance;
		}
	}

	void Start(){

		gyroscope = magnetometer = accelerometer = Vector3.zero;
		instance = new Transmitter ();
		server = FindObjectOfType<HighRateTerminal> ();
	}

	void Update(){

		if (server.isActive) {
			
			gyroscope = BluetoothClient.gyroscope;
			accelerometer = BluetoothClient.accelerometer;
			magnetometer = BluetoothClient.magnetometer;

			Gaccel = accelerometer*(range/LSB);
		} 
		else {
			gyroscope = accelerometer = magnetometer = Vector3.one;
		}
//		print (gyroscope + " " + accelerometer + " " + magnetometer);
	}


}
