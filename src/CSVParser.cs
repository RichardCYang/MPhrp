
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace MPhrpLib {
    public partial class CSVParser {
        public int HeaderIndex = 0;
        private string PreprocessEmpty(string content){
            return content.Replace(",,",",null,").Replace("," + System.Environment.NewLine, ",null" + System.Environment.NewLine).Replace(System.Environment.NewLine + ",",System.Environment.NewLine + "null,");
        }

        public DataFrame ParseFromFile(string path){
            DataFrame frame = null;
            try{
                string data = File.ReadAllText(path);
                frame = this.ParseFromString( data );
            }catch(Exception e){
                Console.WriteLine(e);
            }
            return frame;
        }

        public DataFrame ParseFromString(string content){
            DataFrame frame = new DataFrame();
            content = this.PreprocessEmpty(content);
            try{
                // 줄 단위로 읽어오기 (헤더 파싱)
                string[] lines      = content.Split(new string[]{System.Environment.NewLine},StringSplitOptions.None);
                string[] tokens     = null;

                foreach(string line in lines){
                    if( line.Length < 1 ){    
                        break;
                    }

                    tokens = line.Split(',');
                    frame.AddRow(tokens);
                }
            }catch(Exception e){
                Console.WriteLine(e);
            }
            
            frame.Columns = frame.FetchRow(this.HeaderIndex).Copy();

            for(int i = 0; i <= this.HeaderIndex; i++){
                frame.DropRow(i);
            }
            return frame;
        }
    }
}