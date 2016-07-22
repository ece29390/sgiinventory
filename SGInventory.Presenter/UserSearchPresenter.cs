using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGInventory.Model;
using SGInventory.Business.Model;

namespace SGInventory.Presenters
{
    public class UserSearchPresenter:SearchPresenterBase<User, IUserBusinessModel, int>
    {
       

        public UserSearchPresenter(Views.IUserSearchView iUserSearchView
            , Business.Model.IUserBusinessModel iUserBusinessModel):base(iUserSearchView,iUserBusinessModel)
        {
            
           
        }
    }
}
