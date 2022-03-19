using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace WordCounter {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private TableRowBuilder builder;
        public MainWindow() {
            InitializeComponent();
            builder = new TableRowBuilder();
        }

        private void LoadFileButton_Click(object sender, RoutedEventArgs e) {

            var dialogFile = new OpenFileDialog();
            dialogFile.Filter = "txt files (*.txt)|*.txt";

            Dictionary<string, int> dic = new Dictionary<string, int>();

            if (dialogFile.ShowDialog().Value) {

                string filePath = dialogFile.FileName;
                var fileStream = dialogFile.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream)) {

                    string currentLine;

                    while ((currentLine = reader.ReadLine()) != null) {

                        var words = currentLine.Split(' ', '\n');

                        for (int i = 0; i < words.Count(); i++) {

                            string currentWord = words[i];

                            if (currentWord == String.Empty) continue;

                            currentWord = currentWord.ToLower().Trim(
                                ',', '.', ';', ':', '[', ']', '?', '!',
                                '-', '\"');

                            if (int.TryParse(currentWord, out int r)) continue;

                            if (dic.ContainsKey(currentWord)) {
                                dic[currentWord]++;
                            }
                            else {
                                dic.Add(currentWord, 1);
                            }
                        }
                    }
                }

                TableRowGroup.Rows.Clear();

                int index = 1;

                foreach (var item in dic.OrderByDescending(i => i.Value)) {
                    TableRowGroup.Rows.Add(builder.Build(index, item.Key, item.Value));
                    index++;
                }
            }
        }
    }
}
