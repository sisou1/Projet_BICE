    using BICE.DAL;
using BICE.DTO;
using Moq;

namespace BICE.SRV.test
{
    public class GestionMateriel_SRV_test
    {
        [Fact]
        public void GestionMateriel_SRV_GetById()
        {
            var mock = new Mock<IDepot_DAL<Materiel_DAL>>();
            mock.Setup(d => d.GetById(It.IsAny<int>())).Returns(new Materiel_DAL(0, 10, DateTime.Now, DateTime.Now, true, "stock", 5, "denomination", true, 5, "categorie"));

            var srv = new GestionMateriel_SRV(mock.Object);

            var result = srv.GetById(1);

            Assert.NotNull(result);
            Assert.IsType<Materiel_DTO>(result);

            mock.Verify(depot => depot.GetById(It.IsAny<int>()), Times.AtLeastOnce);
        }

        
        [Fact]
        public void GestionMateriel_SRV_Delete()
        {
            var mock = new Mock<IDepot_DAL<Materiel_DAL>>();
            mock.Setup(d => d.Delete(It.IsAny<Materiel_DAL>()));

            var srv = new GestionMateriel_SRV(mock.Object);

            srv.Delete(new Materiel_DTO());

            mock.Verify(depot => depot.Delete(It.IsAny<Materiel_DAL>()), Times.AtLeastOnce);
        }
        [Fact]
        public void GestionMateriel_SRV_Insert()
        {
            var mock = new Mock<IDepot_DAL<Materiel_DAL>>();
            mock.Setup(d => d.Insert(It.IsAny<Materiel_DAL>())).Returns(new Materiel_DAL(0, 10, DateTime.Now, DateTime.Now, true, "stock", 5, "denomination", true, 5, "categorie"));

            var srv = new GestionMateriel_SRV(mock.Object);

            var result = srv.Insert(new Materiel_DTO());

            mock.Verify(depot => depot.Insert(It.IsAny<Materiel_DAL>()), Times.AtLeastOnce);
        }
        [Fact]
        public void GestionMateriel_SRV_Update()
        {
            var mock = new Mock<IDepot_DAL<Materiel_DAL>>();
            mock.Setup(d => d.Update(It.IsAny<Materiel_DAL>()));

            var srv = new GestionMateriel_SRV(mock.Object);

            var result = srv.Update(new Materiel_DTO());

            mock.Verify(depot => depot.Update(It.IsAny<Materiel_DAL>()), Times.AtLeastOnce);
        }

        
        [Fact]
        public void GestionMateriel_SRV_GetAll()
        {
            var mock = new Mock<IDepot_DAL<Materiel_DAL>>();
            mock.Setup(d => d.GetAll()).Returns(new List<Materiel_DAL>()
            {
                new Materiel_DAL(0, 10, DateTime.Now, DateTime.Now, true, "stock", 1, "denomination", true, 5, "categorie"),
                new Materiel_DAL(0, 10, DateTime.Now, DateTime.Now, true, "stock2", 5, "denomination2", true, 5, "categorie2")
            });

            var srv = new GestionMateriel_SRV(mock.Object);

            var result = srv.GetAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count() );


            mock.Verify(depot => depot.GetAll(), Times.AtLeastOnce);
        }
        
        
    }
}