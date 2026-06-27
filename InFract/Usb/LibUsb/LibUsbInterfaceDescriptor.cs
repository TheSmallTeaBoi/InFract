using System.Runtime.InteropServices;
using InFract.Usb.LibUsb.Native;

namespace InFract.Usb.LibUsb;

public unsafe class LibUsbInterfaceDescriptor
{
	public libusb_descriptor_type DescriptorType { get; }
	public byte InterfaceNumber { get; }
	public byte AlternateSetting { get; }
	public libusb_class_code InterfaceClass { get; }
	public byte InterfaceSubClass { get; }
	public byte InterfaceProtocol { get; }
	public byte Interface { get; }
	public LibUsbEndpointDescriptor[] Endpoints { get; }
	public byte[] Extra { get; }

	internal LibUsbInterfaceDescriptor(libusb_interface_descriptor descriptor)
	{
		DescriptorType = (libusb_descriptor_type)descriptor.bDescriptorType;
		InterfaceNumber = descriptor.bInterfaceNumber;
		AlternateSetting = descriptor.bAlternateSetting;
		InterfaceClass = (libusb_class_code)descriptor.bInterfaceClass;
		InterfaceSubClass = descriptor.bInterfaceSubClass;
		InterfaceProtocol = descriptor.bInterfaceProtocol;
		Interface = descriptor.iInterface;

		Endpoints = new LibUsbEndpointDescriptor[descriptor.bNumEndpoints];
		for (int i = 0; i < Endpoints.Length; i++)
		{
			Endpoints[i] = new(descriptor.endpoint[i]);
		}

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
