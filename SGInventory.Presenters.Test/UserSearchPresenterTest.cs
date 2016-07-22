using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGInventory.Views;
using Moq;
using SGInventory.Business.Model;
using SGInventory.Model;
using SGInventory.Presenters;
using System.Windows.Forms;

namespace SGInventory.Presenters.Test
{
    [TestClass]
    public class UserSearchPresenterTest
    {
       private  UserSearchPresenter _searchPresenter;
        private Mock<IUserSearchView> _searchView;
        private Mock<IUserBusinessModel> _businessModel;
        private List<User> _suppliers;
        private User _user;

        public UserSearchPresenterTest()
        {
            _searchView = new Mock<IUserSearchView>(MockBehavior.Strict);
            _businessModel = new Mock<IUserBusinessModel>(MockBehavior.Strict);
            _searchPresenter = new UserSearchPresenter(_searchView.Object, _businessModel.Object);

            _suppliers = new List<User>
            {
                new User
                {
                    Id=1,
                    UserName="UserX",
                    Name="FullName X",
                    Password="QC",
                    CreatedDate=DateTime.Now,
                    CreatedBy="user",
                    ModifiedDate=DateTime.Now,
                    ModifiedBy="user"
                },
                   new User
                {
                    Id=2,
                    UserName="UserY",                    
                    Name="FullName Y",
                    Password="Ermita Manila",
                    CreatedDate=DateTime.Now,
                    CreatedBy="user",
                    ModifiedDate=DateTime.Now,
                    ModifiedBy="user"
                }
            };

            _user = new User
            {
                Id = 2,
                UserName = "UserZ",
                Name="Fullname user",
                Password = "Tayuman, San Lazaro",
                CreatedDate = DateTime.Now,
                CreatedBy = "user",
                ModifiedDate = DateTime.Now,
                ModifiedBy = "user"
            };
        }

        [TestMethod]
        public void LoadAll_GivenAllAreSelected_Test()
        {
            
            _businessModel.Setup(b => b.SelectAll()).Returns(_suppliers);
            _searchView.Setup(s => s.LoadModel(It.IsAny<List<User>>()));

            _searchPresenter.LoadModels();

            _businessModel.VerifyAll();
            _searchView.VerifyAll();
        }

        [TestMethod]
        public void AddModel_Test()
        {
            _searchView.Setup(v => v.OpenEditForm());

            _searchPresenter.OpenEditForm();

            _searchView.VerifyAll();
        }

        [TestMethod]
        public void PopulateModelToEditForm_Test()
        {
            

            _searchView.Setup(v => v.ConvertToModel(It.IsAny<object>())).Returns(_user);
            _searchView.Setup(v => v.OpenEditForm(It.IsAny<User>()));

            _searchPresenter.PopulateModelToEditForm("colName", null);

            _searchView.VerifyAll();

        }

        [TestMethod]
        public void DeleteSelectedModels_GivenTheUserSayYes_Test()
        {
            
            _searchView.Setup(v => v.GetSelectedModels()).Returns(_suppliers);
            _searchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.Yes);
            _businessModel.Setup(b => b.Delete(It.IsAny<User>()));
            _searchView.Setup(v => v.DeletedPopUpMessage(It.IsAny<string>()));
            _businessModel.Setup(b => b.SelectAll()).Returns(new List<User>());
            _searchView.Setup(v => v.LoadModel(It.IsAny<List<User>>()));

            _searchPresenter.DeleteSelectedModels();

            _searchView.VerifyAll();
            _businessModel.Verify(b => b.Delete(It.IsAny<User>()), Times.Exactly(_suppliers.Count));


        }

        [TestMethod]
        public void DeleteSelectedModels_GivenNothingIsSelected_Test()
        {
            var _supplier = new List<User>();

            _searchView.Setup(v => v.GetSelectedModels()).Returns(_supplier);

            _searchPresenter.DeleteSelectedModels();

            _searchView.VerifyAll();



        }

        [TestMethod]
        public void DeleteSelectedModels_GivenTheUserSayNo_Test()
        {
            
            _searchView.Setup(v => v.GetSelectedModels()).Returns(_suppliers);
            _searchView.Setup(v => v.ConfirmationPopUpYesNo(It.IsAny<string>())).Returns(DialogResult.No);


            _searchPresenter.DeleteSelectedModels();

            _searchView.VerifyAll();
            _businessModel.VerifyAll();


        }
    }
}
