using System.Collections.Generic;

namespace WPFChatApp
{
    /// <summary>
    /// View Model for each chatlistuser
    /// </summary>
    public class ChatListViewModel : ViewModelBase
    {
        public List<ChatListUserViewModel> Users { get; set; }
    }
}
