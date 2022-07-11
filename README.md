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
// CSV 데이터 출력
Console.WriteLine( frame );
// 실제 CSV 데이터의 행과 열 개수를 표시하기
Console.WriteLine( frame.Shape );
```
* CSV 파싱 출력 결과
```
  ID, LAST_NAME, AGE
0 1   KIM        30
1 2   CHOI       25
2 3   LEE        41
3 4   PARK       19
4 5   LIM        36

5, 3
```
