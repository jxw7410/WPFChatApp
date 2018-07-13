namespace WPFChatApp.Core
{
    /// <summary>
    /// An pre-initialized ChatListUser for modeling at design time (fall back)
    /// </summary>
    public class ChatListUserDesignModel : ChatListUserViewModel
    {
        #region Singleton
        //getter per new C# syntax (older method still works too!)
        public static ChatListUserDesignModel Instance => new ChatListUserDesignModel(); 
  
        #endregion
        public ChatListUserDesignModel()
        {
            this.Initials = "P";
            this.Name = "Person";
            this.ProfilePictureColor = "RoyalBlue";
            this.Message = "404: No message.";
        }
    }
}
