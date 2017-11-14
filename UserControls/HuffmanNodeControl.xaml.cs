using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace EduDemo.HuffmanCoding
{
    /// <summary>
    /// Interaction logic for HuffmanNodeControl.xaml
    /// </summary>
    public partial class HuffmanNodeControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        Storyboard MouseEnterStoryboard;
        Storyboard MouseLeaveStoryboard;
        Storyboard HighlightStoryboard;

        QuadraticEase QEaseOut = new QuadraticEase() { EasingMode = System.Windows.Media.Animation.EasingMode.EaseOut };
           
        public Line LeftChildEdge;
        public Line RightChildEdge;

        HuffmanNode _Node;
        public HuffmanNode Node
        {
            get
            {
                return _Node;
            }
            set
            {
                _Node = value;
                if(_Node.IsCompositeNode)
                {
                    txtName.Text = "[ ]";                    
                }
                else
                {
                    txtName.Text = _Node.Title;
                }
                txtName.ToolTip = _Node.Title;
                txtFrequency.Text = _Node.Frequency.ToString();
            }
        }
        
        public HuffmanNodeControl( HuffmanNode node)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Node = node;
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            if (MouseEnterStoryboard == null)
            {
                MouseEnterStoryboard = new Storyboard();
                
                MouseEnterStoryboard.Duration = new TimeSpan(0, 0, 0, 0, 150);
                {
                    DoubleAnimation wa = new DoubleAnimation(80, TimeSpan.FromMilliseconds(150));
                    wa.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
                    wa.EasingFunction = QEaseOut;
                    Storyboard.SetTargetProperty(wa, new PropertyPath(Ellipse.WidthProperty));
                    Storyboard.SetTarget(wa, OuterEllipse);
                    MouseEnterStoryboard.Children.Add(wa);
                }
                {
                    DoubleAnimation ha = new DoubleAnimation(80, TimeSpan.FromMilliseconds(150));
                    ha.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
                    ha.EasingFunction = QEaseOut;
                    Storyboard.SetTargetProperty(ha, new PropertyPath(Ellipse.HeightProperty));
                    Storyboard.SetTarget(ha, OuterEllipse);
                    MouseEnterStoryboard.Children.Add(ha);
                }
                {
                    DoubleAnimation sta = new DoubleAnimation(10, TimeSpan.FromMilliseconds(150));
                    sta.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
                    sta.EasingFunction = QEaseOut;
                    Storyboard.SetTargetProperty(sta, new PropertyPath(Ellipse.StrokeThicknessProperty));
                    Storyboard.SetTarget(sta, OuterEllipse);
                    MouseEnterStoryboard.Children.Add(sta);
                }
            }

            MouseEnterStoryboard.Stop();
            MouseEnterStoryboard.Begin();
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if (MouseLeaveStoryboard == null)
            {
                MouseLeaveStoryboard = new Storyboard();

                MouseLeaveStoryboard.Duration = new TimeSpan(0, 0, 0, 0, 150);
                {
                    DoubleAnimation wa = new DoubleAnimation(60, TimeSpan.FromMilliseconds(150));
                    wa.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
                    wa.EasingFunction = QEaseOut;
                    Storyboard.SetTargetProperty(wa, new PropertyPath(Ellipse.WidthProperty));
                    Storyboard.SetTarget(wa, OuterEllipse);
                    MouseLeaveStoryboard.Children.Add(wa);
                }
                {
                    DoubleAnimation ha = new DoubleAnimation(60, TimeSpan.FromMilliseconds(150));
                    ha.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
                    ha.EasingFunction = QEaseOut;
                    Storyboard.SetTargetProperty(ha, new PropertyPath(Ellipse.HeightProperty));
                    Storyboard.SetTarget(ha, OuterEllipse);
                    MouseLeaveStoryboard.Children.Add(ha);
                }
                {
                    DoubleAnimation sta = new DoubleAnimation(1, TimeSpan.FromMilliseconds(150));
                    sta.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
                    sta.EasingFunction = QEaseOut;
                    Storyboard.SetTargetProperty(sta, new PropertyPath(Ellipse.StrokeThicknessProperty));
                    Storyboard.SetTarget(sta, OuterEllipse);
                    MouseLeaveStoryboard.Children.Add(sta);
                }
            }

            MouseLeaveStoryboard.Stop();
            MouseLeaveStoryboard.Begin();
        }

        public void Highlight()
        {
            if (HighlightStoryboard == null)
            {
                HighlightStoryboard = new Storyboard();

                HighlightStoryboard.Duration = new TimeSpan(0, 0, 0, 0, 500);

                {
                    DoubleAnimation wa = new DoubleAnimation(80, TimeSpan.FromMilliseconds(250));
                    wa.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
                    wa.EasingFunction = QEaseOut;
                    Storyboard.SetTargetProperty(wa, new PropertyPath(Ellipse.WidthProperty));
                    Storyboard.SetTarget(wa, OuterEllipse);
                    HighlightStoryboard.Children.Add(wa);
                }
                {
                    DoubleAnimation ha = new DoubleAnimation(80, TimeSpan.FromMilliseconds(250));
                    ha.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
                    ha.EasingFunction = QEaseOut;
                    Storyboard.SetTargetProperty(ha, new PropertyPath(Ellipse.HeightProperty));
                    Storyboard.SetTarget(ha, OuterEllipse);
                    HighlightStoryboard.Children.Add(ha);
                }
                {
                    DoubleAnimation sta = new DoubleAnimation(10, TimeSpan.FromMilliseconds(250));
                    sta.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
                    sta.EasingFunction = QEaseOut;
                    Storyboard.SetTargetProperty(sta, new PropertyPath(Ellipse.StrokeThicknessProperty));
                    Storyboard.SetTarget(sta, OuterEllipse);
                    HighlightStoryboard.Children.Add(sta);
                }

                {
                    DoubleAnimation wa = new DoubleAnimation(60, TimeSpan.FromMilliseconds(250));
                    wa.BeginTime = new TimeSpan(0, 0, 0, 0, 250);
                    wa.EasingFunction = QEaseOut;
                    Storyboard.SetTargetProperty(wa, new PropertyPath(Ellipse.WidthProperty));
                    Storyboard.SetTarget(wa, OuterEllipse);
                    HighlightStoryboard.Children.Add(wa);
                }
                {
                    DoubleAnimation ha = new DoubleAnimation(60, TimeSpan.FromMilliseconds(250));
                    ha.BeginTime = new TimeSpan(0, 0, 0, 0, 250);
                    ha.EasingFunction = QEaseOut;
                    Storyboard.SetTargetProperty(ha, new PropertyPath(Ellipse.HeightProperty));
                    Storyboard.SetTarget(ha, OuterEllipse);
                    HighlightStoryboard.Children.Add(ha);
                }
                {
                    DoubleAnimation sta = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
                    sta.BeginTime = new TimeSpan(0, 0, 0, 0, 250);
                    sta.EasingFunction = QEaseOut;
                    Storyboard.SetTargetProperty(sta, new PropertyPath(Ellipse.StrokeThicknessProperty));
                    Storyboard.SetTarget(sta, OuterEllipse);
                    HighlightStoryboard.Children.Add(sta);
                }
            }

            HighlightStoryboard.Stop();
            HighlightStoryboard.Begin();
        }
    }
}
