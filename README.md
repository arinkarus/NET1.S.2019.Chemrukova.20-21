## Читать

- [C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015.](http://shop.oreilly.com/product/0636920040323.do)
   - *Chapter 15.* Streams and I/O [Code Listings](http://www.albahari.com/nutshell/cs5ch15.aspx)
- [C# 5.0 Unleashed. Bart De Smet. Sams Publishing. 2013.](https://www.goodreads.com/book/show/16284093-c-5-0-unleashed)
   - *Chapter 28.* Working with I/O 
- [Programming C# 5.0. Ian Griffiths. O'Reilly Media. 2012.](http://shop.oreilly.com/product/0636920024064.do)
   - *Chapter 16.* Files and Streams [Download Example Code](https://resources.oreilly.com/examples/0636920024064/blob/master/Ch16.zip)
- [*Пространство имен System.IO*](https://msdn.microsoft.com/ru-ru/library/system.io(v=vs.110).aspx)


## Задачи
1.  **(deadline - 07.05.2019, 24.00)** Разработать класс, предоставляющий следующие функциональные возможности : 
      - функцию побайтового копирования содержимого одного тествового файла в другой с использованием класса FileStream в качестве потока с резервным хранилищем; функция должна возвращать количество записанных байт;
      - функцию побайтового копирования содержимого одного тествового файла в другой с использованием класса MemoryStream в качестве потока с резервным хранилищем; функция должна возвращать количество записанных байт; содержимое потока MemoryStream наполняется массивом байт, полученных на основе текстовой информации из файла-источника с помощью класса StreamReader;
      - функцию копирования содержимого одного тествового файла в другой, используя возможности буферизации класса FileStream, функция должна возвращать количество записанных байт;
      - функцию копирования содержимого одного тествового файла в другой, используя возможности класса-декоратора потоков BufferedStream, функция должна возвращать количество записанных байт;
      - функцию копирования содержимого одного тествового файла в другой с использованием класса MemoryStream в качестве потока с резервным хранилищем; функция должна возвращать количество записанных байт; 
      - функцию построчного копирования содержимого одного тествового файла в другой, функция должна возвращать количество записанных строк;
      - функцию сравнения содержимого исходного и полученного файлов.
- Протестировать работу класса для данного текстового [*SourceText.txt*](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/edit/master/Day%2020%20-%2001.05.2019/) в консоли, обратить внимание на содержимое файлов, полученных при копировании с помощью различных методов класса. Результаты проанализировать.
- Проанализировать основные возможности потоков (CanRead, CanSeek, CanTimeout, CanWrite...).
- Для выполнения задания использовать следующий [проект Streams.zip](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/tree/master/Day%2020%20-%2001.05.2019).

2. **(deadline - )** Реализовать функциональность, обозначенную в методах класса *IOStreamTask* проекта [Streams.2.zip](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/tree/master/Day%2020%20-%2001.05.2019). Проверить работу реализованной функциональности для предлагаемых в проекте тестов.

## Реализация (Done)
1. - [Решение](https://github.com/arinkarus/NET1.S.2019.Chemrukova.20-21/blob/master/Streams/StreamsDemo/StreamsExtension.cs)
   - [Консоль](https://github.com/arinkarus/NET1.S.2019.Chemrukova.20-21/blob/master/Streams/ConsoleClient/Program.cs)
2. - [Решение](https://github.com/arinkarus/NET1.S.2019.Chemrukova.20-21/blob/master/Streams.2/IOStreams/IOStreamTask.cs)
