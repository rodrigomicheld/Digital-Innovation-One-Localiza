using System;

namespace Series
{
    public class Series : EntidadeBase
    {
        private Genre _genre { get; set; }
        private string _titlle { get; set; }
        private string _descripton { get; set; }
        private int _year { get; set; }
        private bool _excluded { get; set; }

        

        public Series (int id, Genre genre, string titlle, string descripton, int year){
            this.Id = id;
            this._genre = genre;
            this._titlle = titlle;
            this._descripton = descripton;
            this._year = _year;
            this._excluded = false;
        }

        public override string ToString()
        {
            string response = "";
            response += "Genre: " + _genre + Environment.NewLine;
            response += "Titlle: " + _titlle + Environment.NewLine;
            response += "Descripton: " + _descripton + Environment.NewLine;
            response += "Start Year: " + _year + Environment.NewLine;
            response += "Status Excluded: " + _excluded;
            return response;
        }

        public string returnTitle(){
            return _titlle;
        }
        public int returnId(){
            return Id;
        }
        public void delete(){
            this._excluded = true;
        }

        public bool returnStatusExcluted(){
            return this._excluded;
        }
        
    }
}