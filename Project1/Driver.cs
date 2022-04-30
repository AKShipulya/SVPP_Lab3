using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{

    public enum GENDER
    {
        male,
        female,
        variant
    };

    public enum COLOR_EYES
    {
        brown,
        green,
        blue,
        gray
    };

    public class Driver : INotifyPropertyChanged, IDataErrorInfo
    {
        private int number;
        private char clazz;
        private double hgt;
        private string name;
        private string address;
        private GENDER gender;
        private COLOR_EYES coloredEyes;
        private DateTime dob;
        private DateTime iss;
        private DateTime exp;
        private bool donor;
        private string uriImage;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Number
        {
            get => number;
            set
            { 
                number = value;
                OnPropertyChanged("Number");
            }
        }
        public char Clazz 
        {
            get => clazz; 
            set
            {
                clazz = value;
                OnPropertyChanged("Clazz");
            }
                
        }
        public double Hgt 
        {
            get => hgt;
            set
            {
                hgt = value;
                OnPropertyChanged("Hgt");
            }
        }
        public string Name 
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Address 
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        public GENDER Gender 
        {
            get => gender; 
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
                 
        }
        public COLOR_EYES ColoredEyes 
        {
            get => coloredEyes; 
            set
            {
                coloredEyes = value;
                OnPropertyChanged("ColoredEyes");
            }
        }
        public DateTime Dob 
        {
            get => dob;
            set
            {
                dob = value;
                OnPropertyChanged("Dob");
            }
        }
        public DateTime Iss 
        {
            get => iss;
            set
            {
                iss = value;
                OnPropertyChanged("Iss");
            }
        }
        public DateTime Exp 
        { 
            get => exp;
            set
            {
                exp = value;
                OnPropertyChanged("Exp");
            }
        }
        public bool Donor {
            get => donor;
            set
            {
                donor = value;
                OnPropertyChanged("Donor");
            }
        }
        public string UriImage 
        { 
            get => uriImage;
            set
            {
                uriImage = value;
                OnPropertyChanged("UriImage");
            }
        }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch(columnName)
                {
                    case "Clazz":
                       if(Clazz < 'A' || Clazz > 'E')
                        {
                            error = "Wrong class!";
                        }
                        break;
                    case "Exp":
                        if(Exp < DateTime.Now)
                        {
                            error = "The license is expired!";
                        }
                        break;
                    case "Dob":
                        if(Dob < new DateTime(1900, 01, 01))
                        {
                            error = "Wrong date of birthday!";
                        }
                        break;
                    case "Iss":
                        if (Iss > DateTime.Now)
                        {
                            error = "Wrong date of ISS!";
                        }
                        break;
                }
                return error;
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public override string ToString()
        {
            return $"Driver's license: №{Number} Class: {Clazz}, from {Iss.ToShortDateString()} to {Exp.ToShortDateString()}." +
                $"\n {Name}, {Gender}. DOB: {Dob.ToShortDateString()}." +
                $"\n Address: {Address}. Height: {String.Format("{0:0.00}", Hgt)}, Eyes: {ColoredEyes}." +
                $"\n Donor status: {(Donor ? "Donor" : "Not donor")}" +
                $"\n Image: {UriImage}";
        }
    }
}
