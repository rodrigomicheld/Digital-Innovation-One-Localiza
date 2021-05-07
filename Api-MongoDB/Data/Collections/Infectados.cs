using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api_MongoDB.Data.Collections
{
    public class Infectados
    {
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }

        public Infectados (DateTime dataNascimento, string sexo, double longitude, double latitude){
            DataNascimento = dataNascimento;
            Sexo = sexo;
            Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude); 
        }

    }
}