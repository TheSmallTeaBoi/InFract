using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace InFract.Usb.LibUsb.Native;

public static unsafe partial class LibUsbNative
{
	[LibraryImport(LibraryName)]
	public static partial int libusb_control_transfer(
		libusb_device_handle* dev_handle,
		byte bmRequestType,
		byte bRequest,
		ushort wValue,
		ushort wIndex,
		byte* data,
		ushort wLength,
		uint timeout
	);

	[LibraryImport(LibraryName)]
	public static partial int libusb_bulk_transfer(
		libusb_device_handle* dev_handle,
		byte endpoint,
		byte* data,
		int length,
		int* transferred,
		uint timeout
	);

	[LibraryImport(LibraryName)]
	public static partial int libusb_interrupt_transfer(
		libusb_device_handle* dev_handle,
		byte endpoint,
		byte* data,
		int length,
		int* transferred,
		uint timeout
	);
}
