Matrix-Processor for CSharp (MPhrp)
===================================
C# 기반 플랫폼에서 행렬(DataFrame) 및 리스트(DataRow) 클래스 구현 및 관련 수학 메서드 기능을 구현하는 것을

목표로 진행하고 있는 프로젝트 입니다. 대표적인 구현 기능으로 CSV 파일에서 데이터를 파싱할 수 있는 CSVParser

클래스 등이 있습니다.

## 주요 라이브러리
* 클라이언트
    * .NET Frameworks
    * .NET Frameworks IO Library (System.IO)
    * .NET Frameworks Collections (List)

## 라이브러리 사용 예제
* CSV 파싱
```C#
// CSV 파싱 객체 생성
CSVParser csvParser = new CSVParser();
// CSV 파일에서 헤더를 제외한 실 데이터 행렬을 가져오기
DataFrame frame     = csvParser.ParseFromFile("test.csv");
// CSV 파일에서 헤더에 해당하는 행 리스트를 가져오기
DataRow   header    = csvParser.HeaderRow;
// 헤더를 제외한 실제 CSV 데이터의 행과 열 개수를 표시하기
Console.WriteLine( frame.Shape );
```