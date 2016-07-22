using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Linq.Expressions;
namespace SGInventory.Helpers
{
    public class FormsHelper
    {
        public const int NAME_MAXLENGTH = 25,
                         DESC_MAXLENGTH=50,
                         CODE_MAXLENGTH=10;
        public const int ADDRESS_MAXLENGTH=100,
                         WASHINGNAME_MAXLENGTH=100;
        public const string CONFIRMATION_DELETE_MODEL="Are you sure you want to delete the selected Items?";
        public const string SUCCESSFULL_DELETED_ITEMS="The selected item has been successfully deleted";
        public const string CREATED_SUCCESSFULL = "A new {0} has been added",
                            UPDATED_SUCCCESSFULL = "{0} has been updated";
        public static string WashingNameValidationError
        {
            get { return string.Format("Name has exceeded the maximum limit of {0} characters", WASHINGNAME_MAXLENGTH); }
        }
        public static  string NameValidationError 
        {
            get{return string.Format("Name has exceeded the maximum limit of {0} characters", NAME_MAXLENGTH);}
        }
                       
        public static string DescriptionValidationError 
        {
            get { return string.Format("Description has exceeded the maximum limit of {0} characters", DESC_MAXLENGTH); }
        }

        public static string ValidationError(string fieldName,int maxLength)
        {
            return string.Format("{0} has exceeded the maximum limit of {0} characters", fieldName, maxLength); 
        }

        public static string AddressValidationError
        {
            get { return string.Format("Address has exceeded the maximum limit of {0} characters", ADDRESS_MAXLENGTH); }
        }
        
        public static List<T> GetSelectedModel<T>(string columnName,DataGridView dataGridView) where T:class,new()
        {
            List<T> model = new List<T>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if ((bool)row.Cells[columnName].FormattedValue)
                {
                    model.Add((T)row.DataBoundItem);
                }
                
            }

            return model;
        }

        public static void ApplyEditViewSettings(Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Size = new System.Drawing.Size(437, 202);            
        }

        public static void ApplySearchViewSetting(Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Size = new System.Drawing.Size(790, 426);   
        }
        
        public static string CodeValidationError
        {
             get { return string.Format("Code has exceeded the maximum limit of {0} characters", CODE_MAXLENGTH); }
        }

        public static void CloseAllOpenFormsWithName(params string[] formNames)
        {            
            var openForms = new List<Form>();
           
            var formCollection = Application.OpenForms;

            foreach (Form form in formCollection)
            {
                foreach (var formName in formNames)
                {
                    if (form.Name == formName)
                    {
                        openForms.Add(form);                            
                        break;
                    }
                }
            }

            foreach(Form form in openForms)
            {
                form.Close();
            }
                                            
        }
    }
}
