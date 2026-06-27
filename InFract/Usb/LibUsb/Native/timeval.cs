using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace InFract.Usb.LibUsb.Native;

[StructLayout(LayoutKind.Sequential)]
public struct timeval
{
	public nint tv_sec;
	public nint tv_usec;
}
