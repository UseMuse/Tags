﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tags.ViewModel
{
    public class ViewModelTag : BaseInpc
    {
        public static ViewModelTag FirstTag = new ViewModelTag("Теги", false);

        private bool isChecked;
        public bool IsChecked
        {
            get => isChecked;
            set => Set(ref isChecked, value);
        }

        private string title;
        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }

        private bool isEnabled = true;
        public bool IsEnabled
        {
            get => isEnabled;
            set => Set(ref isEnabled, value);
        }
        public ViewModelTag(string title, bool isEnabled) : this(title)
        {
            IsEnabled = isEnabled;
        }
        public ViewModelTag(string title)
        {
            this.Title = title;

            CheckedCommand = new RelayCommand((object parameter) =>
                     {

                     });
            UncheckedCommand = new RelayCommand((object parameter) =>
            {

            });
            SelectionChangedCommand = new RelayCommand((object parameter) =>
            {

            });

        }
        public ICommand CheckedCommand { get; set; }
        public ICommand UncheckedCommand { get; set; }

        public ICommand SelectionChangedCommand { get; set; }
    }
}
