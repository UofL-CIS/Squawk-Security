﻿using System;
using System.Linq;
using PacketDotNet;
using SharpPcap;
using Squawk_Security.ClassLibrary.Models.Exceptions;

namespace Squawk_Security.ClassLibrary.Services
{
    public class SharpPcapSniffingService : ISniffingService
    {
        private readonly ICaptureDevice _captureDevice;

        public event EventHandler OnPcapArrival;

        public SharpPcapSniffingService()
        {
            var desiredLinkLayer = LinkLayers.Ethernet;
            var devices = CaptureDeviceList.Instance;

            if (devices.Count == 0)
                throw new NoCaptureDevicesAvailableException();
            
            if (devices.All(d => d.LinkType != desiredLinkLayer))
                throw new NoCaptureDevicesAvailableException("No ethernet device was available for capture");

            _captureDevice = devices.First(d => d.LinkType == desiredLinkLayer);
        }

        ~SharpPcapSniffingService()
        {
            StopListening();
        }

        public void StartListening()
        {
            _captureDevice.OnPacketArrival += CaptureDeviceOnOnPacketArrival;
            _captureDevice.StartCapture();
        }

        public void StopListening()
        {
            _captureDevice.OnPacketArrival -= CaptureDeviceOnOnPacketArrival;
            _captureDevice.StopCapture();
        }

        private void CaptureDeviceOnOnPacketArrival(object sender, CaptureEventArgs e) =>
            OnPcapArrival(this, e);
    }
}
