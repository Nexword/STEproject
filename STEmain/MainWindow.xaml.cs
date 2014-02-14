using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartMain();
        }

        public List<UIElement> Pages = new List<UIElement>();
        public void StartMain()
        {
            GetXml xrdr = new GetXml();
            STEXAMLProcessor xamlProcessor = new STEXAMLProcessor();
            XmlReader TestSet, TaskSet;
            TestSet = xrdr.GetXMLTest();
            TaskSet = xrdr.GetXMLTask();
            Pages= xamlProcessor.GetPagesList(TestSet,TaskSet);
            //STEWin.Content = Pages[0];
            STEWin.Content = Pages[1];
          
          
        }
    }
}
