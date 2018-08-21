using System;

namespace WPFChatApp.Core
{
    /// <summary>
    /// View Model for each chatlistuser
    /// </summary>
    public class ChatMessageUserViewModel : ViewModelBase
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
        public string SenderName { get; set; }
       
        /// <summary>
        /// True if item is selected 
        ///
        /// </summary>
        public bool IsSelected { get; set; }
        /// <summary>
        /// Flag to see if the message sent by user
        /// </summary>
        public bool IsSentByMe { get; set; }
        /// <summary>
        /// is message read? True if message read time > message sent time
        /// </summary>
        public bool IsMessageRead { get; }
        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset MessageReadTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset MessageSentTime { get; set; }
    }
}
