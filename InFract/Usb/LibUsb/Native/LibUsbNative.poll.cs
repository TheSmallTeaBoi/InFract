using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace InFract.Usb.LibUsb.Native;

public static unsafe partial class LibUsbNative
{
	[LibraryImport(LibraryName)]
	public static partial int libusb_try_lock_events(libusb_context* ctx);

	[LibraryImport(LibraryName)]
	public static partial void libusb_lock_events(libusb_context* ctx);

	[LibraryImport(LibraryName)]
	public static partial void libusb_unlock_events(libusb_context* ctx);

	[LibraryImport(LibraryName)]
	public static partial int libusb_event_handling_ok(libusb_context* ctx);

	[LibraryImport(LibraryName)]
	public static partial int libusb_event_handler_active(libusb_context* ctx);

	[LibraryImport(LibraryName)]
	public static partial void libusb_interrupt_event_handler(libusb_context* ctx);

	[LibraryImport(LibraryName)]
	public static partial void libusb_lock_event_waiters(libusb_context* ctx);

	[LibraryImport(LibraryName)]
	public static partial void libusb_unlock_event_waiters(libusb_context* ctx);

	[LibraryImport(LibraryName)]
	public static partial int libusb_wait_for_event(libusb_context* ctx, timeval* tv);

	[LibraryImport(LibraryName)]
	public static partial int libusb_handle_events_timeout_completed(libusb_context* ctx, timeval* tv, int* completed);

	[LibraryImport(LibraryName)]
	public static partial int libusb_handle_events_timeout(libusb_context* ctx, timeval* tv);

	[LibraryImport(LibraryName)]
	public static partial int libusb_handle_events(libusb_context* ctx);

	[LibraryImport(LibraryName)]
	public static partial int libusb_handle_events_completed(libusb_context* ctx, int* completed);

	[LibraryImport(LibraryName)]
	public static partial int libusb_handle_events_locked(libusb_context* ctx, timeval* tv);

	[LibraryImport(LibraryName)]
	public static partial int libusb_pollfds_handle_timeouts(libusb_context* ctx);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_next_timeout(libusb_context* ctx, timeval* tv);

	// [LibraryImport(LibraryName)]
	// public static partial void libusb_set_pollfd_notifiers(
	// 	libusb_context* ctx,
	// 	libusb_pollfd_added_cb added_cb,
	// 	libusb_pollfd_removed_cb removed_cb,
	// 	void* user_data
	// );

	// [LibraryImport(LibraryName)]
	// public static partial libusb_pollfd** libusb_get_pollfds(libusb_context* ctx);

	// [LibraryImport(LibraryName)]
	// public static partial void libusb_free_pollfds(libusb_pollfd** pollfds);
}
