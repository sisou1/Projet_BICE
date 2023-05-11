using BICE.DAL;
using BICE.DTO;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.SRV.test
{
    public class GestionIntervention_SRV_test
    {
        [Fact]
        public void GestionIntervention_SRV_Insert()
        {
            var mock = new Mock<IDepot_DAL<Intervention_DAL>>();
            mock.Setup(d => d.Insert(It.IsAny<Intervention_DAL>())).Returns(new Intervention_DAL(5, DateTime.Now, "nom", "desc"));

            var srv = new GestionIntervention_SRV(mock.Object);

            var result = srv.Insert(new Intervention_DTO());

            mock.Verify(depot => depot.Insert(It.IsAny<Intervention_DAL>()), Times.AtLeastOnce);
        }
        [Fact]
        public void GestionIntervention_SRV_GetById()
        {
            var mock = new Mock<IDepot_DAL<Intervention_DAL>>();
            mock.Setup(d => d.GetById(It.IsAny<int>())).Returns(new Intervention_DAL(5, DateTime.Now, "nom", "desc"));

            var srv = new GestionIntervention_SRV(mock.Object);

            var result = srv.GetById(1);

            Assert.NotNull(result);
            Assert.IsType<Intervention_DTO>(result);

            //pas compris
            mock.Verify(depot => depot.GetById(It.IsAny<int>()), Times.AtLeastOnce);
        }
        [Fact]
        public void GestionIntervention_SRV_GetAll()
        {
            var mock = new Mock<IDepot_DAL<Intervention_DAL>>();
            mock.Setup(d => d.GetAll()).Returns(new List<Intervention_DAL>()
            {
                new Intervention_DAL(0, DateTime.Now, "bonjour", "bonsoir"),
                new Intervention_DAL(0, DateTime.Now, "on", "off")
            });

            var srv = new GestionIntervention_SRV(mock.Object);

            var result = srv.GetAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());


            mock.Verify(depot => depot.GetAll(), Times.AtLeastOnce);
        }
    }
}
