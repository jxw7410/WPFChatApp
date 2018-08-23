using System;
using System.Collections.Generic;

namespace WPFChatApp.Core
{
    /// <summary>
    /// An pre-initialized ChatListUser for modeling at design time (fall back)
    /// </summary>
    public class ChatMessageDesignModel : ChatMessageViewModel
    {
        #region Singleton
        //getter per new C# syntax (older method still works too!)
        public static ChatMessageDesignModel Instance => new ChatMessageDesignModel(); 
  
        #endregion
        /// <summary>
        /// The color declarator should be using the HEX code for colors. As it is, it violates MVVM
        /// since the strings are interpreted by WPF view to know what it is.
        /// Real MVVM will use Colorvalueconverter to extract the actual color
        /// </summary>
        public ChatMessageDesignModel()
        {
            Users = new List<ChatMessageUserViewModel>()
            {
                new ChatMessageUserViewModel
                {
                    Initials = "P1",
                    SenderName = "Person1",
                    ProfilePictureColor = "Red",
                    Message = "Ligma",
                    MessageSentTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.4)),
                    IsSentByMe = false,
                },
                 new ChatMessageUserViewModel
                {
                    Initials = "P2",
                    SenderName = "Person2",
                    ProfilePictureColor = "Green",
                    Message = "What's Ligma?",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                    IsSentByMe = true,
                },
                  new ChatMessageUserViewModel
                {
                    Initials = "P1",
                    SenderName = "Person1",
                    ProfilePictureColor = "Red",
                    Message = "Ligma Balls. LOLOLOL ROFL! GOTEEEEM!",
                    MessageSentTime =DateTimeOffset.UtcNow,
                    IsSentByMe = false,
                },                               
            };
        }
    }
}
