
using System;
using System.Text;
using System.Collections.Generic;

namespace MPhrpLib {
    public partial class DataFrame {
        private List<DataRow>   rows;
        public  DataRow         Shape;
        public DataFrame(){
            this.rows = new List<DataRow>();
            this.Shape = new DataRow();
            this.Shape.Cells.Add(null); // 행 개수가 저장 될 공간 초기화
            this.Shape.Cells.Add(null); // 열 개수가 저장 될 공간 초기화
        }
        public int GetRowCount(){
            return this.rows.Count;
        }
        public DataRow FetchRow(int idx){
            return this.rows[idx];
        }
        public DataRow Head(){
            return this.FetchRow(0);
        }
        public DataRow Tail(){
            return this.FetchRow(this.GetRowCount() - 1);
        }
        public DataFrame Head(int n){
            DataFrame frame = new DataFrame();
            for(int i = 0; i < n; i++){
                frame.AddRow(this.FetchRow(i));
            }
            return frame;
        }
        public DataFrame Tail(int n){
            DataFrame frame = new DataFrame();
            for(int i = 0; i < n; i++){
                frame.AddRow(this.FetchRow(this.GetRowCount() - 1 - i));
            }
            return frame;
        }
        public void DropRow(int idx){
            this.rows.RemoveAt(idx);
            this.UpdateShape();
        }
        public void AddRow(string[] row){
            DataRow dRow = new DataRow();
            for(int i = 0; i < row.Length; i++){
                dRow.Cells.Add(row[i]);
            }
            this.rows.Add(dRow);
            this.UpdateShape();
        }
        public void AddRow(DataRow row){
            this.rows.Add(row);
            this.UpdateShape();
        }
        public void UpdateShape(){
            // 행 개수 구하기
            this.Shape.Cells[0] = this.rows.Count + "";
            // 열 개수 구하기
            this.Shape.Cells[1] = this.rows[0].Cells.Count + "";
        }
        public DataFrame Copy(){
            DataFrame frame = new DataFrame();
            foreach(DataRow row in this.rows){
                frame.AddRow( row.Copy() );
            }
            frame.Shape = this.Shape.Copy();
            return frame;
        }
        public DataFrame Abs(){
            DataFrame absFrame = new DataFrame();
            foreach(DataRow row in this.rows){
                absFrame.AddRow(row.Abs());
            }
            return absFrame;
        }
        public override string ToString(){
            string content = "";

            for(int i = 0; i < rows.Count; i++) {
                content += rows[i];
                content += System.Environment.NewLine;
            }
            return content;
        }
        public int NDim(){
            return 2;
        }
    }
}