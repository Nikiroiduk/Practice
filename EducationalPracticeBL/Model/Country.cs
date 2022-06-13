using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EducationalPracticeBL.Model
{
    public class Country : INotifyPropertyChanged
    {
        public string Code { get; set; }
        public string Name { get; set; }

        private bool _isSelected = false;
        public bool isSelected
        {
            get => _isSelected;
            set
            {
                //if (isSelected != value)
                //{
                //    isSelected = value;
                //    NotifyPropertyChanged();
                //}
                _isSelected = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Country(string Code, string Name, bool isSelected = false)
        {
            this.Code = Code;
            this.Name = Name;
            this.isSelected = isSelected;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
