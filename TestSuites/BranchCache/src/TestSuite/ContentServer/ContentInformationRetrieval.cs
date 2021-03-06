// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Text;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Protocols.TestTools;
using Microsoft.Protocols.TestTools.Messages;
using Microsoft.Protocols.TestTools.StackSdk.BranchCache.Pccrtp;
using Microsoft.Protocols.TestTools.StackSdk.BranchCache.Pccrd;
using Microsoft.Protocols.TestTools.StackSdk.BranchCache.Pccrc;
using Microsoft.Protocols.TestTools.StackSdk.BranchCache.Pccrr;
using Microsoft.Protocols.TestTools.StackSdk.BranchCache.Pchc;
using Microsoft.Protocols.TestTools.StackSdk.CommonStack;
using Microsoft.Protocols.TestTools.StackSdk.CommonStack.Enum;
using Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Smb2;
using Microsoft.Protocols.TestSuites.BranchCache.TestSuite;

namespace Microsoft.Protocols.TestSuites.BranchCache.TestSuite.ContentServer
{
    [TestClass]
    public class ContentInformationRetrieval : BranchCacheTestClassBase
    {
        #region Test Suite Initialization

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            TestClassBase.Initialize(testContext);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestClassBase.Cleanup();
        }

        protected override void TestInitialize()
        {
            base.TestInitialize();

            ResetContentServer();
        }

        protected override void TestCleanup()
        {
            ResetContentServer();

            base.TestCleanup();
        }

        #endregion

        #region ContentServer_BVT_ContentInformationRetrieval_V1

        [TestMethod]
        [TestCategory("BVT")]
        [TestCategory("ContentServer")]
        [TestCategory("BranchCacheV1")]
        [TestCategory("PCCRTP")]
        [TestCategory("SMB2")]
        public void ContentServer_BVT_ContentInformationRetrieval_V1()
        {
            CheckApplicability();

            RetrieveContentInformation(BranchCacheVersion.V1);
        }

        #endregion

        #region ContentServer_BVT_ContentInformationRetrieval_V2

        [TestMethod]
        [TestCategory("BVT")]
        [TestCategory("ContentServer")]
        [TestCategory("BranchCacheV2")]
        [TestCategory("PCCRTP")]
        [TestCategory("SMB2")]
        public void ContentServer_BVT_ContentInformationRetrieval_V2()
        {
            CheckApplicability();

            RetrieveContentInformation(BranchCacheVersion.V2);
        }

        #endregion

        #region Private Methods

        public void RetrieveContentInformation(BranchCacheVersion version)
        {
            BaseTestSite.Log.Add(
                LogEntryKind.Debug,
                "Trigger hash generation on content server");

            var content = contentInformationUtility.RetrieveContentData();

            BaseTestSite.Log.Add(
                LogEntryKind.Debug,
                "Retrieve content information from content server");

            var contentInformation = contentInformationUtility.RetrieveContentInformation(version);

            contentInformationUtility.VerifyContentInformation(content, contentInformation, version);
        }

        #endregion
    }
}
