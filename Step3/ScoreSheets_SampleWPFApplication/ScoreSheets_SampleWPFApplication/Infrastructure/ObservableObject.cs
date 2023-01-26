using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ScoreSheets_SampleWPFApplication.Infrastructure
{
#nullable enable
    internal abstract class ObservableObject : INotifyPropertyChanged
    {
        protected ObservableObject()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] String? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
#nullable disable
}
