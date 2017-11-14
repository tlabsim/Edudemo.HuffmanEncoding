using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using TLABS.Collections;

namespace EduDemo.HuffmanCoding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetControls();
            SetUI();
            AddEvents();
        }

        #region Properties
        string CurrentTool = "Zoom";
        string AnimationMode = "Stopped";              

        //Canvas pan
        bool CanvasTreeMouseDown = false;
        Point CanvasTreeMouseDownPosition;
        double CanvasTreeMouseDownTransformX;
        double CanvasTreeMouseDownTransformY;

        Storyboard CanvasGridMouseEnterStoryboard;
        Storyboard CanvasGridMouseLeaveStoryboard;
        QuinticEase QEaseOut = new QuinticEase() { EasingMode = EasingMode.EaseOut };

        Storyboard StartupAnimationStoryboard;       
        Storyboard DemoAnimationStoryboard;
        Storyboard FitGraphStoryboard;

        int _ResultMode = 1;
        public int ResultMode
        {
            get
            {
                return _ResultMode;
            }
            set
            {
                _ResultMode = value;
                if (value == 1)
                {
                    ThicknessAnimation ta = new ThicknessAnimation(new Thickness(0, 0, 0, 0), TimeSpan.FromMilliseconds(200));
                    ta.EasingFunction = QEaseOut;
                    ResultGrid.BeginAnimation(Grid.MarginProperty, ta);
                }
                else if (value == 2)
                {
                    ThicknessAnimation ta = new ThicknessAnimation(new Thickness(-310, 0, 0, 0), TimeSpan.FromMilliseconds(200));
                    ta.EasingFunction = QEaseOut;
                    ResultGrid.BeginAnimation(Grid.MarginProperty, ta);
                }
            }
        }

        public List<HuffmanNode> NodesInOrder = new List<HuffmanNode>();
        public List<Composition> Compositions = new List<Composition>();

        double node_control_width = 80;
        double node_control_height = 100;

        ImageSource PlayImageSource = new BitmapImage(new Uri("pack://application:,,,/EduDemo.HuffmanCoding;component/Images/icon_play.png"));
        ImageSource PauseImageSource = new BitmapImage(new Uri("pack://application:,,,/EduDemo.HuffmanCoding;component/Images/icon_pause.png"));
        #endregion

        #region Methods
        void SetControls()
        {
        }

        void SetUI()
        {
            txtTextToEncode.Focus();
        }

        void AddEvents()
        {
            this.sliderCanvasScale.ValueChanged+=new RoutedPropertyChangedEventHandler<double>(sliderCanvasScale_ValueChanged);
        }

        void RunStartupAnimation()
        {
            //Left panel appears from left
            //Header texts appears
            //Textbox appears
            //Logo appears
            //Instruction appears

            if (StartupAnimationStoryboard == null)
            {
                StartupAnimationStoryboard = new Storyboard();
                StartupAnimationStoryboard.Duration = TimeSpan.FromMilliseconds(600);

                //Left panel appears from left
                {
                    ThicknessAnimation ta = new ThicknessAnimation(new Thickness(0, 0, 0, 0), TimeSpan.FromMilliseconds(250));
                    ta.BeginTime = new TimeSpan(0, 0, 0, 0, 100);
                    ta.EasingFunction = QEaseOut;
                    Storyboard.SetTarget(ta, LeftPanel);
                    Storyboard.SetTargetProperty(ta, new PropertyPath(Border.MarginProperty));
                    StartupAnimationStoryboard.Children.Add(ta);
                }

                //Header texts appears
                {
                    ThicknessAnimation ta = new ThicknessAnimation(new Thickness(20,0,0,0), TimeSpan.FromMilliseconds(250));
                    ta.BeginTime = new TimeSpan(0, 0, 0, 0, 350);
                    ta.EasingFunction = QEaseOut;
                    Storyboard.SetTarget(ta, txtHeader);
                    Storyboard.SetTargetProperty(ta, new PropertyPath(TextBlock.MarginProperty));
                    StartupAnimationStoryboard.Children.Add(ta);
                }
              
                {
                    DoubleAnimation da = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
                    da.BeginTime = new TimeSpan(0, 0, 0, 0, 350);
                    da.EasingFunction = QEaseOut;
                    Storyboard.SetTarget(da, txtHeader);
                    Storyboard.SetTargetProperty(da, new PropertyPath(TextBlock.OpacityProperty));
                    StartupAnimationStoryboard.Children.Add(da);
                }

                //Help icon appears
                {
                    ThicknessAnimation ta = new ThicknessAnimation(new Thickness(0, 0, 20, 0), TimeSpan.FromMilliseconds(250));
                    ta.BeginTime = new TimeSpan(0, 0, 0, 0, 350);
                    ta.EasingFunction = QEaseOut;
                    Storyboard.SetTarget(ta, iconHelp);
                    Storyboard.SetTargetProperty(ta, new PropertyPath(Image.MarginProperty));
                    StartupAnimationStoryboard.Children.Add(ta);
                }

                {
                    DoubleAnimation da = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
                    da.BeginTime = new TimeSpan(0, 0, 0, 0, 350);
                    da.EasingFunction = QEaseOut;
                    Storyboard.SetTarget(da, iconHelp);
                    Storyboard.SetTargetProperty(da, new PropertyPath(Image.OpacityProperty));
                    StartupAnimationStoryboard.Children.Add(da);
                }

                {
                    DoubleAnimation da = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
                    da.BeginTime = new TimeSpan(0, 0, 0, 0, 350);
                    da.EasingFunction = QEaseOut;
                    Storyboard.SetTarget(da, InputPanel);
                    Storyboard.SetTargetProperty(da, new PropertyPath(StackPanel.OpacityProperty));
                    StartupAnimationStoryboard.Children.Add(da);
                }

                {
                    DoubleAnimation da = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
                    da.BeginTime = new TimeSpan(0, 0, 0, 0, 350);
                    da.EasingFunction = QEaseOut;
                    Storyboard.SetTarget(da, imgLogo);
                    Storyboard.SetTargetProperty(da, new PropertyPath(Image.OpacityProperty));
                    StartupAnimationStoryboard.Children.Add(da);
                }
            }
            StartupAnimationStoryboard.Begin();
        }

        void RunCloseAnimation()
        {
        }

        void Run()
        {
            string text= txtTextToEncode.Text.Trim();
            if (text != string.Empty)
            {
                text = text.ToUpper();
                text = text.Replace(' ', '␣'); //Replace space with a visible symbol

                HuffmanTree tree = ConstructTree(text);
                canvasTree.Children.Clear();
                int depth = tree.Depth;
                canvasTree.Width = (Math.Pow(2, depth)) * node_control_width;
                canvasTree.Height = depth * node_control_height;

                double root_x = canvasTree.Width / 2 - node_control_width / 2;
                double root_y = 0;

                DrawNode(tree.Root, 1, root_x, root_y);

                double scale_x = CanvasGrid.ActualWidth / canvasTree.Width;
                double scale_y = CanvasGrid.ActualHeight / canvasTree.Height;
                double scale = Math.Min(scale_x, scale_y);
                canvasTreeTT.X = 0;
                canvasTreeTT.Y = 0;
                {
                    DoubleAnimation da = new DoubleAnimation(1, scale, TimeSpan.FromMilliseconds(500));
                    da.EasingFunction = QEaseOut;
                    sliderCanvasScale.BeginAnimation(Slider.ValueProperty, da);
                }

                tree.GetNodeEncodings();

                txtEncodedData.Inlines.Clear();
                int l = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    string e = tree.EncodingDictionary[text[i]].Encoding;
                    Run r = new Run();
                    r.Text = e;
                    r.ToolTip = text[i].ToString();
                    r.MouseEnter += (o1, e1) => { Run s = o1 as Run; s.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255)); };
                    r.MouseLeave += (o1, e1) => { Run s = o1 as Run; s.Background = new SolidColorBrush(Colors.Transparent); };
                    txtEncodedData.Inlines.Add(r);
                    l += e.Length;
                }

                txtCompressionRatio.Text = (((double)text.Length * 800) / (double)l).ToString("F2") + "%";

                EncodingGrid.Children.Clear();
                EncodingGrid.RowDefinitions.Clear();
                int rds = 0;

                List<HuffmanNode> leafs = tree.Leafs;
                leafs = leafs.OrderByDescending(n => n.Frequency).ThenBy(n => n.Encoding).ToList();
                for (int i = 0; i < leafs.Count; i++)
                {
                    EncodingGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30, GridUnitType.Pixel) });

                    {
                        Border b1 = new Border() { Background = new SolidColorBrush(Color.FromArgb(30, 255, 255, 255)), Margin = new Thickness(0.5) };
                        TextBlock t1 = new TextBlock() { Text = leafs[i].Character.ToString(), FontSize = 15, FontWeight = FontWeights.Bold, Foreground = new SolidColorBrush(Colors.Wheat), Margin = new Thickness(5, 0, 0, 0), VerticalAlignment = System.Windows.VerticalAlignment.Center };
                        b1.Child = t1;
                        EncodingGrid.Children.Add(b1);
                        b1.SetValue(Grid.ColumnProperty, 0);
                        b1.SetValue(Grid.RowProperty, rds);
                    }
                    {
                        Border b2 = new Border() { Background = new SolidColorBrush(Color.FromArgb(30, 255, 255, 255)), Margin = new Thickness(0.5) };
                        TextBlock t2 = new TextBlock() { Text = leafs[i].Frequency.ToString(), FontSize = 15, FontWeight = FontWeights.Bold, Foreground = new SolidColorBrush(Colors.White), Margin = new Thickness(5, 0, 0, 0), VerticalAlignment = System.Windows.VerticalAlignment.Center };
                        b2.Child = t2;
                        EncodingGrid.Children.Add(b2);
                        b2.SetValue(Grid.ColumnProperty, 1);
                        b2.SetValue(Grid.RowProperty, rds);
                    }
                    {
                        Border b3 = new Border() { Background = new SolidColorBrush(Color.FromArgb(30, 255, 255, 255)), Margin = new Thickness(0.5) };
                        TextBlock t3 = new TextBlock() { Text = leafs[i].Encoding, FontSize = 15, FontWeight = FontWeights.Bold, Foreground = new SolidColorBrush(Colors.White), Margin = new Thickness(5, 0, 0, 0), VerticalAlignment = System.Windows.VerticalAlignment.Center };
                        b3.Child = t3;
                        EncodingGrid.Children.Add(b3);
                        b3.SetValue(Grid.ColumnProperty, 2);
                        b3.SetValue(Grid.RowProperty, rds);
                    }
                    rds++;
                }

                {
                    DoubleAnimation da = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(500));
                    da.EasingFunction = QEaseOut;
                    ResultPanel.BeginAnimation(Grid.OpacityProperty, da);
                }
                ResultMode = 1;

                //Demo animation
                CreateDemoAnimation();
            }
        }

        HuffmanTree ConstructTree(string text)
        {
            HuffmanTree tree = new HuffmanTree();            

            //Get all characters and their frequencies            
            for (int i = 0; i < text.Length; i++)
            {
                HuffmanNode node = tree.Nodes.Find(n => n.Character == text[i]);
                if (node != null)
                {
                    node.Frequency++;
                }
                else
                {
                    HuffmanNode hn = new HuffmanNode();
                    hn.Character = text[i];
                    hn.Title = text[i].ToString();
                    hn.IsCompositeNode = false;
                    hn.Frequency = 1;                    
                    tree.Nodes.Add(hn);                    
                }
            }

            if(tree.Nodes.Count==1)
            {
                tree.Root = tree.Nodes[0];
            }
            else if (tree.Nodes.Count > 1)
            {
                HeapPriorityQueue<PriorityQueueNode> HPQ = new HeapPriorityQueue<PriorityQueueNode>(tree.NodeCount);
                for (int i = 0; i < tree.Nodes.Count; i++)
                {
                    PriorityQueueNode pqn = new PriorityQueueNode();
                    pqn.Tag = tree.Nodes[i];
                    HPQ.Enqueue(pqn, tree.Nodes[i].Frequency);
                }

                NodesInOrder.Clear();
                Compositions.Clear();
                HuffmanNode LastCompositeNode = null;
                while (HPQ.Count > 1)
                {
                    PriorityQueueNode p1 = HPQ.Dequeue();
                    PriorityQueueNode p2 = HPQ.Dequeue();

                    HuffmanNode left_child = p1.Tag as HuffmanNode;
                    HuffmanNode right_child = p2.Tag as HuffmanNode;

                    HuffmanNode composite_node = new HuffmanNode();
                    composite_node.IsCompositeNode = true;
                    composite_node.Title = left_child.Title + right_child.Title;
                    composite_node.Frequency = left_child.Frequency + right_child.Frequency;
                    composite_node.LeftChild = left_child;
                    composite_node.RightChild = right_child;
                    left_child.Parent = composite_node;
                    right_child.Parent = composite_node;
                    if (left_child.IsCompositeNode)
                    {
                        left_child.NodeType = NodeType.LeftChildWithBothChild;
                    }
                    else
                    {
                        left_child.NodeType = NodeType.LeftLeaf;
                    }
                    if (right_child.IsCompositeNode)
                    {
                        right_child.NodeType = NodeType.RightChildWithBothChild;
                    }
                    else
                    {
                        right_child.NodeType = NodeType.RightLeaf;
                    }

                    //Nodes in order of composition
                    NodesInOrder.Add(left_child);
                    NodesInOrder.Add(right_child);

                    //Add to composition list
                    Composition c = new Composition();
                    c.Parent = composite_node;
                    c.LeftChild = left_child;
                    c.RightChild = right_child;
                    Compositions.Add(c);

                    PriorityQueueNode cpqn = new PriorityQueueNode();
                    cpqn.Tag = composite_node;
                    HPQ.Enqueue(cpqn, composite_node.Frequency);

                    tree.Nodes.Add(composite_node);
                    LastCompositeNode = composite_node;
                }

                NodesInOrder.Add(LastCompositeNode);
                tree.Root = LastCompositeNode;
            }

            return tree;
        }       

        HuffmanNodeControl DrawNode(HuffmanNode node, int depth, double x, double y)
        {
            HuffmanNodeControl hnc = null;
            if (node != null)
            {
                hnc = new HuffmanNodeControl(node);
                node.NodeControl = hnc;
                canvasTree.Children.Add(hnc);
                hnc.SetValue(Canvas.LeftProperty, x);
                hnc.SetValue(Canvas.TopProperty, y);
                hnc.SetValue(Panel.ZIndexProperty, 100);

                int new_depth = depth + 1;
                double offset_x = canvasTree.Width / Math.Pow(2, new_depth);
                if (node.LeftChild != null)
                {
                    HuffmanNodeControl lhnc = DrawNode(node.LeftChild, new_depth, x - offset_x, y + node_control_height);
                    ConnectLeftChild(hnc, lhnc);
                }
                if (node.RightChild != null)
                {
                    HuffmanNodeControl rhnc = DrawNode(node.RightChild, new_depth, x + offset_x, y + node_control_height);
                    ConnectRightChild(hnc, rhnc);
                }
            }

            return hnc;
        }

        void ConnectLeftChild(HuffmanNodeControl parent, HuffmanNodeControl child)
        {
            Line l = new Line();
            l.Stroke = new SolidColorBrush(Colors.Crimson);
            l.StrokeThickness = 2;

            double px = (double)parent.GetValue(Canvas.LeftProperty) + 20;
            double py = (double)parent.GetValue(Canvas.TopProperty) + 60;
            double cx = (double)child.GetValue(Canvas.LeftProperty) + 60;
            double cy = (double)child.GetValue(Canvas.TopProperty) + 20;

            double w = Math.Abs(px - cx);
            double h = Math.Abs(py - cy);
            if (w == 0) w = 2;

            l.Width = w;
            l.Height = h;

            l.X1 = w;
            l.Y1 = 0;
            l.X2 = 0;
            l.Y2 = h;

            canvasTree.Children.Add(l);
            l.SetValue(Canvas.LeftProperty, Math.Min(px, cx));
            l.SetValue(Canvas.TopProperty, Math.Min(py, cy));

            parent.LeftChildEdge = l;
        }

        void ConnectRightChild(HuffmanNodeControl parent, HuffmanNodeControl child)
        {
            Line l = new Line();
            l.Stroke = new SolidColorBrush(Colors.Crimson);
            l.StrokeThickness = 2;

            double px = (double)parent.GetValue(Canvas.LeftProperty) + 60;
            double py = (double)parent.GetValue(Canvas.TopProperty) + 60;
            double cx = (double)child.GetValue(Canvas.LeftProperty) + 20;
            double cy = (double)child.GetValue(Canvas.TopProperty) + 20;

            double w = Math.Abs(px - cx);
            double h = Math.Abs(py - cy);

            l.Width = w;
            l.Height = h;

            l.X1 = 0;
            l.Y1 = 0;
            l.X2 = w;
            l.Y2 = h;

            canvasTree.Children.Add(l);
            l.SetValue(Canvas.LeftProperty, Math.Min(px, cx));
            l.SetValue(Canvas.TopProperty, Math.Min(py, cy));

            parent.RightChildEdge= l;
        }

        void SwipeResult()
        {
            if (ResultMode == 1)
            {
                ResultMode = 2;
            }
            else
            {
                ResultMode = 1;
            }
        }

        void CreateDemoAnimation()
        {
            //Create node control 2 in order
            wp_NC2.Children.Clear();
            for (int i = 0; i < NodesInOrder.Count; i++)
            {
                HuffmanNodeControl2 nc2 = new HuffmanNodeControl2(NodesInOrder[i]);
                NodesInOrder[i].NodeControl2 = nc2;
                wp_NC2.Children.Add(nc2);
                if (NodesInOrder[i].IsCompositeNode)
                {
                    (nc2.LayoutTransform as ScaleTransform).ScaleX = 0;
                }
            }

            if (DemoAnimationStoryboard == null)
            {
                DemoAnimationStoryboard = new Storyboard();
                DemoAnimationStoryboard.Completed += new EventHandler(DemoAnimationStoryboard_Completed);
            }
            else
            {
                DemoAnimationStoryboard.Stop();
                DemoAnimationStoryboard.Children.Clear();
            }

            sliderTimeline.Value = 0;

            AnimationMode = "Stopped";
            btnPlayPause.Visibility = System.Windows.Visibility.Visible;
            imgPlayPause.Source = PlayImageSource;
            btnStop.Visibility = System.Windows.Visibility.Collapsed;

            int frame_duration = 500;
            int t = 0;

            //On first frame hide all nodes
            for (int i = 0; i < NodesInOrder.Count; i++)
            {
                HuffmanNode node = NodesInOrder[i];
                HuffmanNodeControl hnc = node.NodeControl;
                if (hnc != null)
                {
                    DoubleAnimation da = new DoubleAnimation(0, TimeSpan.FromMilliseconds(frame_duration));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t);
                    Storyboard.SetTarget(da, hnc);
                    Storyboard.SetTargetProperty(da, new PropertyPath(UIElement.OpacityProperty));
                    DemoAnimationStoryboard.Children.Add(da);

                    if (node.IsCompositeNode)
                    {
                        if (hnc.LeftChildEdge != null)
                        {
                            DoubleAnimation da1 = new DoubleAnimation(0, TimeSpan.FromMilliseconds(frame_duration));
                            da1.EasingFunction = QEaseOut;
                            da1.BeginTime = TimeSpan.FromMilliseconds(t);
                            Storyboard.SetTarget(da1, hnc.LeftChildEdge);
                            Storyboard.SetTargetProperty(da1, new PropertyPath(Line.OpacityProperty));
                            DemoAnimationStoryboard.Children.Add(da1);
                        }
                        if (hnc.RightChildEdge != null)
                        {
                            DoubleAnimation da1 = new DoubleAnimation(0, TimeSpan.FromMilliseconds(frame_duration));
                            da1.EasingFunction = QEaseOut;
                            da1.BeginTime = TimeSpan.FromMilliseconds(t);
                            Storyboard.SetTarget(da1, hnc.RightChildEdge);
                            Storyboard.SetTargetProperty(da1, new PropertyPath(Line.OpacityProperty));
                            DemoAnimationStoryboard.Children.Add(da1);
                        }
                    }
                }
            }

            {
                DoubleAnimation da = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(frame_duration));
                da.EasingFunction = QEaseOut;
                da.BeginTime = TimeSpan.FromMilliseconds(t);
                Storyboard.SetTarget(da, TopBar);
                Storyboard.SetTargetProperty(da, new PropertyPath(UIElement.OpacityProperty));
                DemoAnimationStoryboard.Children.Add(da);
            }

            //Show Top bar


            t += frame_duration;

            for (int i = 0; i < Compositions.Count; i++)
            {
                Composition c = Compositions[i];
                HuffmanNodeControl lhnc = c.LeftChild.NodeControl;
                HuffmanNodeControl rhnc = c.RightChild.NodeControl;
                HuffmanNodeControl phnc = c.Parent.NodeControl;

                HuffmanNodeControl2 lhnc2 = c.LeftChild.NodeControl2;
                HuffmanNodeControl2 rhnc2 = c.RightChild.NodeControl2;
                HuffmanNodeControl2 phnc2 = c.Parent.NodeControl2;

                Line lcl = phnc.LeftChildEdge;
                Line rcl = phnc.RightChildEdge;

                {
                    DoubleAnimation da = new DoubleAnimation(1, TimeSpan.FromMilliseconds(frame_duration));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t);
                    Storyboard.SetTarget(da, lhnc);
                    Storyboard.SetTargetProperty(da, new PropertyPath(UIElement.OpacityProperty));
                    DemoAnimationStoryboard.Children.Add(da);
                }

                {
                    DoubleAnimation da = new DoubleAnimation(1, TimeSpan.FromMilliseconds(frame_duration));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t);
                    Storyboard.SetTarget(da, rhnc);
                    Storyboard.SetTargetProperty(da, new PropertyPath(UIElement.OpacityProperty));
                    DemoAnimationStoryboard.Children.Add(da);
                }

                //Node control 2
                {
                    DoubleAnimation da = new DoubleAnimation(0.3, TimeSpan.FromMilliseconds(frame_duration));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t);
                    Storyboard.SetTarget(da, lhnc2);
                    Storyboard.SetTargetProperty(da, new PropertyPath(UIElement.OpacityProperty));
                    DemoAnimationStoryboard.Children.Add(da);
                }

                {
                    DoubleAnimation da = new DoubleAnimation(0.3, TimeSpan.FromMilliseconds(frame_duration));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t);
                    Storyboard.SetTarget(da, rhnc2);
                    Storyboard.SetTargetProperty(da, new PropertyPath(UIElement.OpacityProperty));
                    DemoAnimationStoryboard.Children.Add(da);
                }

                t += frame_duration;

                //Scale
                //left child
                {
                    DoubleAnimation da = new DoubleAnimation(1.2, TimeSpan.FromMilliseconds(frame_duration/2));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t);
                    Storyboard.SetTarget(da, lhnc);
                    Storyboard.SetTargetProperty(da, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                    DemoAnimationStoryboard.Children.Add(da);
                }

                {
                    DoubleAnimation da = new DoubleAnimation(1.2, TimeSpan.FromMilliseconds(frame_duration / 2));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t);
                    Storyboard.SetTarget(da, lhnc);
                    Storyboard.SetTargetProperty(da, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));
                    DemoAnimationStoryboard.Children.Add(da);
                }

                {
                    DoubleAnimation da = new DoubleAnimation(1, TimeSpan.FromMilliseconds(frame_duration / 2));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t + frame_duration / 2);
                    Storyboard.SetTarget(da, lhnc);
                    Storyboard.SetTargetProperty(da, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                    DemoAnimationStoryboard.Children.Add(da);
                }

                {
                    DoubleAnimation da = new DoubleAnimation(1, TimeSpan.FromMilliseconds(frame_duration / 2));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t + frame_duration / 2);
                    Storyboard.SetTarget(da, lhnc);
                    Storyboard.SetTargetProperty(da, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));
                    DemoAnimationStoryboard.Children.Add(da);
                }

                //right child
                {
                    DoubleAnimation da = new DoubleAnimation(1.2, TimeSpan.FromMilliseconds(frame_duration / 2));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t);
                    Storyboard.SetTarget(da, rhnc);
                    Storyboard.SetTargetProperty(da, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                    DemoAnimationStoryboard.Children.Add(da);
                }

                {
                    DoubleAnimation da = new DoubleAnimation(1.2, TimeSpan.FromMilliseconds(frame_duration / 2));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t);
                    Storyboard.SetTarget(da, rhnc);
                    Storyboard.SetTargetProperty(da, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));
                    DemoAnimationStoryboard.Children.Add(da);
                }

                {
                    DoubleAnimation da = new DoubleAnimation(1, TimeSpan.FromMilliseconds(frame_duration / 2));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t + frame_duration / 2);
                    Storyboard.SetTarget(da, rhnc);
                    Storyboard.SetTargetProperty(da, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
                    DemoAnimationStoryboard.Children.Add(da);
                }

                {
                    DoubleAnimation da = new DoubleAnimation(1, TimeSpan.FromMilliseconds(frame_duration / 2));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t + frame_duration / 2);
                    Storyboard.SetTarget(da, rhnc);
                    Storyboard.SetTargetProperty(da, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));
                    DemoAnimationStoryboard.Children.Add(da);
                }


                //Lines
                {
                    DoubleAnimation da = new DoubleAnimation(1, TimeSpan.FromMilliseconds(frame_duration));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t);
                    Storyboard.SetTarget(da, lcl);
                    Storyboard.SetTargetProperty(da, new PropertyPath(UIElement.OpacityProperty));
                    DemoAnimationStoryboard.Children.Add(da);
                }

                {
                    DoubleAnimation da = new DoubleAnimation(1, TimeSpan.FromMilliseconds(frame_duration));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t);
                    Storyboard.SetTarget(da, rcl);
                    Storyboard.SetTargetProperty(da, new PropertyPath(UIElement.OpacityProperty));
                    DemoAnimationStoryboard.Children.Add(da);
                }

                //Parent
                {
                    DoubleAnimation da = new DoubleAnimation(1, TimeSpan.FromMilliseconds(frame_duration));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t);
                    Storyboard.SetTarget(da, phnc);
                    Storyboard.SetTargetProperty(da, new PropertyPath(UIElement.OpacityProperty));
                    DemoAnimationStoryboard.Children.Add(da);
                }

                {
                    DoubleAnimation da = new DoubleAnimation(1, TimeSpan.FromMilliseconds(frame_duration));
                    da.EasingFunction = QEaseOut;
                    da.BeginTime = TimeSpan.FromMilliseconds(t);
                    Storyboard.SetTarget(da, phnc2);
                    Storyboard.SetTargetProperty(da, new PropertyPath("(UserControl.LayoutTransform).(ScaleTransform.ScaleX)"));
                    DemoAnimationStoryboard.Children.Add(da);
                }

                t += frame_duration;
            }

            t += frame_duration;
            DemoAnimationStoryboard.Duration = TimeSpan.FromMilliseconds(t + 1000); 

            sliderTimeline.Minimum = 0;
            sliderTimeline.Maximum = t;
            sliderTimeline.SmallChange = 1;

            DemoAnimationStoryboard.CurrentTimeInvalidated += new EventHandler(DemoAnimationStoryboard_CurrentTimeInvalidated);

            DemoAnimationStoryboard.Begin();
            DemoAnimationStoryboard.Stop();
            ControlBar.Visibility = System.Windows.Visibility.Visible;
        }

        void DemoAnimationStoryboard_Completed(object sender, EventArgs e)
        {            
            AnimationMode = "Stopped"; 
            btnStop.Visibility = System.Windows.Visibility.Collapsed; 
            imgPlayPause.Source = PlayImageSource;
            DemoAnimationStoryboard.Pause();
            DemoAnimationStoryboard.Stop();
        }

        void DemoAnimationStoryboard_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            sliderTimeline.Value = DemoAnimationStoryboard.GetCurrentProgress() * DemoAnimationStoryboard.Duration.TimeSpan.TotalMilliseconds;            
        }

        #endregion

        #region EventHandlers

        #endregion

        #region WindowEventHanders

        private void btnClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        #endregion

        private void CanvasGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CanvasTreeMouseDown = true;
            CanvasTreeMouseDownPosition = e.GetPosition(CanvasGrid);
            CanvasTreeMouseDownTransformX = canvasTreeTT.X;
            CanvasTreeMouseDownTransformY = canvasTreeTT.Y;
            CanvasGrid.Cursor = Cursors.ScrollAll;
        }

        private void CanvasGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (CanvasTreeMouseDown)
            {
                Point p = e.GetPosition(CanvasGrid);
                canvasTreeTT.X = CanvasTreeMouseDownTransformX - (CanvasTreeMouseDownPosition.X - p.X);
                canvasTreeTT.Y = CanvasTreeMouseDownTransformY - (CanvasTreeMouseDownPosition.Y - p.Y);
            }
        }

        private void CanvasGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CanvasTreeMouseDown = false;
            CanvasGrid.Cursor = Cursors.Arrow;
        }

        private void CanvasGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (CanvasGridMouseEnterStoryboard == null)
            {
                CanvasGridMouseEnterStoryboard = new Storyboard();
                CanvasGridMouseEnterStoryboard.Duration = TimeSpan.FromMilliseconds(200);

                {
                    ThicknessAnimation ta = new ThicknessAnimation(new Thickness(0, 0, 0, 0), TimeSpan.FromMilliseconds(200));
                    ta.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
                    ta.EasingFunction = QEaseOut;
                    Storyboard.SetTarget(ta, ControlBar);
                    Storyboard.SetTargetProperty(ta, new PropertyPath(Border.MarginProperty));
                    CanvasGridMouseEnterStoryboard.Children.Add(ta);
                }
                {
                    DoubleAnimation da = new DoubleAnimation(1, TimeSpan.FromMilliseconds(200));
                    da.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
                    da.EasingFunction = QEaseOut;
                    Storyboard.SetTarget(da, ToolPanel);
                    Storyboard.SetTargetProperty(da, new PropertyPath(StackPanel.OpacityProperty));
                    CanvasGridMouseEnterStoryboard.Children.Add(da);
                }
            }
            CanvasGridMouseEnterStoryboard.Stop();
            CanvasGridMouseEnterStoryboard.Begin();
        }

        private void CanvasGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (CanvasGridMouseLeaveStoryboard == null)
            {
                CanvasGridMouseLeaveStoryboard = new Storyboard();
                CanvasGridMouseLeaveStoryboard.Duration = TimeSpan.FromMilliseconds(200);

                {
                    ThicknessAnimation ta = new ThicknessAnimation(new Thickness(0, 0, 0, -60), TimeSpan.FromMilliseconds(200));
                    ta.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
                    ta.EasingFunction = QEaseOut;
                    Storyboard.SetTarget(ta, ControlBar);
                    Storyboard.SetTargetProperty(ta, new PropertyPath(Border.MarginProperty));
                    CanvasGridMouseLeaveStoryboard.Children.Add(ta);
                }
                {
                    DoubleAnimation da = new DoubleAnimation(0.2, TimeSpan.FromMilliseconds(200));
                    da.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
                    da.EasingFunction = QEaseOut;
                    Storyboard.SetTarget(da, ToolPanel);
                    Storyboard.SetTargetProperty(da, new PropertyPath(StackPanel.OpacityProperty));
                    CanvasGridMouseLeaveStoryboard.Children.Add(da);
                }
            }
            CanvasGridMouseLeaveStoryboard.Stop();
            CanvasGridMouseLeaveStoryboard.Begin();
        }

        private void CanvasGrid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta != 0)
            {
                if (this.CurrentTool == "Zoom")
                {
                    DoubleAnimation da = new DoubleAnimation(sliderCanvasScale.Value + e.Delta / 1200.0, TimeSpan.FromMilliseconds(100));
                    sliderCanvasScale.BeginAnimation(Slider.ValueProperty, da);
                }
                else if (this.CurrentTool == "Move")
                {
                    if (Keyboard.Modifiers == ModifierKeys.Shift)
                    {
                        DoubleAnimation da = new DoubleAnimation(canvasTreeTT.X + e.Delta / 2, TimeSpan.FromMilliseconds(100));
                        canvasTreeTT.BeginAnimation(TranslateTransform.XProperty, da);
                    }
                    else
                    {
                        DoubleAnimation da = new DoubleAnimation(canvasTreeTT.Y + e.Delta / 2, TimeSpan.FromMilliseconds(100));
                        canvasTreeTT.BeginAnimation(TranslateTransform.YProperty, da);
                    }
                }
            }
        }

        private void sliderCanvasScale_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtCanvasScale.Text = (int)(sliderCanvasScale.Value * 100) + "%";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //Reset
            if (e.Key == Key.R)
            {
                sliderCanvasScale.Value = 1.0;
                canvasTreeTT.X = 0;
                canvasTreeTT.Y = 0;
            }
        }

        private void toolMove_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            toolMove.Opacity = 1.0;
            toolZoom.Opacity = 0.5;
            this.CurrentTool = "Move";
        }

        private void toolZoom_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            toolMove.Opacity = 0.5;
            toolZoom.Opacity = 1.0;
            this.CurrentTool = "Zoom";
        }

        private void txtTextToEncode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Run();
            }
        }
        
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void imgLogo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AC_AboutTLABS.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RunStartupAnimation();
            AC_AboutTLABS.Initialize();
        }

        private void btnEncode_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Run();
        }

        private void btnSwipeResultLeft_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SwipeResult();
        }

        private void btnSwipeResultRight_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SwipeResult();
        }

        private void ResultGrid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            SwipeResult();
        }

        private void iconHelp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://en.wikipedia.org/wiki/Huffman_coding");
        }       

        private void btnPlayPause_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (AnimationMode)
            {
                case "Playing": //pause button
                    if (DemoAnimationStoryboard != null)
                    {
                        DemoAnimationStoryboard.Pause();
                        imgPlayPause.Source = PlayImageSource;
                        AnimationMode = "Paused";
                        btnStop.Visibility = System.Windows.Visibility.Collapsed;
                    }
                    break;
                case "Paused":
                    if (DemoAnimationStoryboard != null)
                    {
                        DemoAnimationStoryboard.Resume();
                        imgPlayPause.Source = PauseImageSource;
                        AnimationMode = "Playing";
                        btnStop.Visibility = System.Windows.Visibility.Visible;
                    }
                    break;
                case "Stopped":
                    if(DemoAnimationStoryboard != null)
                    {
                        DemoAnimationStoryboard.Stop(); //Confirm stop
                        DemoAnimationStoryboard.Begin();
                        imgPlayPause.Source = PauseImageSource;
                        AnimationMode="Playing";
                        btnStop.Visibility = System.Windows.Visibility.Visible;
                    }
                    break;
            }
            e.Handled = true;
        }

        private void btnStop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DemoAnimationStoryboard != null)
            {
                DemoAnimationStoryboard.Stop();
                sliderTimeline.Value = 0;
                imgPlayPause.Source = PlayImageSource;
                AnimationMode = "Stopped";
                btnStop.Visibility = System.Windows.Visibility.Collapsed;

            }
            e.Handled = true;
        }

        private void btnSoundOnOff_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        //private void sliderTimeline_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    IsSeeking = true;
        //    AnimationStateBeforeSeeking = AnimationMode;
        //    if (AnimationMode == "Playing")
        //    {
        //        DemoAnimationStoryboard.Pause();
        //    }
        //    txtTime.Opacity = .75;
        //    e.Handled = true;
        //}

        //private void sliderTimeline_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    if (AnimationStateBeforeSeeking == "Playing")
        //    {
        //        DemoAnimationStoryboard.Resume();
        //    }
        //    txtTime.Opacity = 1.0;
        //    IsSeeking = false;
        //    e.Handled = true;
        //}

        private void sliderTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (AnimationMode!= "Playing")
            {                      
                DemoAnimationStoryboard.Seek(TimeSpan.FromMilliseconds(sliderTimeline.Value));
            }
            txtTime.Text = TimeSpan.FromMilliseconds(sliderTimeline.Value).TotalSeconds.ToString("F2");
        }

        private void imgFitGraph_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            double scale_x = CanvasGrid.ActualWidth / canvasTree.Width;
            double scale_y = CanvasGrid.ActualHeight / canvasTree.Height;
            double scale = Math.Min(scale_x, scale_y);

            sliderCanvasScale.Tag = scale;

            if (FitGraphStoryboard == null)
            {
                FitGraphStoryboard = new Storyboard();
                FitGraphStoryboard.Completed += new EventHandler(FitGraphStoryboard_Completed);
            }

            FitGraphStoryboard.Stop();
            FitGraphStoryboard.Children.Clear();

            {
                DoubleAnimation da = new DoubleAnimation(scale, TimeSpan.FromMilliseconds(500));
                da.EasingFunction = QEaseOut;
                da.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
                Storyboard.SetTarget(da, sliderCanvasScale);
                Storyboard.SetTargetProperty(da, new PropertyPath(Slider.ValueProperty));
                FitGraphStoryboard.Children.Add(da);          
            }

            {
                DoubleAnimation da = new DoubleAnimation(0, TimeSpan.FromMilliseconds(500));
                da.EasingFunction = QEaseOut;
                da.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
                Storyboard.SetTarget(da, canvasTree);
                Storyboard.SetTargetProperty(da, new PropertyPath("(Canvas.RenderTransform).(TranslateTransform.X)"));
                FitGraphStoryboard.Children.Add(da);   
            }

            {
                DoubleAnimation da = new DoubleAnimation(0, TimeSpan.FromMilliseconds(500));
                da.EasingFunction = QEaseOut;
                da.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
                Storyboard.SetTarget(da, canvasTree);
                Storyboard.SetTargetProperty(da, new PropertyPath("(Canvas.RenderTransform).(TranslateTransform.Y)"));
                FitGraphStoryboard.Children.Add(da);   
            }

            FitGraphStoryboard.Duration = TimeSpan.FromMilliseconds(500);
            FitGraphStoryboard.FillBehavior = FillBehavior.Stop;
            
            FitGraphStoryboard.Begin();
        }

        void FitGraphStoryboard_Completed(object sender, EventArgs e)
        {          
            sliderCanvasScale.Value = (double)sliderCanvasScale.Tag;
            canvasTreeTT.X = 0;
            canvasTreeTT.Y = 0;
        }
    }
}
