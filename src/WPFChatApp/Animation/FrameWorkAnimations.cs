using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WPFChatApp
{
/// <summary>
/// Helpers to animation framework elements (User control probably) in specific ways
/// </summary>
    public static class FrameworkAnimations
    {
        public static async Task SlideAndFadeInFromRightAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            var storyBoard = new Storyboard();
            storyBoard.AddSlideFromRight(seconds, width == 0 ? element.ActualWidth : width, keepMargin : keepMargin);
            storyBoard.AddFadeInAugment(seconds);
            storyBoard.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }

        public static async Task SlideAndFadeOutToRightAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            var storyBoard = new Storyboard();
            storyBoard.RemoveSlideToRight(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);
            storyBoard.AddFadeOutAugment(seconds);
            storyBoard.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }

        public static async Task SlideAndFadeInFromLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            var storyBoard = new Storyboard();
            storyBoard.AddSlideFromLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);
            storyBoard.AddFadeInAugment(seconds);
            storyBoard.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }

        public static async Task SlideAndFadeOutToLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            var storyBoard = new Storyboard();
            storyBoard.RemoveSlideToLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);
            storyBoard.AddFadeOutAugment(seconds);
            storyBoard.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
    }
}
