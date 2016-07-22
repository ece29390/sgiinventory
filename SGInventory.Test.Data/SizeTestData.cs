using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Test.Data
{
    public class SizeTestData:TestDataBase<Size>
    {
        public SizeTestData()
        {
            _entity = new Size { Name = "S", Code = "S3", CreatedBy = "sgisize", CreatedDate = DateTime.Now };
            _entities = new List<Size>
                    {
                        _entity,
                        new Size{Code ="S4",Name="S",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"}
                    };
        }
    }
}
