using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Newtonsoft.Json;
using System.Windows.Markup;
using System;
using Newtonsoft.Json.Linq;

namespace Commons.Wpf.ControlLibrary
{
    /// <summary>
    /// A RichTextBox formatter used to format sql code used by SQLHelper
    /// </summary>
    public static class SQLHelperRTB
    {
        public static readonly DependencyProperty BoundDocument =
        DependencyProperty.RegisterAttached("BoundDocument", typeof(string), typeof(SQLHelperRTB),
        new FrameworkPropertyMetadata(null,
        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
        OnBoundDocumentChanged));

        private static void OnBoundDocumentChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
            RichTextBox box = d as RichTextBox;

            if (box == null)
                return;

            RemoveEventHandler(box);
            string boundData = GetBoundDocument(d);            

            if (!string.IsNullOrEmpty(boundData))
            {
                if (!boundData.Contains("<Section xmlns")) // Only proceed if there is nothing continaing this tag combination (Garbage Section tag gets added when you focus onto RTB even in ReadyOnly mode)
                {
                    box.Document.Blocks.Clear(); //Clear here as you dont want to clear when RichTextBox obtains focus 

                    try
                    {
                        JArray boundJsonData = (JArray)JsonConvert.DeserializeObject(boundData);

                        Section section = new Section();
                        Paragraph paragraph = null;

                        foreach (JToken token in boundJsonData.Children())
                        {
                            if (token.HasValues)
                            {
                                paragraph = new Paragraph();

                                Run resultRun = new Run(token["Result"].ToString());
                                resultRun.FontWeight = FontWeights.Bold;
                                resultRun.FontSize = 14;
                                resultRun.Foreground = (token["Result"].ToString().ToLower().Contains("error")) ? 
                                    (System.Windows.Media.Brush)Application.Current.Resources["ErrorStatusFontColor"] : 
                                    (System.Windows.Media.Brush)Application.Current.Resources["SuccessStatusFontColor"];

                                paragraph.Inlines.Add(resultRun);
                                paragraph.Inlines.Add(new LineBreak());

                                Run codeRun = null;
                                string[] sqlArray = token["SQL"].ToString().Split('\n');
                                foreach (string line in sqlArray)
                                {
                                    codeRun = new Run(line.Trim('\r'));
                                    codeRun.FontSize = 14;

                                    if (line.Contains("[PARAMERROR]"))
                                    {
                                        codeRun.Text = codeRun.Text.Replace("[PARAMERROR]", string.Empty);
                                        codeRun.Foreground = (System.Windows.Media.Brush)Application.Current.Resources["ErrorStatusFontColor"];
                                    }                                        

                                    paragraph.Inlines.Add(codeRun);
                                    paragraph.Inlines.Add(new LineBreak());
                                }

                                section.Blocks.Add(paragraph);
                            }
                        }                        
                        box.Document.Blocks.Add(section);
                    }   
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }           

                    // The below would only be used if the bounddata passed was XAML
                    //using (MemoryStream xamlMemoryStream = new MemoryStream(Encoding.ASCII.GetBytes(string.Format("<Section>{0}</Section>", newXAML)))) // Wrap in Section element here 
                    //{
                    //    ParserContext parser = new ParserContext();
                    //    parser.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
                    //    parser.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
                    //    FlowDocument doc = new FlowDocument();

                    //    Section section = XamlReader.Load(xamlMemoryStream, parser) as Section;
                    //    box.Document.Blocks.Add(section);
                    //}
                }                
            }
            AttachEventHandler(box);
        }

        private static void RemoveEventHandler( RichTextBox box )
        {
            Binding binding = BindingOperations.GetBinding(box, BoundDocument);

            if (binding != null)
            {
                if (binding.UpdateSourceTrigger == UpdateSourceTrigger.Default ||
                binding.UpdateSourceTrigger == UpdateSourceTrigger.LostFocus)
                {
                    box.LostFocus -= HandleLostFocus;
                }
                else
                {
                    box.TextChanged -= HandleTextChanged;
                }
            }
        }

        private static void AttachEventHandler( RichTextBox box )
        {
            Binding binding = BindingOperations.GetBinding(box, BoundDocument);
            if (binding != null)
            {
                if (binding.UpdateSourceTrigger == UpdateSourceTrigger.Default ||
                binding.UpdateSourceTrigger == UpdateSourceTrigger.LostFocus)
                {
                    box.LostFocus += HandleLostFocus;
                }
                else
                {
                    box.TextChanged += HandleTextChanged;
                }
            }
        }

        private static void HandleLostFocus( object sender, RoutedEventArgs e )
        {

            RichTextBox box = sender as RichTextBox;
            TextRange tr = new TextRange(box.Document.ContentStart, box.Document.ContentEnd);
            using (MemoryStream ms = new MemoryStream())
            {
                tr.Save(ms, DataFormats.Xaml);
                string xamlText = ASCIIEncoding.Default.GetString(ms.ToArray());
                SetBoundDocument(box, xamlText);
            }
        }

        private static void HandleTextChanged( object sender, RoutedEventArgs e )
        {
            // TODO: TextChanged is currently not working!
            RichTextBox box = sender as RichTextBox;
            TextRange tr = new TextRange(box.Document.ContentStart,
            box.Document.ContentEnd);

            using (MemoryStream ms = new MemoryStream())
            {
                tr.Save(ms, DataFormats.Xaml);
                string xamlText = ASCIIEncoding.Default.GetString(ms.ToArray());
                SetBoundDocument(box, xamlText);
            }
        }

        public static string GetBoundDocument( DependencyObject dp )
        {
            return dp.GetValue(BoundDocument) as string;
        }

        public static void SetBoundDocument( DependencyObject dp, string value )
        {
            dp.SetValue(BoundDocument, value);
        }
    }
}
