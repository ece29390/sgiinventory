using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Test.Data
{
    public class ColorTestData:TestDataBase<Color>
    {
        public ColorTestData()
        {
            _entities = new List<Color>
                                            {
                                                new Color{Code ="001",Name="Navy Blue",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"},
                                                new Color{Code ="002",Name="Khaki",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"}
                                            };

            _entity = _entities[0];
        }
    }
}
