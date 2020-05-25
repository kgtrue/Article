using Articles.Core.Entities;
using Articles.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Articles.Core.Tests
{
    public class ArticleTests
    {
        [Fact]
        public void TestArticle_NullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => new Article(null));
        }
        [Fact]
        public void TestArticle_Author_FirstName()
        {
            Assert.Throws<CoreValidationException>(() => new Article(new Author() { FirstName = "", LastName = "lastname" }));
        }
        [Fact]
        public void TestArticle_Author_LastName()
        {
            Assert.Throws<CoreValidationException>(() => new Article(new Author() { FirstName = "Firstame", LastName = "" }));
        }

        [Fact]
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
        [Fact]
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
