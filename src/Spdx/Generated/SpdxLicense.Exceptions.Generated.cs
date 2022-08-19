//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
// </auto-generated>
//------------------------------------------------------------------------------

namespace Spdx;

public sealed partial class SpdxLicense
{
    public sealed partial class Exceptions
    {
        private static readonly IReadOnlySet<string> _exceptions;

        static Exceptions()
        {
            _exceptions = GenerateExceptions();
        }

        private static IReadOnlySet<string> GenerateExceptions()
        {
            return new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                { "389-exception" },
                { "Autoconf-exception-2.0" },
                { "Autoconf-exception-3.0" },
                { "Bison-exception-2.2" },
                { "Bootloader-exception" },
                { "Classpath-exception-2.0" },
                { "CLISP-exception-2.0" },
                { "DigiRule-FOSS-exception" },
                { "eCos-exception-2.0" },
                { "Fawkes-Runtime-exception" },
                { "FLTK-exception" },
                { "Font-exception-2.0" },
                { "freertos-exception-2.0" },
                { "GCC-exception-2.0" },
                { "GCC-exception-3.1" },
                { "gnu-javamail-exception" },
                { "GPL-3.0-linking-exception" },
                { "GPL-3.0-linking-source-exception" },
                { "GPL-CC-1.0" },
                { "GStreamer-exception-2005" },
                { "GStreamer-exception-2008" },
                { "i2p-gpl-java-exception" },
                { "KiCad-libraries-exception" },
                { "LGPL-3.0-linking-exception" },
                { "Libtool-exception" },
                { "Linux-syscall-note" },
                { "LLVM-exception" },
                { "LZMA-exception" },
                { "mif-exception" },
                { "Nokia-Qt-exception-1.1" },
                { "OCaml-LGPL-linking-exception" },
                { "OCCT-exception-1.0" },
                { "OpenJDK-assembly-exception-1.0" },
                { "openvpn-openssl-exception" },
                { "PS-or-PDF-font-exception-20170817" },
                { "Qt-GPL-exception-1.0" },
                { "Qt-LGPL-exception-1.1" },
                { "Qwt-exception-1.0" },
                { "SHL-2.0" },
                { "SHL-2.1" },
                { "Swift-exception" },
                { "u-boot-exception-2.0" },
                { "Universal-FOSS-exception-1.0" },
                { "WxWindows-exception-3.1" },
            };
        }
    }
}