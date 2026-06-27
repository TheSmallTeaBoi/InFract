using System.Runtime.InteropServices;
using InFract.Usb.LibUsb.Native;
using static InFract.Usb.LibUsb.Native.LibUsbNative;

namespace InFract.Usb.LibUsb;

public unsafe class LibUsbConfigDescriptor : IDisposable
{
	public byte DescriptorType { get; }
	public ushort TotalLength { get; }
	public byte ConfigurationValue { get; }
	public byte Configuration { get; }
	public byte Attributes { get; }
	public byte MaxPower { get; }
	public LibUsbInterfaceDescriptor[][] Interfaces { get; }
	public byte[] Extra { get; }

	private readonly libusb_config_descriptor* config;
	
	internal LibUsbConfigDescriptor(libusb_config_descriptor* config)
	{
		this.config = config;
		DescriptorType = config->bDescriptorType;
		TotalLength = config->wTotalLength;
		ConfigurationValue = config->bConfigurationValue;
		Configuration = config->iConfiguration;
		Attributes = config->bmAttributes;
		MaxPower = config->MaxPower;

		Interfaces = new LibUsbInterfaceDescriptor[config->bNumInterfaces][];
		for (int i = 0; i < Interfaces.Length; i++)
		{
			libusb_interface itf = config->interface_[i];
			
			LibUsbInterfaceDescriptor[] descriptors = new LibUsbInterfaceDescriptor[itf.num_altsetting];
			for (int j = 0; j < descriptors.Length; j++)
			{
				descriptors[j] = new(itf.altsetting[j]);
			}
			
			Interfaces[i] = descriptors;
		}

		if (config->extra != null)
		{
			Extra = new byte[config->extra_length];
			Marshal.Copy((nint)config->extra, Extra, 0, Extra.Length);
		}
		else
		{
			Extra = [];
		}
	}

	private void ReleaseUnmanagedResources()
	{
		libusb_free_config_descriptor(config);
	}

	public void Dispose()
	{
		ReleaseUnmanagedResources();
		GC.SuppressFinalize(this);
	}

	~LibUsbConfigDescriptor() => ReleaseUnmanagedResources();
}
