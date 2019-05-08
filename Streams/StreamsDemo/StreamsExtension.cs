using System;
using System.IO;
using System.Linq;
using System.Text;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {
        const int BufferSize = 1000;

        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using (var readFileStream = File.OpenRead(sourcePath))
            {
                using (var writeFileStream = File.Create(destinationPath))
                {
                    int amountOfBytes = 0;
                    for (int i = 0; i < readFileStream.Length; i++)
                    {
                        writeFileStream.WriteByte((byte)readFileStream.ReadByte());
                        amountOfBytes++;
                    }

                    return amountOfBytes;
                }
            }
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            string dataFromSourceFile = null;
            using (var streamReader = new StreamReader(sourcePath, Encoding.ASCII))
            {
                dataFromSourceFile = streamReader.ReadToEnd();
            }
            Encoding encoding = Encoding.ASCII;
            byte[] bytes = encoding.GetBytes(dataFromSourceFile);
            char[] fileCharContent = new char[bytes.Length];
            using (var memoryStream = new MemoryStream(bytes, 0, bytes.Length))
            {
                byte[] resultBytes = memoryStream.ToArray();
                fileCharContent = encoding.GetChars(resultBytes);
            }

            using (var streamWriter = new StreamWriter(File.Create(destinationPath)))
            {
                streamWriter.Write(fileCharContent);
                return fileCharContent.Length;
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            char[] block = new char[BufferSize];
            var sourceString = new StringBuilder();
            int readedBlock = 0;
            using (var reader = File.OpenText(sourcePath))
            {
                sourceString.Append(reader.ReadToEnd());
            }

            var encoding = Encoding.ASCII;
            byte[] buffer = encoding.GetBytes(sourceString.ToString());
            using (var memoryStream = new MemoryStream(buffer, 0, buffer.Length))
            {
                using (var streamWriter = new StreamWriter(File.Create(destinationPath)))
                {
                    byte[] bytesBlock = new byte[BufferSize];
                    while ((readedBlock = memoryStream.Read(bytesBlock, 0, BufferSize)) != 0)
                    {
                        streamWriter.Write(Encoding.UTF8.GetChars(bytesBlock));
                    }

                    return (int)memoryStream.Length;
                }
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using (var readFileStream = File.OpenRead(sourcePath))
            {
                using (var writeFileStream = File.Create(destinationPath))
                {
                    int inputFileLength = (int)readFileStream.Length;
                    byte[] buffer = new byte[inputFileLength];
                    int bytesRead = 0;
                    int offset = 0;
                    while ((bytesRead = readFileStream.Read(buffer, offset, inputFileLength - offset)) > 0)
                    {
                        writeFileStream.Write(buffer, offset, bytesRead);
                        offset += bytesRead;
                    }

                    return (int)writeFileStream.Length;
                }
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using (var readFileStream = File.OpenRead(sourcePath))
            {
                using (var bufferedStream = new BufferedStream(readFileStream, BufferSize))
                {
                    using (var writeFileStream = File.Create(destinationPath))
                    {
                        byte[] buffer = new byte[BufferSize];
                        int bytesRead = 0;
                        int offset = 0;
                        while ((bytesRead = bufferedStream.Read(buffer, 0, BufferSize)) > 0)
                        {
                            writeFileStream.Write(buffer, 0, bytesRead);
                            offset += bytesRead;
                        }

                        return (int)writeFileStream.Length;
                    }
                }
            }
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using (var readFileStream = new StreamReader(sourcePath))
            {
                using (var writeFileStream = new StreamWriter(destinationPath))
                {
                    int amountOfLines = 0;
                    string line = null;
                    while ((line = readFileStream.ReadLine()) != null)
                    {
                        writeFileStream.WriteLine(line);
                        amountOfLines++;
                    }

                    return amountOfLines;
                }
            }
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            if (new FileInfo(sourcePath).Length != new FileInfo(destinationPath).Length)
            {
                return false;
            }

            using (var sourceFileStream = File.OpenRead(sourcePath))
            {
                using (var destFileStream = File.OpenRead(destinationPath))
                {
                    for (int i = 0; i < sourceFileStream.Length; i++)
                    {
                        if (sourceFileStream.ReadByte() != destFileStream.ReadByte())
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (sourcePath == null)
            {
                throw new ArgumentNullException($"Source file is null {nameof(sourcePath)}");
            }

            if (destinationPath == null)
            {
                throw new ArgumentNullException($"Source file is null {nameof(destinationPath)}");
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException($"Source file is not found {nameof(sourcePath)}");
            }
        }

        #endregion

        #endregion

    }
}
