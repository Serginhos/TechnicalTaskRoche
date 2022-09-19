using RocheTechnicalTask.UIWPF.Model;
using RocheTechnicalTask.UIWPF.ViewModel.Commands;
using RocheTechnicalTask.UIWPF.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocheTechnicalTask.UIWPF.ViewModel
{
    public class TextFileVM : INotifyPropertyChanged
    {
        private string text;

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        private TextFile textFile;

        public TextFile TextFile
        {
            get { return textFile; }
            set
            {
                textFile = value;
                OnPropertyChanged("TextFile");
            }
        }

        private int coincidences;

        public int Coincidences
        {
            get { return coincidences; }
            set
            {
                coincidences = value;
                OnPropertyChanged("Coincidences");
            }
        }

        private double totalCoincidences;

        public double TotalCoincidences
        {
            get { return totalCoincidences; }
            set
            {
                totalCoincidences = value;
                OnPropertyChanged("TotalCoincidences");
            }
        }

        private double totalFiles;

        public double TotalFiles
        {
            get { return totalFiles; }
            set
            {
                totalFiles = value;
                OnPropertyChanged("TotalFiles");
            }
        }

        public ObservableCollection<TextFile> Files { get; set; }

        public TextFileVM()
        {
            SearchCommand = new SearchCommand(this);
            Files = new ObservableCollection<TextFile>();
        }

        public SearchCommand SearchCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;


        public async void MakeQuery()
        {
            var files = await TextFileHelper.GetTextFiles(Text);

            Files.Clear();
            foreach (var file in files)
            {
                Files.Add(file);
            }
            TotalFiles = Files.Count;
            TotalCoincidences = Files.Sum(f => f.Coincidences);


        }


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
