using System;
using System.Runtime.InteropServices;
using System.Security;

namespace WPFChatApp
{
    public static class SecureStringHelpers
    {
        /// <summary>
        /// this param allows for extensions like how in C++ you return use a reference type& func(type& var);
        /// Function unsecures a secure string to a text
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static string Unsecure(this SecureString securePassword)
        {
            if (securePassword == null)
                return string.Empty;

            var unmanagedString = IntPtr.Zero; // this is a pointer

            try
            {
                //decrypts password
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                //clean memory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
