using System.ComponentModel;

namespace WindowsFormsApplication1.Models
{

    public class UserInfo
    {
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}