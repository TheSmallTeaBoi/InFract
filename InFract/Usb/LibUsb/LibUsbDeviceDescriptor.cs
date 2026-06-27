using InFract.Usb.LibUsb.Native;

namespace InFract.Usb.LibUsb;

public class LibUsbDeviceDescriptor
{
	public byte DescriptorType { get; }
	public ushort Usb { get; }
	public libusb_class_code DeviceClass { get; }
	public byte DeviceSubClass { get; }
	public byte DeviceProtocol { get; }
	public byte MaxPacketSize0 { get; }
	public ushort IdVendor { get; }
	public ushort IdProduct { get; }
	public ushort Device { get; }
	public byte Manufacturer { get; }
	public byte Product { get; }
	public byte SerialNumber { get; }
	public byte ConfigurationCount { get; }

	internal LibUsbDeviceDescriptor(libusb_device_descriptor descriptor)
	{
		DescriptorType = descriptor.bDescriptorType;
		Usb = descriptor.bcdUSB;
		DeviceClass = (libusb_class_code)descriptor.bDeviceClass;
		DeviceSubClass = descriptor.bDeviceSubClass;
		DeviceProtocol = descriptor.bDeviceProtocol;
		MaxPacketSize0 = descriptor.bMaxPacketSize0;
		IdVendor = descriptor.idVendor;
		IdProduct = descriptor.idProduct;
		Device = descriptor.bcdDevice;
		Manufacturer = descriptor.iManufacturer;
		Product = descriptor.iProduct;
		SerialNumber = descriptor.iSerialNumber;
		ConfigurationCount = descriptor.bNumConfigurations;
	}
}
