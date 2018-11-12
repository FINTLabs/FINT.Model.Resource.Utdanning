#pragma warning disable xUnit2002

using System.IO;
using FINT.Model.Utdanning.Elev;
using Newtonsoft.Json;
using Xunit;

namespace FINT.Model.Resource.Utdanning.Tests
{
    public class ModelDeserializationTest
    {
        [Fact(DisplayName = "Read Elev from elev.json")]
        public void Read_Elev_from_elev_json()
        {
            var elev = JsonConvert.DeserializeObject<Elev>(File.ReadAllText(@"./TestData/elev.json"));
            Assert.NotNull(elev);
            Assert.NotNull(elev.Elevnummer);
            Assert.Equal("500001", elev.Elevnummer.Identifikatorverdi);
            Assert.Equal("Yougung", elev.Brukernavn.Identifikatorverdi);
            Assert.NotNull(elev.Brukernavn.Gyldighetsperiode.Start);
        }

        [Fact(DisplayName = "Read ElevResource from elev.json")]
        public void Read_ElevResource_from_elev_json()
        {
            var elev =
                JsonConvert.DeserializeObject<ElevResource>(File.ReadAllText(@"./TestData/elev.json"));

            Assert.NotNull(elev);
            Assert.NotNull(elev.Elevnummer);
            Assert.Equal("500001", elev.Elevnummer.Identifikatorverdi);
            Assert.Equal("Yougung", elev.Brukernavn.Identifikatorverdi);
            Assert.NotNull(elev.Brukernavn.Gyldighetsperiode.Start);
            Assert.NotNull(elev.Links);
            Assert.True(elev.Links.ContainsKey("person"));
            Assert.True(elev.Links.ContainsKey("elevforhold"));
        }

        [Fact(DisplayName = "Read Basisgruppe from basisgruppe.json")]
        public void Read_Basisgruppe_from_basisgruppe_json()
        {
            var basisgruppe =
                JsonConvert.DeserializeObject<Basisgruppe>(File.ReadAllText(@"./TestData/basisgruppe.json"));

            Assert.NotNull(basisgruppe);
            Assert.Equal("ABC123", basisgruppe.Navn);
        }

        [Fact(DisplayName = "Read Basisgruppe from basisgrupperesource.json")]
        public void Read_Basisgruppe_from_basisgrupperesource_json()
        {
            var basisgruppe =
                JsonConvert.DeserializeObject<Basisgruppe>(File.ReadAllText(@"./TestData/basisgrupperesource.json"));

            Assert.NotNull(basisgruppe);
            Assert.Equal("ABC123", basisgruppe.Navn);
        }

        [Fact(DisplayName = "Read BasisgruppeResource from basisgruppe.json")]
        public void Read_BasisgruppeResource_from_basisgruppe_json()
        {
            var basisgruppe =
                JsonConvert.DeserializeObject<BasisgruppeResource>(File.ReadAllText(@"./TestData/basisgruppe.json"));

            Assert.NotNull(basisgruppe);
            Assert.Equal("ABC123", basisgruppe.Navn);
            Assert.NotNull(basisgruppe.Links);
            Assert.Empty(basisgruppe.Links);
        }

        [Fact(DisplayName = "Read BasisgruppeResource from basisgrupperesource.json")]
        public void Read_BasisgruppeResource_from_basisgrupperesource_json()
        {
            var basisgruppe =
                JsonConvert.DeserializeObject<BasisgruppeResource>(File.ReadAllText(@"./TestData/basisgrupperesource.json"));

            Assert.NotNull(basisgruppe);
            Assert.Equal("ABC123", basisgruppe.Navn);
            Assert.NotNull(basisgruppe.Links);
            Assert.True(basisgruppe.Links.ContainsKey("medlemskap"));
        }

    }
}
#pragma warning restore xUnit2002