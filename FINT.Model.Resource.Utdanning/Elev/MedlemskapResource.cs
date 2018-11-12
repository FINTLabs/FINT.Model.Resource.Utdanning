// Built from tag v3.1.0

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FINT.Model.Resource;

using FINT.Model.Felles.Kompleksedatatyper;

namespace FINT.Model.Utdanning.Elev
{

    public class MedlemskapResource 
    {

    
        public Identifikator SystemId { get; set; }
        
        public MedlemskapResource()
        {
            Links = new Dictionary<string, List<Link>>();
        }

        [JsonProperty(PropertyName = "_links")]
        public Dictionary<string, List<Link>> Links { get; private set; }

        protected void AddLink(string key, Link link)
        {
            if (!Links.ContainsKey(key))
            {
                Links.Add(key, new List<Link>());
            }
            Links[key].Add(link);
        }
     
            

        public void AddMedlem(Link link)
        {
            AddLink("medlem", link);
        }

        public void AddFortlopendeVurdering(Link link)
        {
            AddLink("fortlopendeVurdering", link);
        }

        public void AddGruppe(Link link)
        {
            AddLink("gruppe", link);
        }

        public void AddEndeligVurdering(Link link)
        {
            AddLink("endeligVurdering", link);
        }

        public void AddFravar(Link link)
        {
            AddLink("fravar", link);
        }
    }
}
