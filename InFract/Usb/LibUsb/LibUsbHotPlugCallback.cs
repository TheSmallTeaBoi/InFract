using InFract.Usb.LibUsb.Native;

namespace InFract.Usb.LibUsb;

public delegate bool LibUsbHotPlugCallback(LibUsbDevice device, libusb_hotplug_event eventType);
