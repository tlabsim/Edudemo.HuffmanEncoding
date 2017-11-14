using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EduDemo.HuffmanCoding
{
    /// <summary>
    /// Interaction logic for HuffmanNodeControl2.xaml
    /// </summary>
    public partial class HuffmanNodeControl2 : UserControl
    {
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
                txtName.Text = _Node.Title;                
                txtFrequency.Text = _Node.Frequency.ToString();
                if (_Node.IsCompositeNode)
                {
                    this.ToolTip = "Composite node";
                }
            }
        }

        public HuffmanNodeControl2(HuffmanNode node)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Node = node;
        }
    }
}
