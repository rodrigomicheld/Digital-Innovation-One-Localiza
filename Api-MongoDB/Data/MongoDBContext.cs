using System;
using Api_MongoDB.Data.Collections;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Api_MongoDB.Data
{
    public class MongoDBContext
    {
        public IMongoDatabase DB { get;}

        public MongoDBContext(IConfiguration configuration){
            try{
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionStrings"]));
                var client = new MongoClient(settings);
                DB = client.GetDatabase(configuration["NomeBanco"]);
                MapClasses();
            
            }catch(Exception e){
                throw new MongoClientException("Não foi possível conectar no banco Mmongo", e);

            }
        }

        private  void MapClasses(){
            var conventionPack = new ConventionPack{new CamelCaseElementNameConvention()};
            ConventionRegistry.Register("camelCase",conventionPack, t => true);

            if (!BsonClassMap.IsClassMapRegistered(typeof(Infectados))){
                BsonClassMap.RegisterClassMap<Infectados>(i =>
                {
                    i.AutoMap();
                    i.SetIgnoreExtraElements(true); //ignora a inserção de uma nova propriedade no banco
                });
             
            }  

        }
    }

}