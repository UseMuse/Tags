using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tags.ViewModel
{
    public class ViewModelMain : BaseInpc
    {
        public ObservableCollection<ViewModelTag> Tags { get; }
            = new ObservableCollection<ViewModelTag>();

        private ObservableCollection<ViewModelTag> _selectedTags;
        public ObservableCollection<ViewModelTag> SelectedTags
        {
            get => _selectedTags;
            private set => Set(ref _selectedTags, value);
        }
        private ViewModelTag _selectedTag = ViewModelTag.FirstTag;
        public ViewModelTag SelectedTag
        {
            get => _selectedTag;
            set => Set(ref _selectedTag, value);
        }
        public ViewModelMain()
        {
            Tags.Add(ViewModelTag.FirstTag);
            for (int i = 1; i < 300; i++)
            {
                var t = new ViewModelTag($"Тег #{i:000}");
                Tags.Add(t);
            }

            DropDownClosedCommand = new RelayCommand((object parameter) =>
            {
                var selectedTag = Tags.Where(t => t.IsChecked);
                SelectedTags = new ObservableCollection<ViewModelTag>(selectedTag);
            });
            SelectionChangedCommand = new RelayCommand((object parameter) =>
            {



            });

        }
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand DropDownClosedCommand { get; set; }
    }
}
