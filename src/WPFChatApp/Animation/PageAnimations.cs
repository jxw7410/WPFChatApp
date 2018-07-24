using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WPFChatApp
{
/// <summary>
/// Helpers to animation pages in specific ways
/// </summary>
    public static class PageAnimations
    {
        public static async Task SlideAndFadeInFromRightAsync(this Page page, float seconds, bool keepMargin = true)
        {
            var storyBoard = new Storyboard();
            storyBoard.AddSlideFromRight(seconds, page.WindowWidth, keepMargin: keepMargin);
            storyBoard.AddFadeInAugment(seconds);
            storyBoard.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }

        public static async Task SlideAndFadeOutToRightAsync(this Page page, float seconds, bool keepMargin = true)
        {
            var storyBoard = new Storyboard();
            storyBoard.RemoveSlideToRight(seconds, page.WindowWidth, keepMargin: keepMargin);
            storyBoard.AddFadeOutAugment(seconds);
            storyBoard.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
    }
}
