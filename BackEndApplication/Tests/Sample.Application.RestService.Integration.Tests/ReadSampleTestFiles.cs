using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;


namespace Sample.Application.RestService.Integration.Tests
{
    [ExcludeFromCodeCoverage]

    public class ReadSampleTestFiles

    {

        private const string EmbeddedResourceSubNamespace = "TestFiles";
        private static readonly Assembly AssemblyClass = typeof(ReadSampleTestFiles).Assembly;


        public static string GetJson(string fileName)
        {
            return GetEmbeddedResourceStringContent(EmbeddedResourceSubNamespace, fileName, "json");
        }



        public static string GetXml(string fileName)
        {
            return GetEmbeddedResourceStringContent(EmbeddedResourceSubNamespace, fileName, "xml");
        }



        private static string GetEmbeddedResourceStringContent(string ns, string fileName, string fileType)
        {
            try
            {
                string resfile = $"{typeof(ReadSampleTestFiles).Namespace}.{ns}.{fileName}.{fileType}";
                using var stream = AssemblyClass.GetManifestResourceStream(resfile);
                if (stream == null)
                {
                    throw new FileNotFoundException($"Cannot find embedded resource file '{resfile}'", resfile);
                }
                using TextReader reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
