using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Enums;
using System.Threading;
using SGInventory.Model;
using System.Linq.Expressions;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace SGInventory.Helpers
{
    public class SgiHelper:ISgiHelper
    {
        public const string PRODUCT_SEARCH_STOCKNUMBER = "StockNumber",
                            PRODUCT_SEARCH_CATEGORYNAME = "CategoryName",
                            SEARCH_ALL = "All",
                            ADJUSTMENT_PREFIX ="Adj";

        public IDataHelper DataHelper
        {
            get;
            private set;
        }

        public SgiHelper(IDataHelper dataHelper)
        {
            DataHelper = dataHelper;
        }

        public static string GetRoleName(int roleTypeValue)
        {
            var roleName = string.Empty;
            switch (roleTypeValue)
            {
                case (int)RoleType.Administrator:
                    roleName = Enum.GetName(typeof(RoleType), RoleType.Administrator);
                    break;
                default:
                    roleName = Enum.GetName(typeof(RoleType), RoleType.OrdinaryUser);
                    break;
            }
            return roleName;
        }

        public static string GetIdentityUserName()
        {
            return Thread.CurrentPrincipal.Identity.Name;
        }

        public static string GetBarcode(string month,string year,string stockNumber,string color,string washing,string size)
        {
          return  string.Format("{0}{1}{2}{3}{4}{5}", month
                                                    , year
                                                    , stockNumber
                                                    , color
                                                    , washing
                                                    , size);
        }

        public static T SelectModelByNameInTheCollection<T>(List<T> list, string name) where T : class,Model.ICode, IName, new()
        {
            var selectedList = list.Where<T>(m => m.Name.Equals(name,StringComparison.InvariantCultureIgnoreCase)).ToList<T>();
            if (selectedList.Count == 0)
            {
                return null;
            }

            return selectedList[0];
        }

        public static string GetCorrespondingMonthByDate(DateTime dateTime)
        {
            var retValue = string.Empty;

            retValue = Enum.GetName(typeof(Months), dateTime.Month);
           
            return retValue;
        }

        public static string GetCorrespondingYearByDate(DateTime dt)
        {
            var retValue = string.Empty;

            var baseLineYear = 2000;
            var totalAlphabetCount = 26;
        
            var shouldContiune=true;
            var difference = 0;
            do
            {
                difference = dt.Year - baseLineYear;

                if (totalAlphabetCount >= difference)
                {
                    shouldContiune = false;
                }
                else
                {
                    baseLineYear += totalAlphabetCount;
                }

            } while (shouldContiune);

            retValue = Enum.GetName(typeof(Years), difference);

            return retValue;
        }

        public static int GetHashCodeOfColorAndSize(string colorCode,string sizeCode)
        {
            return string.Concat(colorCode, sizeCode).GetHashCode();
        }

        public static string GetProductDetailCode(string stockNumber,string colorCode,string washingCode,string sizeCode)
        {
            return string.Format("{0}{1}{2}{3}", stockNumber.Replace("-", "").Trim(), colorCode, washingCode, sizeCode);            
        }

        public static List<E> ConvertEnumToList<E>(
            Func<Array> ConvertEnumToArray,
            Func<object, E> ConvertEnumObjectToE)
        {
            var listOfStatusArr = ConvertEnumToArray();
            var lisOfStatus = new List<E>();
            for (int i = 0; i < listOfStatusArr.Length; i++)
            {
                lisOfStatus.Add(ConvertEnumObjectToE(listOfStatusArr.GetValue(i)));
            }
            return lisOfStatus;
        }

        public static void LoadToFileSystemStorage(string folderName,string originalDestination, string newDestination)
        {
            var mainDriveRoot = GetRootDirectory();
            var directoryStorageRoot = Path.Combine(mainDriveRoot, folderName);

            var directoryInfo = new DirectoryInfo(directoryStorageRoot);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            var destinationStorageFile = Path.Combine(mainDriveRoot, newDestination); 

            var fileInfo = new FileInfo(originalDestination);

            fileInfo.CopyTo(destinationStorageFile);

           
        }

        public static void LoadFromFileSystemStorage(PictureBox picBox, string uploadedPicDestination)
        {            
           
            var fileInfo = new FileInfo(uploadedPicDestination);

            if (fileInfo.Exists)
            {
                using (var stream = fileInfo.OpenRead())
                {
                    picBox.Image = Image.FromStream(stream);
                    stream.Close();
                                 
                }
            }                  
        }

        public static string GetNewDestination(string imageFolderName, string sourceFileName)
        {
            var folder = imageFolderName;
            var fileName = Path.GetFileName(sourceFileName);
            var newDestination = Path.Combine(GetRootDirectory(), folder, fileName);
            return newDestination;
        }

        public static string GetRootDirectory()
        {            
            var folderPathOfSystem = Environment.GetFolderPath(Environment.SpecialFolder.System);
            var retValue = Path.GetPathRoot(folderPathOfSystem);
            return retValue;
        }
        public static string GenerateInitialAdjustmentNumber(DateTime adjustmentDate)
        {
            var retValue = $"{adjustmentDate.ToString("MMddyyyy")}01";
            return retValue;
        }
       
        public static string IncrementAdjustmentNumber(DateTime deliveryDate
            , DateTime adjustmentDate
            , string adjustmentNumber)
        {
            var retValue = string.Empty;
            var pattern = @"\d+";
            if (deliveryDate.Date == adjustmentDate.Date)
            {
                var numericalPart = Regex.Match(adjustmentNumber, pattern).Value;
                var numeric = int.Parse(numericalPart);
                numeric += 1;
                retValue = numeric.ToString();
            }
            else
            {
                retValue = GenerateInitialAdjustmentNumber(adjustmentDate);
            }
            return retValue;
        }
    }
}
