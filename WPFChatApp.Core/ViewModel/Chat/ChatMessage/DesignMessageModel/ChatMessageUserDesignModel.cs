using System;

namespace WPFChatApp.Core
{
    /// <summary>
    /// An pre-initialized ChatListUser for modeling at design time (fall back)
    /// </summary>
    public class ChatMessageUserDesignModel : ChatMessageUserViewModel
    {
        #region Singleton
        //getter per new C# syntax (older method still works too!)
        public static ChatMessageUserDesignModel Instance => new ChatMessageUserDesignModel(); 
  
        #endregion
        /// <summary>
        /// default constructor
        /// </summary>
        public ChatMessageUserDesignModel() 
        {
            this.Initials = "P1";
            this.SenderName = "Person";
            this.ProfilePictureColor = "RoyalBlue";
            this.Message = "Ligma";
            this.IsSentByMe = false;
            MessageSentTime = DateTimeOffset.UtcNow;
            MessageReadTime = DateTimeOffset.UtcNow;
        }
    }
}
