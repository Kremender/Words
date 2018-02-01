using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace Words
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI());
        }

    }


    public class CustomComboBox : ComboBox
    {
        public event CancelEventHandler BeforeUpdate;

        public CustomComboBox()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public bool mBusy;
        public int mPrevIndex = -1;

        protected virtual void OnBeforeUpdate(CancelEventArgs cea)
        {
            if (BeforeUpdate != null) BeforeUpdate(this, cea);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (mBusy) return;
            mBusy = true;
            try
            {
                CancelEventArgs cea = new CancelEventArgs();
                OnBeforeUpdate(cea);
                if (cea.Cancel)
                {
                    // Restore previous index
                    this.SelectedIndex = mPrevIndex;
                    return;
                }
                mPrevIndex = this.SelectedIndex;
                base.OnSelectedIndexChanged(e);
            }
            finally
            {
                mBusy = false;
            }
        }
    }

    public class StringOrderValueTag
    {
        public StringOrderValueTag (int i, string s, bool t)
        {
            _order = i;
            _word = s;
            _tag = t;
        }

        public int Order { get { return _order; } set { _order = value; } }
        public string Word { get { return _word; } set { _word = value; } }
        public bool Tag { get { return _tag; } set { _tag = value; } }

        int _order;
        string _word;
        bool _tag; 
        
    }


    public class StringValue
    {
        public StringValue(string s)
        {
            _value = s;
        }
        public string Value { get { return _value; } set { _value = value; } }
        string _value;
    }

}
