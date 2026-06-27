using System.Runtime.InteropServices;
using InFract.Usb.LibUsb.Native;
using static InFract.Usb.LibUsb.Native.LibUsbNative;

namespace InFract.Usb.LibUsb;

public unsafe class LibUsbEndpointDescriptor
{
	public libusb_descriptor_type DescriptorType { get; }
	public byte EndpointAddress { get; }
	public byte Attributes { get; }
	public ushort MaxPacketSize { get; }
	public byte Interval { get; }
	public byte Refresh { get; }
	public byte SynchAddress { get; }
	public byte[] Extra { get; }

	public libusb_endpoint_direction Direction => (libusb_endpoint_direction)(EndpointAddress & LIBUSB_ENDPOINT_DIR_MASK);

	public libusb_endpoint_transfer_type TransferType => (libusb_endpoint_transfer_type)(Attributes & LIBUSB_TRANSFER_TYPE_MASK);

	internal LibUsbEndpointDescriptor(libusb_endpoint_descriptor descriptor)
	{
		DescriptorType = (libusb_descriptor_type)descriptor.bDescriptorType;
		EndpointAddress = descriptor.bEndpointAddress;
		Attributes = descriptor.bmAttributes;
		MaxPacketSize = descriptor.wMaxPacketSize;
		Interval = descriptor.bInterval;
		Refresh = descriptor.bRefresh;
		SynchAddress = descriptor.bSynchAddress;

		if (descriptor.extra != null)
		{
			Extra = new byte[descriptor.extra_length];
			Marshal.Copy((nint)descriptor.extra, Extra, 0, Extra.Length);
		}
		else
		{
			Extra = [];
		}
	}
}
