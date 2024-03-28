using EvernoteClone.Model;
using EvernoteClone.ViewModel;
using EvernoteClone.ViewModel.Helper;
using System.Globalization;
using System.IO;
using System.Speech.Recognition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;

namespace EvernoteClone.View
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        SpeechRecognitionEngine recognizer;
        NotesVM viewModel;
        
        public NotesWindow()
        {
            InitializeComponent();

            //var currentCulture = (from r in SpeechRecognitionEngine.InstalledRecognizers()
            //                      where r.Culture.Equals(Thread.CurrentThread.CurrentCulture)
            //                      select r);


            viewModel = Resources["notesVM"] as NotesVM;
            viewModel.SelectedNoteChange += ViewModel_SelectedNoteChange;
            
            recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));

            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Culture = CultureInfo.GetCultureInfo("en-US");
            grammarBuilder.AppendDictation();
            Grammar grammar = new Grammar(grammarBuilder);

            recognizer.LoadGrammar(grammar);
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.SpeechRecognized += Recognizer_SpeechRecognized;

            var fontFamilies = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            fontFamilyComboBox.ItemsSource = fontFamilies;

            var FontSizeList = new List<int> { 8, 9, 12, 14, 16, 18, 20, 24, 36, 72 };

            fontSizeComboBox.ItemsSource = FontSizeList;
           

        }

        private void ViewModel_SelectedNoteChange(object? sender, EventArgs e)
        {
            contentRichTextBox.Document.Blocks.Clear();

            if (viewModel.SelectedNote != null)
            {
                if (!string.IsNullOrEmpty(viewModel.SelectedNote.FileLocation))
                {
                    using (FileStream fileStream = new FileStream(viewModel.SelectedNote.FileLocation, FileMode.Open))
                    {
                        var contents = new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd);
                        contents.Load(fileStream, DataFormats.Rtf);
                    }
                    
                }
            }
        }

        private void Recognizer_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            string recognizedText = e.Result.Text;
            contentRichTextBox.Document.Blocks.Add(new Paragraph(new Run(recognizedText)));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        bool isRecognizing = false;

        private void SpeechButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isRecognizing)
            {
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
                isRecognizing = true;
            }
            else
            {
                recognizer.RecognizeAsyncStop();

                isRecognizing = false;
            }


            #region
            //string region = "westeurope";
            //string key = "9a0436739e634900b22522533d8e10bf";
            //var speechConfig = SpeechConfig.FromSubscription(key, region);

            //using (var audioConfig = AudioConfig.FromDefaultMicrophoneInput())
            //{
            //    using (var recognizer = new SpeechRecognizer(speechConfig, audioConfig))
            //    {
            //        var result = await recognizer.RecognizeOnceAsync();
            //        contentRichTextBox.Document.Blocks.Add(new Paragraph(new Run(result.Text)));

            //    }
            //}
            #endregion
        }

        private void contentRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int ammountOfCharacters = (new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd)).Text.Length;

            statusTextBlock.Text = $"Document lenght: {ammountOfCharacters} characters";
            
            

        }

        private void boldBtn_Click(object sender, RoutedEventArgs e)
        {

            var isChecked = sender as ToggleButton;

            if (isChecked?.IsChecked == true)
                contentRichTextBox.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
            else if (isChecked?.IsChecked == false)
                contentRichTextBox.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Normal);


        }

        private void contentRichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedWeight = contentRichTextBox.Selection.GetPropertyValue(FontWeightProperty);
            boldBtn.IsChecked = selectedWeight != DependencyProperty.UnsetValue && selectedWeight.Equals(FontWeights.Bold);

            fontFamilyComboBox.SelectedItem = contentRichTextBox.Selection.GetPropertyValue(FontFamilyProperty);
            fontSizeComboBox.SelectedItem = contentRichTextBox.Selection.GetPropertyValue(FontSizeProperty);

        }

        private void fontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fontFamilyComboBox.SelectedItem != null)
            {
                contentRichTextBox.Selection.ApplyPropertyValue(FontFamilyProperty,fontFamilyComboBox.SelectedItem);
            }
        }

        private void fontSizeComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            contentRichTextBox.Selection.ApplyPropertyValue(FontSizeProperty, fontSizeComboBox.Text); // Text because user can write its own value.
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            string rftFile = Path.Combine(Environment.CurrentDirectory, $"{viewModel.SelectedNote.Id}.rtf");
            viewModel.SelectedNote.FileLocation = rftFile;
            DatabaseHelper.Update(viewModel.SelectedNote);
            using (FileStream fileStream = new FileStream(rftFile, FileMode.Create))
            {
                var contents = new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd);
                contents.Save(fileStream, DataFormats.Rtf);
            }

        }

        
    }
}
