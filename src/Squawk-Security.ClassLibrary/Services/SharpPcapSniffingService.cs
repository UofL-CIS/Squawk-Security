using System;
using System.Linq;
using PacketDotNet;
using Serilog;
using SharpPcap;
using SharpPcap.Npcap;
using Squawk_Security.ClassLibrary.Models.Exceptions;

namespace Squawk_Security.ClassLibrary.Services
{
    public class SharpPcapSniffingService : ISniffingService
    {
        private const LinkLayers DESIRED_LINK_LAYER = LinkLayers.Ethernet;
        private readonly ICaptureDevice _captureDevice;

        public event EventHandler OnPcapArrival;

        public SharpPcapSniffingService(ILogger logger)
        {
            var devices = CaptureDeviceList.Instance;

            if (devices.Count == 0)
                throw new NoCaptureDevicesAvailableException();
            
            foreach (var device in devices)
            {
                if (IsConnectedDevice(device))
                    _captureDevice = device;

                // Exit loop early if found desired device
                if (_captureDevice != null) break;
            }

            if (_captureDevice is null)
                throw new NoCaptureDevicesAvailableException($"No {DESIRED_LINK_LAYER} type device was available for capture");

            var deviceName = _captureDevice.Name;
            logger.Verbose("Listening on {deviceName}", deviceName);
        }

        ~SharpPcapSniffingService()
        {
            StopListening();
        }

        public void StartListening()
        {
            _captureDevice.OnPacketArrival += CaptureDeviceOnOnPacketArrival;
            _captureDevice.Open(DeviceMode.Promiscuous);
            _captureDevice.StartCapture();
        }

        public void StopListening()
        {
            _captureDevice.OnPacketArrival -= CaptureDeviceOnOnPacketArrival;
            _captureDevice.StopCapture();
            _captureDevice.Close();
        }

        /// <summary>
        /// Check if device's link layer is DESIRED_LINK_LAYER and has a netmask starting with 255.
        /// </summary>
        private bool IsConnectedDevice(ICaptureDevice device)
        {
            device.Open();

            var result = device.LinkType == DESIRED_LINK_LAYER && ((NpcapDevice) device).Addresses.Any(pcapAddress =>
                pcapAddress.Netmask?.ipAddress != null && pcapAddress.Netmask.ipAddress.ToString().StartsWith("255"));

            device.Close();

            return result;
        }

        private void CaptureDeviceOnOnPacketArrival(object sender, CaptureEventArgs e) =>
            OnPcapArrival(this, e);
    }
}
