using Autofac;
using Jom.Blog.Controllers;
using Jom.Blog.IServices;
using Jom.Blog.Model.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace Jom.Blog.Tests
{
    public class BlogController_Should
    {
        Mock<IBlogArticleServices> mockBlogSev = new Mock<IBlogArticleServices>();
        Mock<ILogger<BlogController>> mockLogger = new Mock<ILogger<BlogController>>();
        BlogController blogController;

        private IBlogArticleServices blogArticleServices;
        DI_Test dI_Test = new DI_Test();



        public BlogController_Should()
        {
            mockBlogSev.Setup(r => r.Query());


            var container = dI_Test.DICollections();
            blogArticleServices = container.Resolve<IBlogArticleServices>();
            blogController = new BlogController(blogArticleServices, mockLogger.Object);
        }

        [Fact]
        public void TestEntity()
        {
            BlogArticle blogArticle = new BlogArticle();

            Assert.True(blogArticle.bID >= 0);
        }
        [Fact]
        public async void GetBlogsTest()
        {
            object blogs =await blogController.Get(1);

            Assert.NotNull(blogs);
        }

        [Fact]
        public async void PostTest()
        {
            BlogArticle blogArticle = new BlogArticle()
            {
                bCreateTime = DateTime.Now,
                bUpdateTime = DateTime.Now,
                btitle = "xuint :test controller addEntity",

            };

            var res = await blogController.Post(blogArticle);

            Assert.True(res.success);

            var data = res.response;

            Assert.NotNull(data);
        }
    }
}
