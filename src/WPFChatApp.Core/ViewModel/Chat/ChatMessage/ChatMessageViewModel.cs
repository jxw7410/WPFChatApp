using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFChatApp.Core
{
    /// <summary>
    /// View Model for each chatlistuser
    /// </summary>
    public class ChatMessageViewModel : ViewModelBase
    {
        public List<ChatMessageUserViewModel> Users { get; set; }

        #region  Commands
        public ICommand AttachedButtonCommand { get; set; }
        #endregion

        #region Private members
        private bool isTriggered = false;
        #endregion

        #region Public Properties
        public bool IsTriggered
        {
            get
            {
                return isTriggered;
            }
            set
            {
                isTriggered = value;
                PropertyChangedEvent("IsTriggered");
            }
        }

        public string DefaultMessage { get; set; } = "Please type a message...";

        public string TextBoxText { get; set; } 
        #endregion

        #region Constructor
        public ChatMessageViewModel()
        {
            AttachedButtonCommand = new RelayCommand(AttachItemButton);
        }
        #endregion


        #region Functions/Methods
        public void AttachItemButton()
        {
            IsTriggered ^= true;
        }
        #endregion

    }
}
