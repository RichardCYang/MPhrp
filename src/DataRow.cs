
using System;
using System.Collections.Generic;

namespace MPhrpLib {
    public class DataRow {
        public List<string> Cells;
        public DataRow(){
            this.Cells = new List<string>(); 
        }
        public DataRow Copy(){
            DataRow row = new DataRow();
            foreach(string cell in this.Cells){
                row.Cells.Add( new string(cell.ToCharArray()) );
            }
            return row;
        }
        public int this[int key]{
            get => Int32.Parse( this.Cells[key] );
        }
        public override string ToString(){
            string content = "";
            for(int i = 0; i < this.Cells.Count; i++){
                content += this.Cells[i];
                content += ", ";
            }
            content = content.TrimEnd();
            content = content.TrimEnd(',');
            return content;
        }
        public DataRow Abs(){
            DataRow absRow = new DataRow();
            double absVal = 0.0;

            foreach(string cell in this.Cells){
                if( Double.TryParse(cell,out absVal) ){
                    absVal = absVal < 0 ? absVal * -1 : absVal;
                    absRow.Cells.Add(absVal + "");
                }else{
                    absRow.Cells.Add(cell);
                }
            }

            return absRow;
        }
        public int NDim(){
            return 1;
        }
    }
}