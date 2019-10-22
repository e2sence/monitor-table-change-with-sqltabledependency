﻿using System;
using System.Globalization;
using System.Linq.Expressions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TableDependency.SqlClient.Test.Models;
using TableDependency.SqlClient.Where;

namespace TableDependency.SqlClient.Test
{
    [TestClass]
    public class WhereUnitTestToString
    {
        [TestMethod]
        public void ToStringOnIntField1()
        {
            // Arrange
            Expression<Func<Product, bool>> expression = p => p.Price.ToString() == "123";

            // Act
            var where = new SqlTableDependencyFilter<Product>(expression).Translate();

            // Assert
            Assert.AreEqual("(CONVERT(varchar(MAX), [Price]) = '123')", where);
        }


        [TestMethod]
        public void ToStringWithInvariantCulture1()
        {
            // Arrange
            Expression<Func<Product, bool>> expression = p => p.Price.ToString(CultureInfo.InvariantCulture) == "123.4";

            // Act
            var where = new SqlTableDependencyFilter<Product>(expression).Translate();

            // Assert
            Assert.AreEqual("(CONVERT(varchar(MAX), [Price]) = '123.4')", where);
        }

        [TestMethod]
        public void ToStringOnStringField1()
        {
            // Arrange
            Expression<Func<Product, bool>> expression = p => p.Code.ToString() == "123.4";

            // Act
            var where = new SqlTableDependencyFilter<Product>(expression).Translate();

            // Assert
            Assert.AreEqual("(CONVERT(varchar(MAX), [Code]) = '123.4')", where);
        }
    }
}