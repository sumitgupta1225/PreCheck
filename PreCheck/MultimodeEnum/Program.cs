using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultimodeEnum
{
    // Add the attribute Flags or FlagsAttribute.
    [Flags]
    public enum NotifyOptions
    {
        // The flag for Preliminary is 0001=1.
        Preliminary = 0x01,
        // The flag for Published is 0010=2.
        Published = 0x02,
        // The flag for SpecificDate is 0100=4.
        SpecificDate = 0x04,        
    }
    class Program
    {
        static void Main(string[] args)
        {
            // The bitwise OR of 0001 and 0100 is 0101.
            NotifyOptions options = NotifyOptions.Preliminary;

            Console.WriteLine("Preliminary: "+(int)options + " "+options.GetHashCode());

            options = NotifyOptions.Published;

            Console.WriteLine("Published: " + (int)options + " " + options.GetHashCode());

            options = NotifyOptions.SpecificDate;

            Console.WriteLine("SpecificDate: " + (int)options + " " + options.GetHashCode());

            // Because the Flags attribute is specified, Console.WriteLine displays 
            // the name of each enum element that corresponds to a flag that has 
            // the value 1 in variable options.

            options = NotifyOptions.Preliminary | NotifyOptions.Published;

            // The integer value of 0101 is 5.
            
            Console.WriteLine(options + ":" + (int)options);

            options = NotifyOptions.Preliminary | NotifyOptions.SpecificDate;
            
            Console.WriteLine(options + ":" + (int)options);

            options = NotifyOptions.Published | NotifyOptions.SpecificDate;

            Console.WriteLine(options + ":" + (int)options);

            options = NotifyOptions.Preliminary | NotifyOptions.Published |NotifyOptions.SpecificDate;
           
            Console.WriteLine(options + ":" + (int)options);
            
            options = (NotifyOptions)7;
            Console.WriteLine(options);            

            var r = options.HasFlag(NotifyOptions.Published | NotifyOptions.Preliminary);
            Console.WriteLine(r);
            Console.WriteLine((int)options);
            Console.Read();
        }
    }
}
