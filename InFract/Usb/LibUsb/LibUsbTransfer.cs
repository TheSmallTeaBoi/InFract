using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using InFract.Usb.LibUsb.Native;
using static InFract.Usb.LibUsb.Native.libusb_error;
using static InFract.Usb.LibUsb.Native.libusb_transfer_flags;
using static InFract.Usb.LibUsb.Native.libusb_transfer_type;
using static InFract.Usb.LibUsb.Native.LibUsbNative;

namespace InFract.Usb.LibUsb;

public unsafe struct LibUsbTransfer : IDisposable
{
	public libusb_transfer_flags Flags
	{
		get => (libusb_transfer_flags)transfer->flags;
		set => transfer->flags = (byte)value;
	}

	public byte Endpoint
	{
		get => transfer->endpoint;
		set => transfer->endpoint = value;
	}

	public libusb_transfer_type Type
	{
		get => (libusb_transfer_type)transfer->type;
		set => transfer->type = (byte)value;
	}

	public uint Timeout
	{
		get => transfer->timeout;
		set => transfer->timeout = value;
	}

	public libusb_transfer_status Status => transfer->status;

	public nint UserData
	{
		get => transfer->user_data;
		set => transfer->user_data = value;
	}

	public int IsoPackets
	{
		get => transfer->num_iso_packets;
		set => transfer->num_iso_packets = value;
	}

	public uint StreamId
	{
		get => libusb_transfer_get_stream_id(transfer);
		set => libusb_transfer_set_stream_id(transfer, value);
	}

	public int WriteLength
	{
		get => transfer->length;
		set => transfer->length = value;
	}

	public int ReadLength => transfer->actual_length;

	public ref byte Buffer => ref Unsafe.AsRef<byte>(transfer->buffer);

	public Span<byte> WriteBuffer => new(transfer->buffer, transfer->length);

	public ReadOnlySpan<byte> ReadBuffer => new(transfer->buffer, transfer->actual_length);

	private readonly libusb_transfer* transfer;

	public LibUsbTransfer(libusb_transfer* transfer)
	{
		this.transfer = transfer;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static LibUsbTransfer Allocate(int isoPackets) => new(libusb_alloc_transfer(isoPackets));

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static LibUsbTransfer Allocate(int isoPackets, int bufferSize)
	{
		libusb_transfer* transfer = libusb_alloc_transfer(isoPackets);
		transfer->flags = (byte)LIBUSB_TRANSFER_FREE_BUFFER;
		transfer->buffer = (byte*)NativeMemory.Alloc((nuint)bufferSize);
		transfer->length = bufferSize;
		return new(transfer);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetDevice(LibUsbDeviceHandle handle) => transfer->dev_handle = handle.Handle;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetCallback(delegate* unmanaged<libusb_transfer*, void> callback) => transfer->callback = callback;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FillBulk(LibUsbDeviceHandle device, byte endpoint, uint timeout)
	{
		transfer->type = (byte)LIBUSB_TRANSFER_TYPE_BULK;
		transfer->dev_handle = device.Handle;
		transfer->endpoint = endpoint;
		transfer->timeout = timeout;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FillInterrupt(LibUsbDeviceHandle device, byte endpoint, uint timeout)
	{
		transfer->type = (byte)LIBUSB_TRANSFER_TYPE_INTERRUPT;
		transfer->dev_handle = device.Handle;
		transfer->endpoint = endpoint;
		transfer->timeout = timeout;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FillIsochronous(LibUsbDeviceHandle device, byte endpoint, int isoPackets, uint timeout)
	{
		transfer->type = (byte)LIBUSB_TRANSFER_TYPE_ISOCHRONOUS;
		transfer->dev_handle = device.Handle;
		transfer->endpoint = endpoint;
		transfer->timeout = timeout;
		transfer->num_iso_packets = isoPackets;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public libusb_error Submit() => (libusb_error)libusb_submit_transfer(transfer);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Cancel()
	{
		libusb_error error = (libusb_error)libusb_cancel_transfer(transfer);
		if (error == LIBUSB_ERROR_NOT_FOUND) return false;

		LibUsbException.ThrowIfError(error);
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Dispose() => libusb_free_transfer(transfer);
}
