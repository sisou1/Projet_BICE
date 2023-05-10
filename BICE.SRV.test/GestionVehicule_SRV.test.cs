using BICE.DAL;
using BICE.DTO;
using Moq;

namespace BICE.SRV.test
{
    public class GestionVehicule_SRV_test
    {
        [Fact]
        public void GestionVehicule_SRV_GetById()
        {
            var mock = new Mock<IDepot_DAL<Vehicule_DAL>>();
            mock.Setup(d => d.GetById(It.IsAny<int>())).Returns(new Vehicule_DAL(5, "sdsd897sdsd", "voiture", "sd987", true));

            var srv = new GestionVehicule_SRV(mock.Object);

            var result = srv.GetById(1);

            Assert.NotNull(result);
            Assert.IsType<Vehicule_DTO>(result);

            //pas compris
            mock.Verify(depot => depot.GetById(It.IsAny<int>()), Times.AtLeastOnce);
        }


        [Fact]
        public void GestionVehicule_SRV_Delete()
        {
            var mock = new Mock<IDepot_DAL<Vehicule_DAL>>();
            mock.Setup(d => d.Delete(It.IsAny<Vehicule_DAL>()));

            var srv = new GestionVehicule_SRV(mock.Object);

            srv.Delete(new Vehicule_DTO());

            mock.Verify(depot => depot.Delete(It.IsAny<Vehicule_DAL>()), Times.AtLeastOnce);
        }
        [Fact]
        public void GestionVehicule_SRV_Insert()
        {
            var mock = new Mock<IDepot_DAL<Vehicule_DAL>>();
            mock.Setup(d => d.Insert(It.IsAny<Vehicule_DAL>())).Returns(new Vehicule_DAL(5, "sdsd897sdsd", "voiture", "sd987", true));

            var srv = new GestionVehicule_SRV(mock.Object);

            var result = srv.Insert(new Vehicule_DTO());

            mock.Verify(depot => depot.Insert(It.IsAny<Vehicule_DAL>()), Times.AtLeastOnce);
        }
        [Fact]
        public void GestionVehicule_SRV_Update()
        {
            var mock = new Mock<IDepot_DAL<Vehicule_DAL>>();
            mock.Setup(d => d.Update(It.IsAny<Vehicule_DAL>()));

            var srv = new GestionVehicule_SRV(mock.Object);

            var result = srv.Update(new Vehicule_DTO());

            mock.Verify(depot => depot.Update(It.IsAny<Vehicule_DAL>()), Times.AtLeastOnce);
        }

        /*
        [Fact]
        public void GestionVehicule_SRV_GetAll()
        {
            var mock = new Mock<IDepot_DAL<Vehicule_DAL>>();
            mock.Setup(d => d.GetAll()).Returns(new List<Vehicule_DAL>()
            {
                new Vehicule_DAL(0, 10, DateTime.Now, DateTime.Now, true, "stock", "denomination", true, 5, "categorie"),
                new Vehicule_DAL(0, 10, DateTime.Now, DateTime.Now, true, "stock2", "denomination2", true, 5, "categorie2")
            });

            var srv = new GestionVehicule_SRV(mock.Object);

            var result = srv.GetAll();

            Assert.NotNull(result);
            Assert.IsType<List<Vehicule_DAL>>(result);


            mock.Verify(depot => depot.GetAll(), Times.AtLeastOnce);
        }
        */

    }
}