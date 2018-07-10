using System.Collections.Generic;

namespace WPFChatApp
{
    /// <summary>
    /// An pre-initialized ChatListUser for modeling at design time (fall back)
    /// </summary>
    public class ChatListDesignModel : ChatListViewModel
    {
        #region Singleton
        //getter per new C# syntax (older method still works too!)
        public static ChatListDesignModel Instance => new ChatListDesignModel(); 
  
        #endregion
        /// <summary>
        /// The color declarator should be using the HEX code for colors. As it is, it violates MVVM
        /// since the strings are interpreted by WPF view to know what it is.
        /// Real MVVM will use Colorvalueconverter to extract the actual color
        /// </summary>
        public ChatListDesignModel()
        {
            Users = new List<ChatListUserViewModel>()
            {
                new ChatListUserViewModel
                {
                    Initials = "P1",
                    Name = "Person1",
                    ProfilePictureColor = "Red",
                    Message = "404: No message.",
                    IsNewContentAvailable = true
                },
                 new ChatListUserViewModel
                {
                    Initials = "P2",
                    Name = "Person2",
                    ProfilePictureColor = "Green",
                    Message = "404: No message.",
                },
                  new ChatListUserViewModel
                {
                    Initials = "P3",
                    Name = "Person3",
                    ProfilePictureColor = "RoyalBlue",
                    Message = "404: No message."
                },
                   new ChatListUserViewModel
                {
                    Initials = "P4",
                    Name = "Person4",
                    ProfilePictureColor = "Yellow",
                    Message = "404: No message."
                },
                 new ChatListUserViewModel
                {
                    Initials = "P5",
                    Name = "Person5",
                    ProfilePictureColor = "Purple",
                    Message = "404: No message."
                },
                  new ChatListUserViewModel
                {
                    Initials = "P6",
                    Name = "Person6",
                    ProfilePictureColor = "Orange",
                    Message = "404: No message."
                },
                   new ChatListUserViewModel
                {
                    Initials = "P7",
                    Name = "Person7",
                    ProfilePictureColor = "Gray",
                    Message = "404: No message."
                },
                 new ChatListUserViewModel
                {
                    Initials = "P8",
                    Name = "Person8",
                    ProfilePictureColor = "Cyan",
                    Message = "404: No message."
                },
                  new ChatListUserViewModel
                {
                    Initials = "P9",
                    Name = "Person9",
                    ProfilePictureColor = "Beige",
                    Message = "404: No message."
                },
            };
        }
    }
}
