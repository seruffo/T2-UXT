using System.Net.Http;
using Xunit;
using Xunit.Priority;

namespace FirjanTests.Scenarios.Base.Query
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public abstract class Base : BaseTest
    {
        public new void Configure(string controllers, string id, string fieldOrderBy)
            => base.Configure(controllers, id, fieldOrderBy);

        public bool AssertTest { get; set; } = true;

        private void AssertMethod()
        {
            if (AssertTest)
                Assert.True(IsSuccess);
            else
                Assert.False(IsSuccess);
        }

        [Fact, Priority(0)]
        public new void GetAll()
        {
            base.GetAll();

            AssertMethod();
        }

        [Fact, Priority(1)]
        public new void Get()
        {
            base.Get();

            AssertMethod();
        }
    }
}

namespace FirjanTests.Scenarios.Base.CRUD
{ 
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public abstract class Base : BaseTest
    {
        public bool AssertTest { get; set; } = true;
        public void AssertMethod()
        {
            if (AssertTest)
                Assert.True(IsSuccess);
            else
                Assert.False(IsSuccess);
        }

        [Fact, Priority(0)]
        public virtual new void GetAll()
        {
            base.GetAll();

            AssertMethod();
        }

        [Fact, Priority(1)]
        public virtual new void Get()
        {
            base.Get();

            AssertMethod();
        }

        [Fact, Priority(2)]
        public virtual new void Post()
        {
            base.Post();

            AssertMethod();

            base.Delete();
        }

        [Fact, Priority(3)]
        public virtual new void Put()
        {
            base.Post();

            base.Put();

            AssertMethod();

            base.Delete();
        }

        [Fact, Priority(4)]
        public virtual new void Delete()
        {
            base.Post();

            base.Put();

            base.Delete();

            AssertMethod();
        }

        internal void SendPut()
        {
            Send(HttpMethod.Put);
        }

        internal void SendPost()
        {
            Send(HttpMethod.Post);
        }

        internal void SendDelete()
        {
            Send(HttpMethod.Delete);
        }
    }
}
