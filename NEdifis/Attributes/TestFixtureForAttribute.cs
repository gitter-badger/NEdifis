using System;
using NUnit.Framework;

namespace NEdifis.Attributes
{
    /// <summary>
    /// Attribute do define the test fixture which tests the class.
    /// Currently you can resharper and F12 to navigate to the test class directly
    /// </summary>
    public class TestFixtureForAttribute : TestFixtureAttribute
    {
        public TestFixtureForAttribute(Type classToTest)
        {
            ClassToTest = classToTest;
        }

        public Type ClassToTest { get; private set; }
    }
}