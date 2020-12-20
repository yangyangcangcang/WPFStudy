using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WpfApplication6.DB;
using WpfApplication6.Models;

namespace WpfApplication6.ViewModel
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

        private LoacalDb mLocalDb;

        private string serarch;

        public string Serarch
        {
            get { return serarch; }
            set { serarch = value;
                RaisePropertyChanged();
            }
        }


        private ObservableCollection<Person> gridModelList;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            mLocalDb = new LoacalDb();

            QueryCommand = new RelayCommand(Query);

            ResetCommand = new RelayCommand(()=> {
                Serarch = string.Empty;
                this.Query();
            });
            //Query();
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        public ObservableCollection<Person> GridModelList
        {
            get { return gridModelList; }
            set { gridModelList = value;
                RaisePropertyChanged();
            }
        }

        public void Query()
        {
            List<Person> list = mLocalDb.GetPersonByName(Serarch);//mLocalDb.GetAllPerson();
            GridModelList = new ObservableCollection<Person>();
            if (list==null)
            {
                return;
            }
            list.ForEach(arg =>
            {
                GridModelList.Add(arg);
            });
        }

        public RelayCommand QueryCommand { get; set; }

        public RelayCommand ResetCommand { get; set; }

        public RelayCommand<int> EditCommand { get; set; }
        public RelayCommand<int> DeleteCommand { get; set; }
    }
}