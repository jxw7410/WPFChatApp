namespace WPFChatApp.Core
{
    /// <summary>
    /// View Model for each chatlistuser
    /// </summary>
    public class ChatListUserViewModel : ViewModelBase
    {
        /// <summary>
        /// Value converter will be used with ProfilePicColor to covert to color type.
        /// </summary>
        public string ProfilePictureColor { get; set; }
        /// <summary>
        /// Initials of User
        /// </summary>
        public string Initials { get; set; }
        /// <summary>
        /// Message in chat box
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// User Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Is new Content available
        /// True if there are unread message
        /// </summary>
        public bool IsNewContentAvailable { get; set; }
        /// <summary>
        /// True if item is selected 
        ///
        /// </summary>
        public bool IsSelected { get; set; }
    }
}
