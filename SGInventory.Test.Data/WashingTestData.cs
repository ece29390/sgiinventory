using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;

namespace SGInventory.Test.Data
{
    public class WashingTestData:TestDataBase<Washing>
    {
        public WashingTestData()
        {
            _entities=  new List<Washing>
                                            {
                                                new Washing{Code ="6",Name="ORDINARY WASH / RAW WASH / RINSE WASH",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"},
                                                new Washing{Code ="7",Name="STONE WASH",CreatedBy="sang",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,ModifiedBy="sang"}
                                            };

            _entity=_entities[0];
        }
    }
}
