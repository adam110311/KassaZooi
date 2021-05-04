using FancyCashRegister.Services.Data;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;


namespace FancyCashRegister.Test.UnitTests
{
    public class AdvertentieRepositoryTest
    {
        [Fact]
        public void Dummy()
        {
            true.Should().BeTrue();
        }

        [Fact]
        public void GetNextAdPath_WhenCalledThenAdFileFullPathReturned()
        {
            // Arrange
            var subject = new AdvertentieRepository();
            var regExAdFile = ConfigurationManager.AppSettings["RegexAdFile"];


            // Act
            var actualFirst = subject.GetNextAdPath();
            var actualSecond = subject.GetNextAdPath();



            // Assert
            actualFirst.Should().NotBeNullOrEmpty();

            Regex.IsMatch(Path.GetFileName(actualFirst), regExAdFile).Should().BeTrue();

            actualSecond.Should().NotBeNullOrEmpty();
            Regex.IsMatch(Path.GetFileName(actualSecond), regExAdFile).Should().BeTrue();

        }

        [Fact]
        public void GetNextAdUri_WhenCalledThenAdFileUriReturned()
        {
            // Arrange
            var subject = new AdvertentieRepository();
            var regExAdFile = ConfigurationManager.AppSettings["RegexAdFile"];


            // Act
            var actualFirst = subject.GetNextAdUri();
            var actualSecond = subject.GetNextAdUri();

            // Assert
            actualFirst.Should().NotBeNull();
            Regex.IsMatch(Path.GetFileName(actualFirst.AbsolutePath), regExAdFile).Should().BeTrue();

            actualSecond.Should().NotBeNull();
            Regex.IsMatch(Path.GetFileName(actualSecond.AbsolutePath), regExAdFile).Should().BeTrue();


        }
    }
}
