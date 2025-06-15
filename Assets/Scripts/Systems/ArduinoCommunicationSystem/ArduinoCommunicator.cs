using UnityEngine;
using System.IO.Ports;
namespace Systems.ArduinoCommunicationSystem
{
    public class ArduinoCommunicator : MonoBehaviour
    {
        SerialPort port = new SerialPort("COM9", 115200);

        void Start()
        {
            port.Open();
        }

        void Update()
        {
            if (port.IsOpen)
            {
                port.WriteLine("Hello ESP32!");
                Debug.Log("Sent: Hello ESP32!");
            }
        }

        void OnApplicationQuit()
        {
            if (port.IsOpen)
                port.Close();
        }
    }
}