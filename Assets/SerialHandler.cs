using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class SerialHandler : MonoBehaviour
{
	public string portName = "/dev/cu.usbserial-MWHKY0X";
	public int baudRate = 115200;

	private SerialPort serialPort_;
	private Thread thread_;
	private bool isRunning_ = false;

	private string message_;
	private bool isNewMessageReceived_ = false;

	void Start()
	{
		Debug.LogWarning("Start");
		Open();
	}

	void Update()
	{



		if (isNewMessageReceived_)
		{
			OnDataReceived(message_);


			string[] Xdata = message_.Split('X');

			if (Xdata.Length == 2) {

				TW d1 = GetComponent<TW>();


				string[] XYZ = Xdata [1].Split (';');
				string[] SensorData = Xdata [0].Split (';');

				if (SensorData [5] == d1.SensorIdentity) {
					
						float X = float.Parse (XYZ [1]);
						float Y = float.Parse (XYZ [2]);
						float Z = float.Parse (XYZ [3]);

						//	Debug.Log (XYZ [1] + "X");
						//	Debug.Log (XYZ [2] + "Y");
						//	Debug.Log (XYZ [3] + "Z");

						Debug.Log (XYZ [1] + XYZ [2] + XYZ [3]);
						Debug.Log (SensorData [5]);


						transform.rotation = (Quaternion.Euler (X, 0, Y));
					}
			}
		}
	}
	void OnDestroy()
	{
		Debug.LogWarning("OnDestroy");
		Close();
	}

	private void Open()
	{
		serialPort_ = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
		serialPort_.Open();

		isRunning_ = true;

		thread_ = new Thread(Read);
		thread_.Start();
	}

	private void Read()
	{
		while (isRunning_ && serialPort_ != null && serialPort_.IsOpen)
		{
			try
			{
				message_ = serialPort_.ReadLine();


				// Debug.LogWarning(message_);
				isNewMessageReceived_ = true;
			}
			catch (System.Exception e)
			{
				Debug.LogWarning(e.Message);
			}
		}
	}

	private void Close()
	{
		isRunning_ = false;

		if (thread_ != null && thread_.IsAlive)
		{
			thread_.Join();
		}

		if (serialPort_ != null && serialPort_.IsOpen)
		{
			serialPort_.Close();
			serialPort_.Dispose();
		}
	}

	void OnDataReceived(string message)
	{
		var data = message.Split(
			new string[] { "\t" }, System.StringSplitOptions.None);
		if (data.Length < 2) return;

		try
		{
		}
		catch (System.Exception e)
		{
			Debug.LogWarning(e.Message);
		}
	}

}