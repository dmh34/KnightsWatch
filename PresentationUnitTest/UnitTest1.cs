using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using KnightsWatch.Presentation.ViewModels;

namespace PresentationUnitTest
{
    [TestClass]
    public class MainWindowViewModelUnitTest
    {
        //    [ClassInitialize]
        //    public static void ClassIntitalize()
        //    {
        //        var windowApdaterMock = new Mock<Presentation.Interfaces.IWindowAdapter>();
        //        windowApdaterMock.Setup(adp => adp.Close());
        //        var dataAccessMock = new Mock<Presentation.Interfaces.IDataAccessService>();

        //    }

        [TestMethod]
        public void Test_Adapter_Close_Should_Pass()
        {
            var mock = new Mock<Presentation.Interfaces.IWindowAdapter>();
            mock.Setup(adp => adp.Close()).Verifiable();
            //mock.Setup(adp => adp.CreateChildWindow()).Verifiable();

            var mockDataAccess = new Mock<Presentation.Interfaces.IDataAccessService>();
            mockDataAccess.Setup(dat => dat.GetTasks()).Returns(new System.Collections.Generic.List<TaskViewModel>() { });
            
            

            var vn = new MainWindowViewModel(mock.Object,  mockDataAccess.Object);
            vn.CloseWindowCommand.Execute(null);
            mock.Verify();
        }

        [TestMethod]
        public void Test_DragDrop_Should_Pass()
        {
            var mock = new Mock<Presentation.Interfaces.IWindowAdapter>();
            mock.Setup(adp => adp.Close()).Verifiable();
            mock.Setup(adp => adp.CreateChildWindow()).Verifiable();

            var mockDataAccess = new Mock<Presentation.Interfaces.IDataAccessService>();
            mockDataAccess.Setup(dat => dat.GetTasks()).Returns(new System.Collections.Generic.List<TaskViewModel>() { });

            

            var vn = new MainWindowViewModel(mock.Object, mockDataAccess.Object);
            //vn.DragOver();
        }
        [TestMethod]
        public void Test_Null_Depencies_Should_Fail()
        {

        }
        
    }
}
