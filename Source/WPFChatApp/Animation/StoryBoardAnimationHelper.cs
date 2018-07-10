using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace WPFChatApp
{
    public static class StoryBoardAnimationHelper
    {
        
        public static void AddSlideFromRight(this Storyboard storyBoard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            var Animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));
            storyBoard.Children.Add(Animation);
        }

        public static void AddFadeInAugment(this Storyboard storyBoard, float seconds)
        {
            var Animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1,
            };
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Opacity"));
            storyBoard.Children.Add(Animation);
        }

        public static void RemoveSlideToRight(this Storyboard storyBoard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            var Animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(offset, 0, -offset, 0),
                DecelerationRatio = decelerationRatio
            };
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));
            storyBoard.Children.Add(Animation);
        }

        public static void AddFadeOutAugment(this Storyboard storyBoard, float seconds)
        {
            var Animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0,
            };
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Opacity"));
            storyBoard.Children.Add(Animation);
        }

    }
}
