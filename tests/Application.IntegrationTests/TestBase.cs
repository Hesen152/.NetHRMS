﻿using NUnit.Framework;
using System.Threading.Tasks;

namespace dotnethrmsmy.Application.IntegrationTests
{
    using static Testing;

    public class TestBase
    {
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}
