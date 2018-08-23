using System.Windows;
using System.Windows.Input;
using WPFChatApp.Core;


namespace WPFChatApp
{
    /// <summary>
    /// View Model class to describe the customized Window 
    /// </summary>
    public class WindowViewModel : ViewModelBase
    {

        #region Commands

        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }

        #endregion
        #region Constructors
        public WindowViewModel(Window window)
        {
            myWindow = window;
            window.StateChanged += (sender, e) =>
             {
                 WindowResized();
             };

            MinimizeCommand = new RelayCommand(() => myWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => myWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => myWindow.Close());
            MenuCommand = 
                new RelayCommand(() => SystemCommands.ShowSystemMenu(myWindow, myWindow.PointToScreen(Mouse.GetPosition(myWindow))));


            mWindowResizer = new WindowResizer(myWindow);

            // Listen out for dock changes
            mWindowResizer.WindowDockChanged += (dock) =>
            {
                // Store last position
                mDockPosition = dock;

                // Fire off resize events
                WindowResized();
            };
        }
        #endregion
        #region public Properties
        /// <summary>
        /// Resizing Borders, outermagin included as a factor
        /// </summary>
        public int ResizeBorder { get { return myWindow.WindowState == WindowState.Maximized ? 0 : 10; } }
        public Thickness ResizeBorderTHICCness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }
        /// <summary>
        /// Resizing OuterMargins
        /// </summary>
        public int OuterMarginSize
        {
            get { return myWindow.WindowState == WindowState.Maximized ? 0 : outerMarginSize; }
            set
            {
                outerMarginSize = value;
            }
        }
        public Thickness OuterMarginThickness { get { return new Thickness(OuterMarginSize); } }
        /// <summary>
        /// Adjusting Curve of window box edges
        /// </summary>
        public int WindowCurveEdge
        {
            get { return myWindow.WindowState == WindowState.Maximized ? 0 : windowCurveEdge; }
            set
            {
                windowCurveEdge = value;
            }
        }
        public CornerRadius WindowCurveEdgeRadius { get { return new CornerRadius(WindowCurveEdge); } }
        /// <summary>
        /// Caption Height of Title Bar
        /// </summary>
        public int CaptionHeight { get; set; } = 42;
        public GridLength TitleHeightGridLength { get { return new GridLength(CaptionHeight + ResizeBorder); } }
        public int MinWidth { get; set; } = 750;
        public int MinHeight { get; set; } = 400;
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        public bool Borderless => (myWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked);
        public void WindowResized()
        {
            PropertyChangedEvent("ResizeBorderTHICCness");
            PropertyChangedEvent("OuterMarginSize");
            PropertyChangedEvent("OuterMarginThicness");
            PropertyChangedEvent("WindowCurveEdge");
            PropertyChangedEvent("WindowCurveEdgeRadius");
        }
        #endregion
        #region Private Members
        private Window myWindow;
        private int outerMarginSize = 2;
        private int windowCurveEdge = 10;
        private WindowResizer mWindowResizer;
        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;
        #endregion

    }
}
