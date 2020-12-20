using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WpfApplication7Mvvm.DB;
using WpfApplication7Mvvm.Model;

namespace WpfApplication7Mvvm.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        LocalDB mLocalDB = null;

        private ObservableCollection<Person> gridModelList;

        private string serach;

        public RelayCommand QueryCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }

        public RelayCommand AddCaommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public string Serach
        {
            get { return serach; }
            set { serach = value;
                RaisePropertyChanged();
            }
        }


        public ObservableCollection<Person> GridModelList
        {
            get { return gridModelList; }
            set { gridModelList = value;
                RaisePropertyChanged();
            }
        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            mLocalDB = new LocalDB();
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            QueryCommand = new RelayCommand(QueryCondition);

            ResetCommand = new RelayCommand(() => {
                Serach = string.Empty;
                Query();
            });

            AddCaommand = new RelayCommand(()=> {

            });

            DeleteCommand = new RelayCommand(() =>{

            });
        }

        public void QueryCondition()
        {
            Person p = mLocalDB.FindById(int.Parse(Serach));
            if(p==null)
            {
                return;
            }
            GridModelList = new ObservableCollection<Person>();
            GridModelList.Add(p);
        }


        public void Query()
        {
            List<Person> personList  = mLocalDB.FindAll();
            if(personList==null)
            {
                return;
            }
            GridModelList = new ObservableCollection<Person>();
            personList.ForEach(arg => {
                GridModelList.Add(arg);
            });

        }



    }
}