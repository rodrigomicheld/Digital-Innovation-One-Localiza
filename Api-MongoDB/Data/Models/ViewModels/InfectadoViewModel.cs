using System;

namespace Api_MongoDB.Data.Models.ViewModels
{
    public class InfectadoViewModel //retorno da api
    {
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Longitude { get; set;}
        public double Latitude { get; set;}


    }
}