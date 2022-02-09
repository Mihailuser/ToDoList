using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using WMPLib;



namespace listofwork.Models
{
    class ToDoModel : INotifyPropertyChanged
    {

        private string _text;
        private bool _isDone;
        private DateTime cd = DateTime.Now;
        public DateTime CreationDate
        {
            get { return cd; }
            set { cd = value; }
        }
        private DateTime wd;

        public bool IsDone
        {
            get { return _isDone; }
            set
            {
                if (_isDone == value)
                    return;
                _isDone = value;
                OnProperetyChangeed("IsDONE");
            }
        }

        public DateTime WorkDate
        {
            get { return wd; }
            set
            {
                Check();
                wd = value;
            }
        }
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text == value)
                    return;
                _text = value;
                OnProperetyChangeed("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnProperetyChangeed(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }
        public void Check()
        {
            if (_isDone == false)
            {
                if (DateTime.Now > wd)
                {
                    MessageBox.Show("Выполни задание!");
                }
            }
        }
    }
}
