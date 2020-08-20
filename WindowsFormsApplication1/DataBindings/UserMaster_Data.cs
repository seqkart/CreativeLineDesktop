
using DevExpress.XtraEditors;
using SeqKartLibrary;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Image = System.Drawing.Image;

namespace DataBindings
{
    public class UserMaster_Data : INotifyPropertyChanged
    {
        public UserMaster_Data()
        {

        }

        string user_name;
        public string UserName
        {
            get { return user_name; }
            set
            {
                if (user_name != value)
                {
                    user_name = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        string login_as;
        public string Login_As
        {
            get { return login_as; }
            set
            {
                if (login_as != value)
                {
                    login_as = value;
                    OnPropertyChanged("Login_As");
                }
            }
        }

        string user_active;
        public string UserActive
        {
            get { return user_active; }
            set
            {
                if (user_active != value)
                {
                    user_active = value;
                    OnPropertyChanged("UserActive");
                }
            }
        }


        Image edit;
        public Image Edit_Link
        {
            get { return edit; }
            set
            {
                if (edit != value)
                {

                    edit = value;
                    OnPropertyChanged("Edit_Link");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Binding_DataHelper
    {
        public static BindingList<UserMaster_Data> GetData(DataSet dsMaster)
        {
            BindingList<UserMaster_Data> records = new BindingList<UserMaster_Data>();
            foreach (DataRow dr in dsMaster.Tables[0].Rows)
            {
                HyperLinkEdit hyperLink = new HyperLinkEdit
                {
                    Text = "Edit"
                };

                records.Add(new UserMaster_Data()
                {
                    UserName = dr[SQL_COLUMNS.USER_MASTER._UserName] + string.Empty,
                    Login_As = dr[SQL_COLUMNS.USER_MASTER._LoginAs] + string.Empty,
                    UserActive = dr[SQL_COLUMNS.USER_MASTER._UserActive] + string.Empty,
                    Edit_Link = SystemIcons.Information.ToBitmap()


                });
            }
            return records;
        }
    }
}

