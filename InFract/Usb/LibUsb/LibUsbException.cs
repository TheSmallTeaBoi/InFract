using System.Runtime.InteropServices;
using InFract.Usb.LibUsb.Native;
using static InFract.Usb.LibUsb.Native.LibUsbNative;

namespace InFract.Usb.LibUsb;

public unsafe class LibUsbException : Exception
{
	public libusb_error Error { get; }

	public LibUsbException(string? message) : base(message)
	{
	}

	public LibUsbException(libusb_error error) : base($"{error}: {Marshal.PtrToStringUTF8((nint)libusb_strerror(error))}")
	{
		Error = error;
	}

	public static int ThrowIfError(int error)
	{
		if (error < 0) throw new LibUsbException((libusb_error)error);
		return error;
	}

	public static void ThrowIfError(libusb_error error) => ThrowIfError((int)error);
	public static nint ThrowIfError(nint error) => ThrowIfError((int)error);
}
