﻿
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regulus.Remoting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regulus.Remoting.Tests
{
    [TestClass()]
    public class PackageReleaseTests
    {
        [TestMethod()]
        public void ToBufferTest1()
        {
            var id = Guid.NewGuid();
            var package1 = new TestPackageData();
            package1.Id = id;

            var buffer = package1.ToBuffer();

            var package2 = buffer.ToPackageData<TestPackageData>();

            Assert.AreEqual(id , package2.Id);
        }

        [TestMethod()]
        public void ToBufferTest2()
        {
            
            var p1 = 0;
            var p2 = "234";
            var p3 = Guid.NewGuid();
            var package1 = new TestPackageBuffer();
            
            
            
            package1.Datas = new [] { Regulus.TypeHelper.Serializer(p1), Regulus.TypeHelper.Serializer(p2), Regulus.TypeHelper.Serializer(p3) };

            var buffer = package1.ToBuffer();

            var package2 = buffer.ToPackageData<TestPackageBuffer>();

            
            Assert.AreEqual(p1, Regulus.TypeHelper.Deserialize<int>(package2.Datas[0]));
            Assert.AreEqual(p2, Regulus.TypeHelper.Deserialize<string>(package2.Datas[1]));
            Assert.AreEqual(p3, Regulus.TypeHelper.Deserialize<Guid>(package2.Datas[2]));
        }

        [TestMethod()]
        public void ToBufferTest3()
        {

            
            
            var package1 = new TestPackageBuffer();



            package1.Datas = new byte[0][] ;

            var buffer = package1.ToBuffer();

            var package2 = buffer.ToPackageData<TestPackageBuffer>();


            Assert.AreEqual(0, package2.Datas.Length);
            
        }
    }

    [ProtoBuf.ProtoContract]
    public class TestPackageData : TPackageData<TestPackageData>
    {
        [ProtoBuf.ProtoMember(1)]
        public Guid Id;
    }

    [ProtoBuf.ProtoContract]
    public class TestPackageBuffer : TPackageData<TestPackageBuffer>
    {

        public TestPackageBuffer()
        {
            Datas = new byte[0][];
        }
        [ProtoBuf.ProtoMember(1)]
        public byte[][] Datas;
    }
}