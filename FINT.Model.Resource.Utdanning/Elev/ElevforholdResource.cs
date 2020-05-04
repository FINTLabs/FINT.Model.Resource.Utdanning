// Built from tag v3.5.0-rc-2

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FINT.Model.Resource;

using FINT.Model.Felles.Kompleksedatatyper;
using FINT.Model.Utdanning.Basisklasser;

namespace FINT.Model.Utdanning.Elev
{

    public class ElevforholdResource : Utdanningsforhold 
    {

    
        public Periode Gyldighetsperiode { get; set; }
        public bool? Hovedskole { get; set; }
        
        public ElevforholdResource()
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
     
            

        public void AddElev(Link link)
        {
            AddLink("elev", link);
        }

        public void AddKategori(Link link)
        {
            AddLink("kategori", link);
        }

        public void AddSkole(Link link)
        {
            AddLink("skole", link);
        }

        public void AddBasisgruppe(Link link)
        {
            AddLink("basisgruppe", link);
        }

        public void AddBasisgruppemedlemskap(Link link)
        {
            AddLink("basisgruppemedlemskap", link);
        }

        public void AddUndervisningsgruppemedlemskap(Link link)
        {
            AddLink("undervisningsgruppemedlemskap", link);
        }

        public void AddVurdering(Link link)
        {
            AddLink("vurdering", link);
        }

        public void AddKontaktlarergruppe(Link link)
        {
            AddLink("kontaktlarergruppe", link);
        }

        public void AddEksamensgruppemedlemskap(Link link)
        {
            AddLink("eksamensgruppemedlemskap", link);
        }

        public void AddKontaktlarergruppemedlemskap(Link link)
        {
            AddLink("kontaktlarergruppemedlemskap", link);
        }

        public void AddProgramomrade(Link link)
        {
            AddLink("programomrade", link);
        }

        public void AddFravar(Link link)
        {
            AddLink("fravar", link);
        }

        public void AddProgramomrademedlemskap(Link link)
        {
            AddLink("programomrademedlemskap", link);
        }

        public void AddEksamensgruppe(Link link)
        {
            AddLink("eksamensgruppe", link);
        }

        public void AddUndervisningsgruppe(Link link)
        {
            AddLink("undervisningsgruppe", link);
        }

        public void AddMedlemskap(Link link)
        {
            AddLink("medlemskap", link);
        }
    }
}
