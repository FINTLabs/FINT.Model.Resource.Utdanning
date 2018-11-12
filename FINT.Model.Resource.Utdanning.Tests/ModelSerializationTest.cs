using System;
using System.Collections.Generic;
using FINT.Model.Felles;
using FINT.Model.Felles.Kompleksedatatyper;
using FINT.Model.Utdanning.Elev;
using Newtonsoft.Json;
using Xunit;

namespace FINT.Model.Resource.Utdanning.Tests
{
    public class ModelSerializationTest
    {
        [Fact(DisplayName = "Serialize Elev without Links")]
        public void Serialize_Elev_without_Links()
        {
            var elev = new Elev
            {
                SystemId = new Identifikator {Identifikatorverdi = "ABC123"},
                Kontaktinformasjon = new Kontaktinformasjon {
                    Mobiltelefonnummer = "98765432",
                    Epostadresse = "xxx@example.org"
                },
                Elevnummer = new Identifikator { Identifikatorverdi = "12345" }
            };

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new LowercaseContractResolver()
            };
            var json = JsonConvert.SerializeObject(elev, settings);
            Console.WriteLine(json);

            var deserializeObject = JsonConvert.DeserializeObject<Elev>(json);
            Assert.NotNull(deserializeObject);
            Assert.Equal("98765432", deserializeObject.Kontaktinformasjon.Mobiltelefonnummer);
        }

        [Fact(DisplayName = "Serialize ElevResource with links")]
        public void Serialize_ElevResource_with_links()
        {

            var elev = new ElevResource
            {
                SystemId = new Identifikator {Identifikatorverdi = "ABC123"},
                Kontaktinformasjon = new Kontaktinformasjon
                {
                    Mobiltelefonnummer = "98765432",
                    Epostadresse = "xxx@example.org"
                },
                Elevnummer = new Identifikator { Identifikatorverdi = "12345" }
            };

            elev.AddPerson(Link.with(typeof(Person), "fodselsnummer", "12345678901"));
            elev.AddElevforhold(Link.with(typeof(Elevforhold), "systemid", "CDEF123"));

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new LowercaseContractResolver()
            };
            var json = JsonConvert.SerializeObject(elev, settings);

            Console.WriteLine(json);

            var deserializeObject = JsonConvert.DeserializeObject<ElevResource>(json);
            Assert.NotNull(deserializeObject);
            Assert.Equal("98765432", deserializeObject.Kontaktinformasjon.Mobiltelefonnummer);
            Assert.True(deserializeObject.Links.ContainsKey("person"));
        }

    }
}