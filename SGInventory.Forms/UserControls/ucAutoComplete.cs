using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Model;
using System.Globalization;

namespace SGInventory.UserControls
{
    public partial class ucAutoComplete : UserControl
    {
        public event EventHandler<EventArgs> AfterSelecting;
        public event EventHandler<EventArgs> InsideTextChange;
        public event EventHandler<KeyEventArgs> AutoCompleteKeyup;
        
        private Dictionary<string, string> _codeByName;
        Dictionary<string, int> _codeById;
        
        public ucAutoComplete()
        {
            InitializeComponent();
            AutoCompleteTextbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteTextbox.Text = string.Empty;
            _codeByName = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            _codeById = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
        }

        public string AutoCompleteValue { 
            get { return AutoCompleteTextbox.Text.Trim(); }
            set { AutoCompleteTextbox.Text = value; }
        }

        public string AutoCompleteCode
        {
            get
            {
                if (string.IsNullOrEmpty(AutoCompleteValue))
                {
                    return null;
                }
                string code = "";
                _codeByName.TryGetValue(AutoCompleteValue, out code);

                return string.IsNullOrEmpty(code) ? null : code;
            }
        }

        public int? AutoCompleteId
        {
            get
            {
                if (string.IsNullOrEmpty(AutoCompleteValue))
                {
                    return null;
                }

                var id = 0;
                _codeById.TryGetValue(AutoCompleteValue, out id);

                if (id == 0)
                {
                    return null;
                }
                return id;
            }
        }
        
        public void LoadAutoCompleteNameCodeSource<T>(List<T> dataSource
            ) where T: IName,ICode
        {
            
            var autoCompleteStringCollection=new AutoCompleteStringCollection();
            dataSource.ForEach(m => 
            {
                autoCompleteStringCollection.Add(m.Name);
                _codeByName[m.Name] = m.Code;
            });
            AutoCompleteTextbox.AutoCompleteCustomSource = autoCompleteStringCollection;
        }

        
        public void LoadAutoCompleteIdNameSource<T>(List<T> dataSource
          ) where T : IIdentityIntEntity, IName
        {
           
            var autoCompleteStringCollection = new AutoCompleteStringCollection();
            dataSource.ForEach(m =>
            {
                autoCompleteStringCollection.Add(m.Name);
                _codeById[m.Name] = m.Id;
            });
            AutoCompleteTextbox.AutoCompleteCustomSource = autoCompleteStringCollection;
        }

        public void LoadAutoComplete(AutoCompleteStringCollection collection)
        {
            AutoCompleteTextbox.AutoCompleteCustomSource = collection;
        }

        public void SetTheWitdhOfTheTextbox(int width)
        {
            AutoCompleteTextbox.Width = width;
        }

        private void ucAutoComplete_Leave(object sender, EventArgs e)
        {
            if (AfterSelecting != null)
            {
                AfterSelecting(sender, e);
            }
        }

        private void AutoCompleteTextbox_TextChanged(object sender, EventArgs e)
        {
            if (InsideTextChange != null)
            {
                InsideTextChange(sender, e);
            }
        }

        private void ucAutoComplete_KeyUp(object sender, KeyEventArgs e)
        {
            if (AutoCompleteKeyup != null)
            {
                AutoCompleteKeyup(sender, e);
            }
        }       
    }
}
