<<<<<<< HEAD
=======
using System;
>>>>>>> eed87d12f110c598ec5ea2783c6c988aa1aeb682
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
// [assembly: AssemblyTitle("SalvationArmyProject.Models")]
// [assembly: AssemblyDescription("")]
// [assembly: AssemblyConfiguration("")]
// [assembly: AssemblyCompany("HP Inc.")]
// [assembly: AssemblyProduct("SalvationArmyProject.Models")]
// [assembly: AssemblyCopyright("Copyright © HP Inc. 2019")]
// [assembly: AssemblyTrademark("")]
// [assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
// [assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
// [assembly: Guid("8d6e15fe-e3df-4d0e-9a28-f0379f6b331b")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// [assembly: AssemblyVersion("1.0.0.0")]
// [assembly: AssemblyFileVersion("1.0.0.0")]

namespace SalvationArmyProject.Models
{

    public class Events
    {
        public Guid id { get; set; }

        public string eventName { get; set; }

        public string eventDescription { get; set;}

        public DateTime eventDate { get; set; }

        public DateTime eventTime { get; set; }
    }
}
