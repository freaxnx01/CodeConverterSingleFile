using RoslynCodeConverter.Client;
using RoslynCodeConverter.Client.Proxies;
using RoslynCodeConverter.Client.Proxies.Models;
using System;
using System.IO;

namespace CodeConverterSingleFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileInput = args[0];

            var codeToConvert = File.ReadAllText(fileInput);

            var fileOutput = Path.ChangeExtension(fileInput, ".cs");

            var client = new RoslynCodeConverter.Client.Proxies.RoslynCodeConverter();

            //ConvertResponse result = client.Converter.Post(new ConvertRequest()
            //{
            //    Code = "public class Test {}",
            //    RequestedConversion = SupportedConversions.CSharp2Vb
            //});

//            var code = """
//Imports System.Reflection

//<Assembly: AssemblyTitle("pmc hyp ImportService AnyFileType ANIM")>
//<Assembly: AssemblyDescription("pmc hyp ImportService AnyFileType ANIM")>
//<Assembly: AssemblyProduct("pmc_hyp_ImportService_AnyFileType_ANIM")>
//""";

            ConvertResponse result = client.Converter.Post(new ConvertRequest()
            {
                //Code = "Public Class MyTest\r\nEnd Class",
                Code = codeToConvert,
                RequestedConversion = SupportedConversions.Vb2CSharp
            });

            if (true == result.ConversionOk)
            {
                File.WriteAllText(fileOutput, result.ConvertedCode);

                Console.WriteLine("Conversion succeeded");
                Console.WriteLine(result.ConvertedCode);
            }
            else
            {
                Console.WriteLine("Error converting: " + result.ErrorMessage);
            }
        }
    }
}
