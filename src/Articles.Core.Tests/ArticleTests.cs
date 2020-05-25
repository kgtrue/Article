using Articles.Core.Entities;
using Articles.Core.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articles.Core.Tests
{
    public class ArticleTests
    {
        [Test]
        public void TestArticle_NullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => new Article(null));
        }
        [Test]
        public void TestArticle_Author_FirstName()
        {
            Assert.Throws<CoreValidationException>(() => new Article(new Author() { FirstName = "", LastName = "lastname" }));
        }
        [Test]
        public void TestArticle_Author_LastName()
        {
            Assert.Throws<CoreValidationException>(() => new Article(new Author() { FirstName = "Firstame", LastName = "" }));
        }

        [Test]
        public void TestArticle_SetArticleAuthor_FirstName()
        {
            var article = new Article(new Author()
            {
                Id = Guid.NewGuid(),
                FirstName = "Firstame",
                LastName = "LastName"
            })
            {
                Id = Guid.NewGuid(),
                Heading = "Heading",
                Text = "Text",
                Year = 2020
            };
            Assert.Throws<CoreValidationException>(() => article.SetArticleAuthor(new Author()
            {
                Id = Guid.NewGuid(),
                FirstName = "",
                LastName = "LastName"
            }));
        }
        [Test]
        public void TestArticle_SetArticleAuthor_LastName()
        {
            var article = new Article(new Author()
            {
                Id = Guid.NewGuid(),
                FirstName = "Firstame",
                LastName = "LastName"
            })
            {
                Id = Guid.NewGuid(),
                Heading = "Heading",
                Text = "Text",
                Year = 2020
            };
            Assert.Throws<CoreValidationException>(() => article.SetArticleAuthor(new Author()
            {
                Id = Guid.NewGuid(),
                FirstName = "FirstName",
                LastName = ""
            }));
        }
    }
}
