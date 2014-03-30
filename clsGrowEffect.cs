using System;
using System.Windows.Media.Animation;
using System.Windows;

namespace GrowEffect
{
    public class clsGrowEffect
    {
         public FrameworkElement Target { get; set; }
        public double GoTo { get; set; }
        public double Delay { get; set; }
        private double OldLeft;
        private Thickness novo;
        private Thickness old;

        public clsGrowEffect()
        {
            OldLeft = 0;
            GoTo = 0;
            Delay = 0;
        }

        void Grow()
        {
            Target.BeginAnimation(UIElement.OpacityProperty, null);
   
            Storyboard sb = new Storyboard();
            ThicknessAnimationUsingKeyFrames taNew = new ThicknessAnimationUsingKeyFrames();

            TimeSpan endTime = TimeSpan.FromSeconds(0.5);
            KeyTime kEnd = KeyTime.FromTimeSpan(endTime);

            taNew.BeginTime = TimeSpan.FromSeconds(0);
            Storyboard.SetTargetName(taNew, Target.Name);
            Storyboard.SetTargetProperty(taNew, new PropertyPath("(FrameworkElement.Margin)"));
            taNew.KeyFrames.Add(new SplineThicknessKeyFrame(old, TimeSpan.FromSeconds(0)));
            taNew.KeyFrames.Add(new SplineThicknessKeyFrame(novo, kEnd));
            sb.Children.Add(taNew);
            sb.BeginTime = TimeSpan.FromMilliseconds(Delay);

            sb.Begin(Target);
        }

        public void GrowLeft()
        {
            
            OldLeft = Target.Margin.Left;

            novo = new Thickness(GoTo, Target.Margin.Top, Target.Margin.Right, Target.Margin.Bottom);
            old = new Thickness(OldLeft, Target.Margin.Top, Target.Margin.Right, Target.Margin.Bottom);
            Grow();
        }

        public void GrowUp()
        {
            OldLeft = Target.Margin.Top;

            novo = new Thickness(Target.Margin.Left , GoTo, Target.Margin.Right, Target.Margin.Bottom);
            old = new Thickness(Target.Margin.Left, OldLeft, Target.Margin.Right, Target.Margin.Bottom);
            Grow();
        }

        public void GrowDown()
        {
            OldLeft = Target.Margin.Bottom;

            novo = new Thickness(Target.Margin.Left,Target.Margin.Top , Target.Margin.Right, GoTo);
            old = new Thickness(Target.Margin.Left, Target.Margin.Top, Target.Margin.Right, OldLeft);
            Grow();
        }

        public void GrowRight()
        {
            OldLeft = Target.Margin.Right;

            novo = new Thickness(Target.Margin.Left,Target.Margin.Top , GoTo, Target.Margin.Bottom);
            old = new Thickness(Target.Margin.Left, Target.Margin.Top , OldLeft, Target.Margin.Bottom);
            Grow();
        }
    }
}
