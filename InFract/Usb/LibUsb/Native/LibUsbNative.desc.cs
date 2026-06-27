using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace InFract.Usb.LibUsb.Native;

public enum libusb_class_code : byte
{
	LIBUSB_CLASS_PER_INTERFACE = 0x00,
	LIBUSB_CLASS_AUDIO = 0x01,
	LIBUSB_CLASS_COMM = 0x02,
	LIBUSB_CLASS_HID = 0x03,
	LIBUSB_CLASS_PHYSICAL = 0x05,
	LIBUSB_CLASS_IMAGE = 0x06,
	LIBUSB_CLASS_PTP = LIBUSB_CLASS_IMAGE, // legacy name from libusb-0.1 usb.h
	LIBUSB_CLASS_PRINTER = 0x07,
	LIBUSB_CLASS_MASS_STORAGE = 0x08,
	LIBUSB_CLASS_HUB = 0x09,
	LIBUSB_CLASS_DATA = 0x0a,
	LIBUSB_CLASS_SMART_CARD = 0x0b,
	LIBUSB_CLASS_CONTENT_SECURITY = 0x0d,
	LIBUSB_CLASS_VIDEO = 0x0e,
	LIBUSB_CLASS_PERSONAL_HEALTHCARE = 0x0f,
	LIBUSB_CLASS_AUDIO_VIDEO = 0x10,
	LIBUSB_CLASS_BILLBOARD = 0x11,
	LIBUSB_CLASS_TYPE_C_BRIDGE = 0x12,
	LIBUSB_CLASS_BULK_DISPLAY_PROTOCOL = 0x13,
	LIBUSB_CLASS_MCTP = 0x14,
	LIBUSB_CLASS_I3C = 0x3c,
	LIBUSB_CLASS_DIAGNOSTIC_DEVICE = 0xdc,
	LIBUSB_CLASS_WIRELESS = 0xe0,
	LIBUSB_CLASS_MISCELLANEOUS = 0xef,
	LIBUSB_CLASS_APPLICATION = 0xfe,
	LIBUSB_CLASS_VENDOR_SPEC = 0xff,
}

public enum libusb_descriptor_type : byte
{
	LIBUSB_DT_DEVICE = 0x01,
	LIBUSB_DT_CONFIG = 0x02,
	LIBUSB_DT_STRING = 0x03,
	LIBUSB_DT_INTERFACE = 0x04,
	LIBUSB_DT_ENDPOINT = 0x05,
	LIBUSB_DT_INTERFACE_ASSOCIATION = 0x0b,
	LIBUSB_DT_BOS = 0x0f,
	LIBUSB_DT_DEVICE_CAPABILITY = 0x10,
	LIBUSB_DT_HID = 0x21,
	LIBUSB_DT_REPORT = 0x22,
	LIBUSB_DT_PHYSICAL = 0x23,
	LIBUSB_DT_HUB = 0x29,
	LIBUSB_DT_SUPERSPEED_HUB = 0x2a,
	LIBUSB_DT_SS_ENDPOINT_COMPANION = 0x30,
}

public enum libusb_endpoint_direction : byte
{
	LIBUSB_ENDPOINT_OUT = 0x00,
	LIBUSB_ENDPOINT_IN = 0x80,
}

public enum libusb_endpoint_transfer_type : byte
{
	LIBUSB_ENDPOINT_TRANSFER_TYPE_CONTROL = 0x0,
	LIBUSB_ENDPOINT_TRANSFER_TYPE_ISOCHRONOUS = 0x1,
	LIBUSB_ENDPOINT_TRANSFER_TYPE_BULK = 0x2,
	LIBUSB_ENDPOINT_TRANSFER_TYPE_INTERRUPT = 0x3,
}

public enum libusb_iso_sync_type : byte
{
	LIBUSB_ISO_SYNC_TYPE_NONE = 0x0,
	LIBUSB_ISO_SYNC_TYPE_ASYNC = 0x1,
	LIBUSB_ISO_SYNC_TYPE_ADAPTIVE = 0x2,
	LIBUSB_ISO_SYNC_TYPE_SYNC = 0x3,
}

public enum libusb_iso_usage_type : byte
{
	LIBUSB_ISO_USAGE_TYPE_DATA = 0x0,
	LIBUSB_ISO_USAGE_TYPE_FEEDBACK = 0x1,
	LIBUSB_ISO_USAGE_TYPE_IMPLICIT = 0x2,
}

[Flags]
public enum libusb_supported_speed : byte
{
	LIBUSB_LOW_SPEED_OPERATION = 1 << 0,
	LIBUSB_FULL_SPEED_OPERATION = 1 << 1,
	LIBUSB_HIGH_SPEED_OPERATION = 1 << 2,
	LIBUSB_SUPER_SPEED_OPERATION = 1 << 3,
}

[Flags]
public enum libusb_usb_2_0_extension_attributes : byte
{
	LIBUSB_BM_LPM_SUPPORT = 1 << 1,
}

[Flags]
public enum libusb_ss_usb_device_capability_attributes : byte
{
	LIBUSB_BM_LTM_SUPPORT = 1 << 1,
}

public enum libusb_bos_type : byte
{
	LIBUSB_BT_WIRELESS_USB_DEVICE_CAPABILITY = 0x01,
	LIBUSB_BT_USB_2_0_EXTENSION = 0x02,
	LIBUSB_BT_SS_USB_DEVICE_CAPABILITY = 0x03,
	LIBUSB_BT_CONTAINER_ID = 0x04,
	LIBUSB_BT_PLATFORM_DESCRIPTOR = 0x05,
	LIBUSB_BT_SUPERSPEED_PLUS_CAPABILITY = 0x0A,
}

public enum libusb_superspeedplus_sublink_attribute_sublink_type : byte
{
	LIBUSB_SSPLUS_ATTR_TYPE_SYM = 0,
	LIBUSB_SSPLUS_ATTR_TYPE_ASYM = 1,
}

public enum libusb_superspeedplus_sublink_attribute_sublink_direction : byte
{
	LIBUSB_SSPLUS_ATTR_DIR_RX = 0,
	LIBUSB_SSPLUS_ATTR_DIR_TX = 1,
}

public enum libusb_superspeedplus_sublink_attribute_exponent : byte
{
	LIBUSB_SSPLUS_ATTR_EXP_BPS = 0,
	LIBUSB_SSPLUS_ATTR_EXP_KBS = 1,
	LIBUSB_SSPLUS_ATTR_EXP_MBS = 2,
	LIBUSB_SSPLUS_ATTR_EXP_GBS = 3,
}

public enum libusb_superspeedplus_sublink_attribute_link_protocol : byte
{
	LIBUSB_SSPLUS_ATTR_PROT_SS = 0,
	LIBUSB_SSPLUS_ATTR_PROT_SSPLUS = 1,
}

public enum libusb_device_string_type
{
	LIBUSB_DEVICE_STRING_MANUFACTURER,
	LIBUSB_DEVICE_STRING_PRODUCT,
	LIBUSB_DEVICE_STRING_SERIAL_NUMBER,
	LIBUSB_DEVICE_STRING_COUNT, // The total number of string types.
}

[StructLayout(LayoutKind.Sequential)]
public struct libusb_device_descriptor
{
	public byte bLength;
	public byte bDescriptorType;
	public ushort bcdUSB;
	public byte bDeviceClass;
	public byte bDeviceSubClass;
	public byte bDeviceProtocol;
	public byte bMaxPacketSize0;
	public ushort idVendor;
	public ushort idProduct;
	public ushort bcdDevice;
	public byte iManufacturer;
	public byte iProduct;
	public byte iSerialNumber;
	public byte bNumConfigurations;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct libusb_config_descriptor
{
	public byte bLength;
	public byte bDescriptorType;
	public ushort wTotalLength;
	public byte bNumInterfaces;
	public byte bConfigurationValue;
	public byte iConfiguration;
	public byte bmAttributes;
	public byte MaxPower;
	public libusb_interface* interface_;
	public byte* extra;
	public int extra_length;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct libusb_interface
{
	public libusb_interface_descriptor* altsetting;
	public int num_altsetting;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct libusb_interface_descriptor
{
	public byte bLength;
	public byte bDescriptorType;
	public byte bInterfaceNumber;
	public byte bAlternateSetting;
	public byte bNumEndpoints;
	public byte bInterfaceClass;
	public byte bInterfaceSubClass;
	public byte bInterfaceProtocol;
	public byte iInterface;
	public libusb_endpoint_descriptor* endpoint;
	public byte* extra;
	public int extra_length;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct libusb_endpoint_descriptor
{
	public byte bLength;
	public byte bDescriptorType;
	public byte bEndpointAddress;
	public byte bmAttributes;
	public ushort wMaxPacketSize;
	public byte bInterval;
	public byte bRefresh;
	public byte bSynchAddress;
	public byte* extra;
	public int extra_length;
}

[StructLayout(LayoutKind.Sequential)]
public struct libusb_ss_endpoint_companion_descriptor
{
	public byte bLength;
	public byte bDescriptorType;
	public byte bMaxBurst;
	public byte bmAttributes;
	public ushort wBytesPerInterval;
}

[StructLayout(LayoutKind.Sequential)]
public struct libusb_bos_dev_capability_descriptor
{
	public byte bLength;
	public byte bDescriptorType;
	public byte bDevCapabilityType;

	// public byte dev_capability_data[LIBUSB_FLEXIBLE_ARRAY];
}

[StructLayout(LayoutKind.Sequential)]
public struct libusb_bos_descriptor
{
	public byte bLength;
	public byte bDescriptorType;
	public ushort wTotalLength;
	public byte bNumDeviceCaps;

	// public libusb_bos_dev_capability_descriptor* dev_capability[LIBUSB_FLEXIBLE_ARRAY];
}

[StructLayout(LayoutKind.Sequential)]
public struct libusb_usb_2_0_extension_descriptor
{
	public byte bLength;
	public byte bDescriptorType;
	public byte bDevCapabilityType;
	public uint bmAttributes;
}

[StructLayout(LayoutKind.Sequential)]
public struct libusb_ss_usb_device_capability_descriptor
{
	public byte bLength;
	public byte bDescriptorType;
	public byte bDevCapabilityType;
	public byte bmAttributes;
	public ushort wSpeedSupported;
	public byte bFunctionalitySupport;
	public byte bU1DevExitLat;
	public ushort bU2DevExitLat;
}

// TODO: check if this struct is accurate. enums may not be 4 bytes wide
[StructLayout(LayoutKind.Sequential)]
public struct libusb_ssplus_sublink_attribute
{
	public byte ssid;
	public libusb_superspeedplus_sublink_attribute_exponent exponent;
	public libusb_superspeedplus_sublink_attribute_sublink_type type;
	public libusb_superspeedplus_sublink_attribute_sublink_direction direction;
	public libusb_superspeedplus_sublink_attribute_link_protocol protocol;
	public ushort mantissa;
}

[StructLayout(LayoutKind.Sequential)]
public struct libusb_ssplus_usb_device_capability_descriptor
{
	public byte numSublinkSpeedAttributes;
	public byte numSublinkSpeedIDs;
	public byte ssid;
	public byte minRxLaneCount;
	public byte minTxLaneCount;

	// public libusb_ssplus_sublink_attribute sublinkSpeedAttributes[];
}

[StructLayout(LayoutKind.Sequential)]
public struct libusb_container_id_descriptor
{
	public byte bLength;
	public byte bDescriptorType;
	public byte bDevCapabilityType;
	public byte bReserved;
	public ContainerIDBuffer ContainerID;

	[InlineArray(16)]
	public struct ContainerIDBuffer
	{
		public byte e0;
	}
}

[StructLayout(LayoutKind.Sequential)]
public struct libusb_platform_descriptor
{
	public byte bLength;
	public byte bDescriptorType;
	public byte bDevCapabilityType;
	public byte bReserved;
	public PlatformCapabilityUUIDBuffer PlatformCapabilityUUID;

	// public byte CapabilityData[LIBUSB_FLEXIBLE_ARRAY];

	[InlineArray(16)]
	public struct PlatformCapabilityUUIDBuffer
	{
		public byte e0;
	}
}

[StructLayout(LayoutKind.Sequential)]
public struct libusb_interface_association_descriptor
{
	public byte bLength;
	public byte bDescriptorType;
	public byte bFirstInterface;
	public byte bInterfaceCount;
	public byte bFunctionClass;
	public byte bFunctionSubClass;
	public byte bFunctionProtocol;
	public byte iFunction;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct libusb_interface_association_descriptor_array
{
	public libusb_interface_association_descriptor* iad;
	public int length;
}

public static unsafe partial class LibUsbNative
{
	// Descriptor sizes per descriptor type
	public const byte LIBUSB_DT_DEVICE_SIZE = 18;
	public const byte LIBUSB_DT_CONFIG_SIZE = 9;
	public const byte LIBUSB_DT_INTERFACE_SIZE = 9;
	public const byte LIBUSB_DT_ENDPOINT_SIZE = 7;
	public const byte LIBUSB_DT_ENDPOINT_AUDIO_SIZE = 9; // Audio extension
	public const byte LIBUSB_DT_HUB_NONVAR_SIZE = 7;
	public const byte LIBUSB_DT_SS_ENDPOINT_COMPANION_SIZE = 6;
	public const byte LIBUSB_DT_BOS_SIZE = 5;
	public const byte LIBUSB_DT_DEVICE_CAPABILITY_SIZE = 3;
	public const byte LIBUSB_DT_INTERFACE_ASSOCIATION_SIZE = 8;

	// BOS descriptor sizes
	public const byte LIBUSB_BT_USB_2_0_EXTENSION_SIZE = 7;
	public const byte LIBUSB_BT_SS_USB_DEVICE_CAPABILITY_SIZE = 10;
	public const byte LIBUSB_BT_SSPLUS_USB_DEVICE_CAPABILITY_SIZE = 12;
	public const byte LIBUSB_BT_CONTAINER_ID_SIZE = 20;
	public const byte LIBUSB_BT_PLATFORM_DESCRIPTOR_MIN_SIZE = 20;

	// We unwrap the BOS => define its max size
	public const byte LIBUSB_DT_BOS_MAX_SIZE = (
		LIBUSB_DT_BOS_SIZE +
		LIBUSB_BT_USB_2_0_EXTENSION_SIZE +
		LIBUSB_BT_SS_USB_DEVICE_CAPABILITY_SIZE +
		LIBUSB_BT_CONTAINER_ID_SIZE
	);

	public const byte LIBUSB_ENDPOINT_ADDRESS_MASK = 0x0f; // in bEndpointAddress
	public const byte LIBUSB_ENDPOINT_DIR_MASK = 0x80;
	public const byte LIBUSB_TRANSFER_TYPE_MASK = 0x03; // in bmAttributes
	public const byte LIBUSB_ISO_SYNC_TYPE_MASK = 0x0c;
	public const byte LIBUSB_ISO_USAGE_TYPE_MASK = 0x30;

	public const int LIBUSB_DEVICE_STRING_BYTES_MAX = 384;

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_device_descriptor(libusb_device* dev, libusb_device_descriptor* desc);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_active_config_descriptor(libusb_device* dev, libusb_config_descriptor** config);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_config_descriptor(
		libusb_device* dev,
		byte config_index,
		libusb_config_descriptor** config
	);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_config_descriptor_by_value(
		libusb_device* dev,
		byte bConfigurationValue,
		libusb_config_descriptor** config
	);

	[LibraryImport(LibraryName)]
	public static partial void libusb_free_config_descriptor(libusb_config_descriptor* config);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_ss_endpoint_companion_descriptor(
		libusb_context* ctx,
		libusb_endpoint_descriptor* endpoint,
		libusb_ss_endpoint_companion_descriptor** ep_comp
	);

	[LibraryImport(LibraryName)]
	public static partial void libusb_free_ss_endpoint_companion_descriptor(libusb_ss_endpoint_companion_descriptor* ep_comp);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_bos_descriptor(
		libusb_device_handle* dev_handle,
		libusb_bos_descriptor** bos
	);

	[LibraryImport(LibraryName)]
	public static partial void libusb_free_bos_descriptor(libusb_bos_descriptor* bos);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_usb_2_0_extension_descriptor(
		libusb_context* ctx,
		libusb_bos_dev_capability_descriptor* dev_cap,
		libusb_usb_2_0_extension_descriptor** usb_2_0_extension
	);

	[LibraryImport(LibraryName)]
	public static partial void libusb_free_usb_2_0_extension_descriptor(
		libusb_usb_2_0_extension_descriptor*
			usb_2_0_extension
	);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_ss_usb_device_capability_descriptor(
		libusb_context* ctx,
		libusb_bos_dev_capability_descriptor* dev_cap,
		libusb_ss_usb_device_capability_descriptor** ss_usb_device_cap
	);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_ssplus_usb_device_capability_descriptor(
		libusb_context* ctx,
		libusb_bos_dev_capability_descriptor* dev_cap,
		libusb_ssplus_usb_device_capability_descriptor** ssplus_usb_device_cap
	);

	[LibraryImport(LibraryName)]
	public static partial void libusb_free_ssplus_usb_device_capability_descriptor(
		libusb_ssplus_usb_device_capability_descriptor* ssplus_usb_device_cap
	);

	[LibraryImport(LibraryName)]
	public static partial void libusb_free_ss_usb_device_capability_descriptor(
		libusb_ss_usb_device_capability_descriptor* ss_usb_device_cap
	);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_container_id_descriptor(
		libusb_context* ctx,
		libusb_bos_dev_capability_descriptor* dev_cap,
		libusb_container_id_descriptor** container_id
	);

	[LibraryImport(LibraryName)]
	public static partial void libusb_free_container_id_descriptor(libusb_container_id_descriptor* container_id);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_platform_descriptor(
		libusb_context* ctx,
		libusb_bos_dev_capability_descriptor* dev_cap,
		libusb_platform_descriptor** platform_descriptor
	);

	[LibraryImport(LibraryName)]
	public static partial void libusb_free_platform_descriptor(libusb_platform_descriptor* platform_descriptor);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_string_descriptor_ascii(
		libusb_device_handle* dev_handle,
		byte desc_index,
		byte* data,
		int length
	);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_interface_association_descriptors(
		libusb_device* dev,
		byte config_index,
		libusb_interface_association_descriptor_array** iad_array
	);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_active_interface_association_descriptors(
		libusb_device* dev,
		libusb_interface_association_descriptor_array** iad_array
	);

	[LibraryImport(LibraryName)]
	public static partial void libusb_free_interface_association_descriptors(
		libusb_interface_association_descriptor_array* iad_array
	);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_device_string(
		libusb_device* dev,
		libusb_device_string_type string_type,
		byte* data,
		int length
	);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_descriptor(
		libusb_device_handle* dev_handle,
		libusb_descriptor_type desc_type,
		byte desc_index,
		byte* data,
		int length
	);

	[LibraryImport(LibraryName)]
	public static partial int libusb_get_string_descriptor(
		libusb_device_handle* dev_handle,
		byte desc_index,
		ushort langid,
		byte* data,
		int length
	);
}
