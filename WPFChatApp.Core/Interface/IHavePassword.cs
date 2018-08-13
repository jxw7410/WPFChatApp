using System.Security;

namespace WPFChatApp.Core
{
    /// <summary>
    /// An interface for a class that provides a securepassword
    /// </summary>
    public interface IHavePassword
    {
        SecureString SecurePassword { get; }
    }
}
