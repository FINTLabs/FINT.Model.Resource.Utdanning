// Built from tag v3.2.0-rc-1

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FINT.Model.Resource;

using FINT.Model.Utdanning.Basisklasser;

namespace FINT.Model.Utdanning.Vurdering
{

    public class EksamensgruppeResource : Gruppe 
    {

    
        public EksamensgruppeResource()
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
     
            

        public void AddFag(Link link)
        {
            AddLink("fag", link);
        }

        public void AddSkole(Link link)
        {
            AddLink("skole", link);
        }

        public void AddElevforhold(Link link)
        {
            AddLink("elevforhold", link);
        }

        public void AddUndervisningsforhold(Link link)
        {
            AddLink("undervisningsforhold", link);
        }

        public void AddGrepreferanse(Link link)
        {
            AddLink("grepreferanse", link);
        }

        public void AddVigoreferanse(Link link)
        {
            AddLink("vigoreferanse", link);
        }

        public void AddMedlemskap(Link link)
        {
            AddLink("medlemskap", link);
        }
    }
}
