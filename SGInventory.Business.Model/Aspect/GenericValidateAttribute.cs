using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Aspects;
using SGInventory.Business.Model.ValdiateFactories;

namespace SGInventory.Business.Model.Aspect
{
    [Serializable]
    public class GenericValidateAttribute:OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            var arguments = args.Arguments.ToList();

            var validateFactory = new ValidateFactory(arguments[0].ToString());

            IValid valid = validateFactory.Valid;

            var response = valid.Validate(arguments);
            
            args.ReturnValue = response;

            if (!string.IsNullOrEmpty(response))
            {
                args.FlowBehavior = FlowBehavior.Return;
            }                        
        }
    }
}
