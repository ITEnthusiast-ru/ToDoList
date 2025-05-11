using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ToDoList.Models
{
    class ToDoModel:INotifyPropertyChanged
    {
       
		private bool isDone;
        public bool IsDone
        {
            get { return isDone; }
            set { 
                    if (isDone == value)
                    return;
                    isDone = value; 
                    OnPropertyCanged("IsDone");
                }
        }

        private string _text;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Text
		{
			get { return _text; }
			set { if (_text == value)
                    return ;
                _text = value; 
            OnPropertyCanged("Text");
            }
		}
        public DateTime CreationTime { get; set; } = DateTime.Now;

        protected virtual void OnPropertyCanged( string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }

    }
}
