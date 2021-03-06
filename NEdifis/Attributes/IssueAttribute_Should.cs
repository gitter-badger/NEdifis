using System;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;

namespace NEdifis.Attributes
{
    [TestFixtureFor(typeof(IssueAttribute))]
    [Issue("#42", Title = "Create an attribute to assign a ticket id")]
    // ReSharper disable once InconsistentNaming
    internal class IssueAttribute_Should
    {
        [Test]
        public void Be_Creatable()
        {
            var ctx = new ContextFor<IssueAttribute>();
            var sut = ctx.BuildSut();

            sut.Should().NotBeNull();
            sut.Should().BeAssignableTo<Attribute>();
        }

        [Test]
        [Issue("13", Title = "a test should resolve or be related to multiple tickets")]
        public void Allow_Multiple()
        {
            var att = typeof(IssueAttribute).GetCustomAttribute<AttributeUsageAttribute>();

            att.Should().NotBeNull();
            att.AllowMultiple = true;
            att.ValidOn.Should().Be(AttributeTargets.All);
        }

        [Test]
        public void Have_Id_and_Title()
        {
            var sut = new IssueAttribute("#23") { Title = "foo bar" };
            sut.Id.Should().Be("#23");
            sut.Title.Should().Be("foo bar");
        }
    }
}