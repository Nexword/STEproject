using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Markup;

namespace STE
{
    interface ISTEProcessor { }
    
    class STEXAMLProcessor:ISTEProcessor
    {
        public List<UIElement> pages = new List<UIElement>();
       
        
        public void TestParse(XmlReader testSet,XmlReader taskSet)
        { 
            switch (testSet.Name)
            {
                case "test": ; break;
                case "note": ; break;
                case "block": MakeWPFBlock(testSet.GetAttribute("id")) ; break;
                case "task": AddWPFTask(testSet.GetAttribute("key"),taskSet); break;      
            }
        }

        public List<UIElement> GetPagesList(XmlReader testSet, XmlReader taskSet)
        { 
            while (!testSet.EOF)
            {
                if (testSet.MoveToContent() == XmlNodeType.Element)
                    TestParse(testSet,taskSet); 
                testSet.Read();  
            }
            return pages;
        }

        public void MakeWPFBlock(string Name)
        {
           
            StackPanel Stack = new StackPanel();
            Stack.Name=Name;
            pages.Add(Stack);
            //string SStackPanel = @"<StackPanel></StackPanel>";
            //StringReader sr = new StringReader(SStackPanel);
            //XmlReader reader = XmlReader.Create(sr);
            //Pages.Add( (StackPanel)XamlReader.Load(reader));
        }

        public void Button1_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Content="Yes";

        }


        public void MakeTaskElements(string suffix, XmlReader taskSet)
        {
            while (taskSet.Name != "question")
                taskSet.Read();
            Label myLabel = new Label();
            myLabel.Name = "MyLabel" + suffix;
            myLabel.Content = taskSet.GetAttribute("key");
            myLabel.FontSize = 20;
            taskSet.Read();
            string xaml = 
                "<Button x:Name='MyButton' Content='Fucking button' Click=Button1_Click   xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'   xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'> "
               +"<Button.ToolTip> <ToolTip Background='#90004455'> </ToolTip></Button.ToolTip>"+
               " </Button>";

             
                
                
                
                
               
            string xaml1 = 
        "<Grid Margin='10' " +
        "xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' " +
        "xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' " + 
        "</Grid>";
            StringReader stringReader = new StringReader(xaml);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            
            UIElement buffer = (UIElement)XamlReader.Parse(xaml);
            //(buffer as Button).Click += Button1_Click;
            (buffer as Button).Content="Hello";
          
            (pages.Last() as StackPanel).Children.Add(buffer);
           


        }

        public void AddWPFTask(string id,XmlReader taskSet)
        {
            while ((taskSet.Name!="task") && (taskSet.GetAttribute("id")!=id)) 
               taskSet.Read();
            MakeTaskElements(id,taskSet);
            
        }

    }

    
}
