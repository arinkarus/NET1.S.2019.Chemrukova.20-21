using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.IO.Packaging;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace IOStreams
{
	public static class IOStreamTask
	{
        /// <summary>
        /// Parses Resourses\Planets.xlsx file and returns the planet data: 
        ///   Jupiter     69911.00
        ///   Saturn      58232.00
        ///   Uranus      25362.00
        ///    ...
        /// See Resourses\Planets.xlsx for details
        /// </summary>
        /// <param name="xlsxFileName">Source file name.</param>
        /// <returns>Sequence of PlanetInfo</returns>
        public static IEnumerable<PlanetInfo> ReadPlanetInfoFromXlsx(string xlsxFileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates hash of stream using specified algorithm.
        /// </summary>
        /// <param name="stream">Source stream</param>
        /// <param name="hashAlgorithmName">
        /// Hash algorithm ("MD5","SHA1","SHA256" and other supported by .NET).
        /// </param>
        /// <returns></returns>
        public static string CalculateHash(this Stream stream, string hashAlgorithmName)
        {
            var hashAlgorithm = HashAlgorithm.Create(hashAlgorithmName);
            if (hashAlgorithm == null)
            {
                throw new ArgumentException("Can't find hash algorithm by given name!");
            }
            var hash = hashAlgorithm.ComputeHash(stream);
            return string.Join(string.Empty, hashAlgorithm.ComputeHash(stream).Select(x => x.ToString("X2").ToUpper()));
        }
    
		/// <summary>
		/// Returns decompressed stream from file. 
		/// </summary>
		/// <param name="fileName">Source file.</param>
		/// <param name="method">Method used for compression (none, deflate, gzip).</param>
		/// <returns>output stream</returns>
		public static Stream DecompressStream(string fileName, DecompressionMethods method)
		{
            var stream = File.Create(fileName);
            switch (method)
            {
                case DecompressionMethods.GZip:
                    return new GZipStream(stream, CompressionMode.Decompress);
                case DecompressionMethods.Deflate:
                    return new DeflateStream(stream, CompressionMode.Decompress);
                case DecompressionMethods.None:
                    return stream;
                default:
                    throw new ArgumentException("There is no decompression method!");
            }
		}

		/// <summary>
		/// Reads file content encoded with non Unicode encoding
		/// </summary>
		/// <param name="fileName">Source file name</param>
		/// <param name="encoding">Encoding name</param>
		/// <returns>Unicoded file content</returns>
		public static string ReadEncodedText(string fileName, string encoding)
		{
            //return File.ReadAllText(fileName, Encoding.GetEncoding(encoding));
            using (var streamReader = new StreamReader(fileName, Encoding.GetEncoding(encoding)))
            {
                return streamReader.ReadToEnd();
            }
		}

        private static XDocument LoadToXml(this Package package, string xmlPath)
        {
            var uri = new Uri(xmlPath, UriKind.Relative);

            using (var stream = package.GetPart(uri).GetStream(FileMode.Open, FileAccess.Read))
            {
                return XDocument.Load(stream);
            }
        }
    }
}