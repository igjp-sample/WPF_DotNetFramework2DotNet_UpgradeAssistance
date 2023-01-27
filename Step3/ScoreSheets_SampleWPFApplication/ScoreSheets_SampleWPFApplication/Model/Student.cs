using ScoreSheets_SampleWPFApplication.Infrastructure;
using System;

namespace ScoreSheets_SampleWPFApplication.Model
{
    internal class Student : ObservableObject
    {
        private String _id;

        public String ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }

        private String _name = "";

        public String Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        private String _nameYomi;

        public String NameYomi
        {
            get { return _nameYomi; }
            set { _nameYomi = value; OnPropertyChanged(); }
        }

        private int _japanese;

        public int Japanese
        {
            get { return _japanese; }
            set { _japanese = value; OnPropertyChanged(); }
        }

        private int _mathmatics;

        public int Mathmatics
        {
            get { return _mathmatics; }
            set { _mathmatics = value; OnPropertyChanged(); }
        }

        private int _english;

        public int English
        {
            get { return _english; }
            set { _english = value; OnPropertyChanged(); }
        }

        private int _socialStudies;

        public int SocialStudies
        {
            get { return _socialStudies; }
            set { _socialStudies = value; OnPropertyChanged(); }
        }

        private int _science;

        public int Science
        {
            get { return _science; }
            set { _science = value; OnPropertyChanged(); }
        }

        public Student()
        {
        }
    }
}
