using ScoreSheets_SampleWPFApplication.DataService;
using ScoreSheets_SampleWPFApplication.Infrastructure;
using ScoreSheets_SampleWPFApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreSheets_SampleWPFApplication
{
    internal class MainWindowViewModel : ObservableObject
    {
        private List<List<Student>> _allStudents;

        private List<Student> _selectedStudents;

        public List<Student> SelectedStudents
        {
            get { return _selectedStudents; }
            set { _selectedStudents = value; OnPropertyChanged(); }
        }

        private List<SubjectAndFrequencyData> _selectedFrequency;

        public List<SubjectAndFrequencyData> SelectedFrequency
        {
            get { return _selectedFrequency; }
            set { _selectedFrequency = value; OnPropertyChanged(); }
        }


        private List<Grade> _grades;

        public List<Grade> Grades
        {
            get { return _grades; }
            set { _grades = value; OnPropertyChanged(); }
        }

        private List<List<SubjectAndFrequencyData>> _allFrequencies;


        private object[] _treeDataSelectedItems;

        public object[] TreeDataSelectedItems
        {
            get { return _treeDataSelectedItems; }
            set
            {
                _treeDataSelectedItems = value;
                if (_treeDataSelectedItems != null && _treeDataSelectedItems.Length > 0)
                {
                    var selectedGrade = (Grade)_treeDataSelectedItems[0];
                    SelectedStudents = _allStudents[selectedGrade.IndexInListData];
                    SelectedFrequency = _allFrequencies[selectedGrade.IndexInListData];
                }
                OnPropertyChanged("IsSelected");
                OnPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get
            {
                return (_treeDataSelectedItems != null && _treeDataSelectedItems.Length > 0) ? true : false;
            }
        }


        public MainWindowViewModel()
        {
            (_grades, _allStudents, _allFrequencies) = DataSourceWrapper.GetAllStudentsData();
            _selectedStudents = new List<Student>();
            _selectedFrequency = new List<SubjectAndFrequencyData>();
        }
    }
}
