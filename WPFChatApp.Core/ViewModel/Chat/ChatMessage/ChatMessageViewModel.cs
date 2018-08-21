using System.Collections.Generic;

namespace WPFChatApp.Core
{
    /// <summary>
    /// View Model for each chatlistuser
    /// </summary>
    public class ChatMessageViewModel : ViewModelBase
    {
        public List<ChatMessageUserViewModel> Users { get; set; }
    }
}
