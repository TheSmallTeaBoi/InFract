using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace InFract.Usb.LibUsb.Native;

public enum libusb_error
{
	LIBUSB_SUCCESS = 0,
	LIBUSB_ERROR_IO = -1,
	LIBUSB_ERROR_INVALID_PARAM = -2,
	LIBUSB_ERROR_ACCESS = -3,
	LIBUSB_ERROR_NO_DEVICE = -4,
	LIBUSB_ERROR_NOT_FOUND = -5,
	LIBUSB_ERROR_BUSY = -6,
	LIBUSB_ERROR_TIMEOUT = -7,
	LIBUSB_ERROR_OVERFLOW = -8,
	LIBUSB_ERROR_PIPE = -9,
	LIBUSB_ERROR_INTERRUPTED = -10,
	LIBUSB_ERROR_NO_MEM = -11,
	LIBUSB_ERROR_NOT_SUPPORTED = -12,
	LIBUSB_ERROR_OTHER = -99,
}

public enum libusb_request_type : byte
{
	LIBUSB_REQUEST_TYPE_STANDARD = 0x00 << 5,
	LIBUSB_REQUEST_TYPE_CLASS = 0x01 << 5,
	LIBUSB_REQUEST_TYPE_VENDOR = 0x02 << 5,
	LIBUSB_REQUEST_TYPE_RESERVED = 0x03 << 5,
}

public enum libusb_standard_request : byte
{
	LIBUSB_REQUEST_GET_STATUS = 0x00,
	LIBUSB_REQUEST_CLEAR_FEATURE = 0x01,
	LIBUSB_REQUEST_SET_FEATURE = 0x03,
	LIBUSB_REQUEST_SET_ADDRESS = 0x05,
	LIBUSB_REQUEST_GET_DESCRIPTOR = 0x06,
	LIBUSB_REQUEST_SET_DESCRIPTOR = 0x07,
	LIBUSB_REQUEST_GET_CONFIGURATION = 0x08,
	LIBUSB_REQUEST_SET_CONFIGURATION = 0x09,
	LIBUSB_REQUEST_GET_INTERFACE = 0x0a,
	LIBUSB_REQUEST_SET_INTERFACE = 0x0b,
	LIBUSB_REQUEST_SYNCH_FRAME = 0x0c,
	LIBUSB_REQUEST_SET_SEL = 0x30,
	LIBUSB_SET_ISOCH_DELAY = 0x31,
}

public enum libusb_capability : uint
{
	LIBUSB_CAP_HAS_CAPABILITY = 0x0000U,
	LIBUSB_CAP_HAS_HOTPLUG = 0x0001U,
	LIBUSB_CAP_HAS_HID_ACCESS = 0x0100U,
	LIBUSB_CAP_SUPPORTS_DETACH_KERNEL_DRIVER = 0x0101U
}

public static unsafe partial class LibUsbNative
{
	[LibraryImport(LibraryName)]
	public static partial int libusb_has_capability(libusb_capability capability);

	[LibraryImport(LibraryName)]
	public static partial byte* libusb_error_name(libusb_error error_code);

	// [LibraryImport(LibraryName)]
	// public static partial libusb_version* libusb_get_version();

	[LibraryImport(LibraryName)]
	public static partial ushort libusb_cpu_to_le16(ushort x);

	[LibraryImport(LibraryName)]
	public static partial int libusb_setlocale(byte* locale);
	 
	[LibraryImport(LibraryName)]
	public static partial byte* libusb_strerror(libusb_error errcode);
}
