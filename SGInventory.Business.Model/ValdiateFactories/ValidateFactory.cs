using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Business.Model.ValdiateFactories
{
    public class ValidateFactory
    {
        private string _modelName;

        public ValidateFactory(string modelName)
        {
            _modelName = modelName;
        }

        public IValid Valid
        {
            get
            {
                IValid retValue = null;

                switch (_modelName)
                {
                    case ValidateConstant.PRODUCT:
                        retValue = new ProductValidate();
                        break;
                    default:
                        throw new InvalidOperationException("Model Name has not been specified");
                }
                return retValue;
            }
        }
    }
}
