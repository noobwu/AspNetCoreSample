// ***********************************************************************
// Assembly         : Aliyun.RocketMQSample.Producer
// Author           : Administrator
// Created          : 2020-02-29
//
// Last Modified By : Administrator
// Last Modified On : 2020-03-01
// ***********************************************************************
// <copyright file="Program.cs" company="NoobCore.com">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Kmmp.Core.Helper;
using Kmmp.Core.Imps;
using Kmmp.Core.Models;
using Kmmp.Core.MqFramework.RocketMQ;
using Kmmp.Core.MqFramework.RocketMQ.Producers;
using Kmmp.DSync.Data;
using ons;
using RocketMQSDK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The Producer namespace.
/// </summary>
namespace Aliyun.RocketMQSample.Producer
{

    /// <summary>
    /// Class Program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {

            try
            {
                //KmmpMQProducerTest();
                ProducerTest();
                //KmmpRocketMQPublisherTest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }
        /// <summary>
        /// 每线程发送消息数量
        /// </summary>
        private static readonly int MessageCountPerThread = 1;
        /// <summary>
        /// 线程总数
        /// </summary>
        private static readonly int ProducerThreadCount = 1;
        /// <summary>
        /// Producers the test.
        /// </summary>
        static void ProducerTest()
        {
            string strRocketMQConfigs = JsonConfigInfo.ReadAllFromFile("RocketMQConfigs.json");
            List<RocketMQConfig> configs = JsonHelper.JsonConvertDeserialize<List<RocketMQConfig>>(strRocketMQConfigs);
            Console.WriteLine($"ProducerTest,开始:{DateTime.Now}");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            List<OnscSharp> onscSharpList = new List<OnscSharp>();
            var taskList = new List<Task>();
            if (configs != null && configs.Count > 0)
            {
                configs.ForEach(config =>
                {
                    OnscSharp instance = new OnscSharp(config);
                    switch (config.MsgType)
                    {
                        case 2:
                        case 3:
                            {
                                instance.CreateOrderProducer();
                                instance.StartOrderProducer();
                            }
                            break;
                        default:
                            {
                                instance.CreateProducer();
                                instance.StartProducer();
                            }
                            break;
                    }
                    onscSharpList.Add(instance);
                });
            }
            onscSharpList.ForEach(instance =>
            {
                //消息类型(1:普通消息,2:分区顺序消息,3:全局顺序消息,4:事务消息,5:定时/延时消息)
                switch (instance.Config.MsgType)
                {
                    case 2:
                    case 3:
                        {
                            for (int tempThreadIndex = 1; tempThreadIndex <= ProducerThreadCount; tempThreadIndex++)
                            {
                                // 生产消费
                                var task = Task.Factory.StartNew(() =>
                                {
                                    for (int tempMessageIndex = 1; tempMessageIndex <= MessageCountPerThread; tempMessageIndex++)
                                    {
                                        instance.SendOrderMessage($"This is order test message {tempThreadIndex}:{tempMessageIndex}", $"{instance.Config.GroupId.Replace(instance.Config.GroupIdPrefix, string.Empty)}OrderMessage");
                                    }
                                }, TaskCreationOptions.LongRunning);

                                taskList.Add(task);
                            }
                        }
                        break;
                    case 5:
                        {
                            for (int tempThreadIndex = 1; tempThreadIndex <= ProducerThreadCount; tempThreadIndex++)
                            {
                                // 生产消费
                                var task = Task.Factory.StartNew(() =>
                                {
                                    for (int tempMessageIndex = 1; tempMessageIndex <= MessageCountPerThread; tempMessageIndex++)
                                    {
                                        instance.SendMessage($"This is time delay test message {tempThreadIndex}:{tempMessageIndex}", $"{instance.Config.GroupId.Replace(instance.Config.GroupIdPrefix, string.Empty)}Message", DateTime.Now.AddSeconds(10));
                                    }
                                }, TaskCreationOptions.LongRunning);

                                taskList.Add(task);
                            }
                        }
                        break;
                    default:
                        {
                            for (int tempThreadIndex = 1; tempThreadIndex <= ProducerThreadCount; tempThreadIndex++)
                            {
                                // 生产消费
                                var task = Task.Factory.StartNew(() =>
                                {
                                    for (int tempMessageIndex = 1; tempMessageIndex <= MessageCountPerThread; tempMessageIndex++)
                                    {
                                        instance.SendMessage($"This is test message {tempThreadIndex}:{tempMessageIndex}", $"{instance.Config.GroupId.Replace(instance.Config.GroupIdPrefix, string.Empty)}Message");
                                    }
                                }, TaskCreationOptions.LongRunning);
                                taskList.Add(task);
                            }
                        }
                        break;
                }
            });
            Task.WaitAll(taskList.ToArray());
            onscSharpList.ForEach(a =>
            {
                a.ShutdownProducer();
                a.ShutdownOrderProducer();
            });
            stopWatch.Stop();

            Console.WriteLine($"ProducerTest,结束, 使用时间{stopWatch.ElapsedMilliseconds}毫秒");
        }

        /// <summary>
        /// KMMPs the rocket mq publisher test.
        /// </summary>
        static void KmmpRocketMQPublisherTest()
        {
            string queueName = "CateringVipType";
            string strRocketMQConfigs = JsonConfigInfo.ReadAllFromFile("RocketMQConfigs.json");
            List<RocketMQConfig> configs = JsonHelper.JsonConvertDeserialize<List<RocketMQConfig>>(strRocketMQConfigs);
            Console.WriteLine($"KmmpRocketMQPublisherTest,开始:{DateTime.Now}");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            List<IMessagePublisher> publisherList = new List<IMessagePublisher>();
            var taskList = new List<Task>();
            configs?.ForEach(config =>
            {
                IMessagePublisher instance = null;
                //消息类型(1:普通消息,2:分区顺序消息,3:全局顺序消息,4:事务消息,5:定时/延时消息)
                switch (config.MsgType)
                {
                    case 2:
                    case 3:
                        {
                            instance = new RocketMQOrderPublisher(config, queueName);
                            for (int tempThreadIndex = 1; tempThreadIndex <= ProducerThreadCount; tempThreadIndex++)
                            {
                                // 生产消费
                                var task = Task.Factory.StartNew(() =>
                                {
                                    for (int tempMessageIndex = 1; tempMessageIndex <= MessageCountPerThread; tempMessageIndex++)
                                    {
                                        //instance.Put($"This is order test message {tempThreadIndex}:{tempMessageIndex}");
                                        instance.Put(GetMQVipData());
                                    }
                                }, TaskCreationOptions.LongRunning);

                                taskList.Add(task);
                            }
                        }
                        break;
                    case 5:
                        {
                            instance = new RocketMQPublisher(config, queueName);
                            for (int tempThreadIndex = 1; tempThreadIndex <= ProducerThreadCount; tempThreadIndex++)
                            {
                                // 生产消费
                                var task = Task.Factory.StartNew(() =>
                                {
                                    for (int tempMessageIndex = 1; tempMessageIndex <= MessageCountPerThread; tempMessageIndex++)
                                    {
                                        //instance.Put($"This is order test message {tempThreadIndex}:{tempMessageIndex}");
                                        instance.Put(GetMQVipData(), delay: 10);
                                    }
                                }, TaskCreationOptions.LongRunning);

                                taskList.Add(task);
                            }
                        }
                        break;
                    default:
                        {
                            instance = new RocketMQPublisher(config, queueName);
                            for (int tempThreadIndex = 1; tempThreadIndex <= ProducerThreadCount; tempThreadIndex++)
                            {
                                // 生产消费
                                var task = Task.Factory.StartNew(() =>
                                {
                                    for (int tempMessageIndex = 1; tempMessageIndex <= MessageCountPerThread; tempMessageIndex++)
                                    {
                                        instance.Put(GetMQVipData(), delay: 10);
                                    }
                                }, TaskCreationOptions.LongRunning);
                                taskList.Add(task);
                            }
                        }
                        break;
                }
            });
            Task.WaitAll(taskList.ToArray());
            publisherList?.ForEach(a =>
            {
                a.Dispose();
            });
            stopWatch.Stop();

            Console.WriteLine($"KmmpRocketMQPublisherTest,结束, 使用时间{stopWatch.ElapsedMilliseconds}毫秒");
        }
        /// <summary>
        /// KMMPs the mq producer test.
        /// </summary>
        static void KmmpMQProducerTest()
        {

            System.DateTime startTime = System.DateTime.Now;
            string queueName = "CateringVipType";
            Console.WriteLine($"发送消息,{queueName}:{DateTime.Now}");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            IMessagePublisher publisher = GetPublisher(queueName);
            var taskList = new List<Task>();
            for (int threadIndex = 1; threadIndex <= ProducerThreadCount; threadIndex++)
            {
                // 生产消费
                var task = Task.Factory.StartNew(() =>
                {
                    for (int messageIndex = 1; messageIndex <= MessageCountPerThread; messageIndex++)
                    {
                        KmmpMQPublisherTest(publisher);
                    }
                }, TaskCreationOptions.LongRunning);

                taskList.Add(task);
            }
            string tempQueueName = "TempCateringVipType";
            Console.WriteLine($"发送消息,{tempQueueName}:{DateTime.Now}");
            IMessagePublisher tempPublisher = GetPublisher(tempQueueName);
            for (int tempThreadIndex = 1; tempThreadIndex <= ProducerThreadCount; tempThreadIndex++)
            {
                // 生产消费
                var task = Task.Factory.StartNew(() =>
                {
                    for (int tempMessageIndex = 1; tempMessageIndex <= MessageCountPerThread; tempMessageIndex++)
                    {
                        KmmpMQPublisherTest(tempPublisher);
                    }
                }, TaskCreationOptions.LongRunning);

                taskList.Add(task);
            }

            Task.WaitAll(taskList.ToArray());
            publisher.Dispose();
            tempPublisher.Dispose();
            stopWatch.Stop();
            Console.WriteLine($"发送消息,{queueName}：{MessageCountPerThread * ProducerThreadCount}条， 使用时间{stopWatch.ElapsedMilliseconds}毫秒");
            Console.WriteLine($"发送消息,{tempQueueName}：{MessageCountPerThread * ProducerThreadCount}条， 使用时间{stopWatch.ElapsedMilliseconds}毫秒");
            Console.ReadLine();
        }

        /// <summary>
        /// KMMPs the mq publisher test.
        /// </summary>
        /// <param name="publisher">The publisher.</param>
        static void KmmpMQPublisherTest(IMessagePublisher publisher)
        {
            publisher.Put(GetMQVipData());

        }

        /// <summary>
        /// 获取消息队列对象
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <returns>IMessagePublisher.</returns>
        /// <exception cref="Exception">0006</exception>
        private static IMessagePublisher GetPublisher(string queueName)
        {
            var messageQueue = MessageQueueHelper.GetMessageQueueFromPool(queueName);
            IMessagePublisher _publisher = messageQueue.GetMessagePublisher(queueName);
            if (_publisher == null)
            {
                throw new Exception("0006");
            }
            return _publisher;
        }

        private static MQ_VipData<Temp_VipType> GetMQVipData()
        {

            var strJson = @"[
  {
    ""CustId"": 994323,
    ""CardTypeNo"": ""04"",
    ""CardTypeName"": ""小饭范会员                    "",
    ""Upgrade"": 0.0,
    ""BranchNo"": ""0331"",
    ""SupplyBalance"": true,
    ""SupplyValidate"": false,
    ""PaidFlag"": null,
    ""VipFee"": 0.0,
    ""Validity"": 0,
    ""PresentAmt"": 0.0
  },
  {
    ""CustId"": 994323,
    ""CardTypeNo"": ""01"",
    ""CardTypeName"": ""银牌会员                      "",
    ""Upgrade"": 0.0,
    ""BranchNo"": "",,,,,,,,,,,,,,,,,,,,,,,,,,3001,3002,3003,4001,4002,4003,4004,4005,4006,4007,4008,4009,4010,4011,4012,4013,4014,4015,4016,4017,4018,4019,4020,4021,4022,4023,4024,4025,4026,4027,4028,4029,4030,4031,4032,4033,4035,4036,4037,4038,4039,4040,4041,4042,4043,4044,4045,4046,4048,4049,4050,4051,4052,4053,4054,4055,4056,4057,0006,0007,1003,1004,1005,1006,1007,1008,1009,1010,1011,1012,1013,1014,1015,1016,1017,1018,1019,1020,1021,1022,1023,1024,1025,1026,1027,1028,1029,1030,1031,1032,1033,1034,1035,1036,1037,1038,1039,1040,1041,1042,1043,1044,1045,1046,1047,1048,1049,1050,1051,1052,1053,1054,1055,1056,1057,1058,1059,1060,1061,1062,1063,1064,1065,1066,1067,1068,1069,1070,1071,1072,1073,1074,1075,1076,1077,1078,1079,1080,1081,1082,1083,1084,1085,1086,1087,1088,1089,1090,1091,1092,1093,1094,1095,1096,1097,1098,1099,1100,1101,1102,1103,1104,1105,1106,1107,1108,1109,1110,1111,1112,1113,1114,1115,1116,1117,1118,1119,1120,1121,1122,1123,1124,1125,1126,1127,1128,1129,1130,1131,1132,1133,1134,1135,1136,1137,1138,1139,1140,1141,1142,1143,1144,1145,1146,1147,1148,1149,1150,1151,1152,1154,1155,1156,1157,1158,1159,1160,1161,1162,1163,1164,1165,1166,1167,1168,1169,1170,1171,1172,1173,1175,1176,1177,1178,1179,1180,1181,1183,1184,1185,1186,1187,9998,0001,0002,0003,0004,0005,0011,1001,0012,0014,0008,1002,0009,0013,0010,0015,0016,0017,0018,0019,0020,0021,0022,0023,0024,0025,0026,0027,0028,0029,0030,0031,0032,0033,0034,0035,0036,0037,0038,0039,0040,0041,0042,0043,0044,0045,0046,0047,0048,0049,0050,0051,0052,0053,0054,0055,0056,0057,0058,0059,0060,0061,0062,0063,0064,0065,0066,0067,0068,0069,0070,0071,0072,0073,0074,0075,0076,0077,0078,0079,0080,0081,0082,0083,0084,0085,0086,0087,0088,0089,0090,0091,0092,0093,0094,0095,0096,0097,0098,0099,0100,0101,0102,0103,0104,0105,0106,0107,0108,0109,0110,0111,0112,0113,0114,0115,0116,0117,0118,0119,0120,0121,0122,0123,0124,0125,0126,0127,0128,0129,0130,0131,0132,0133,0134,0135,0136,0137,0138,0139,0140,0141,0142,0143,0144,0145,0146,0147,0148,0149,0150,0151,0152,0153,0154,0155,0156,0157,0158,0159,0160,0161,0164,0165,0166,0167,0168,0169,0170,0171,0172,0173,0174,0175,0176,0177,0178,0179,0180,0181,0182,0183,0184,0185,0186,0187,0188,0189,0190,0191,0192,0193,0194,0195,0196,0197,0198,0199,0200,0201,0202,0203,0204,0205,0206,0207,0208,0209,0210,0211,0212,0213,0214,0215,0216,0217,0218,0219,0220,0221,0222,0223,0224,0225,0226,0227,0228,0229,0230,0231,0232,0233,0234,0235,0236,0237,0238,0239,0240,0241,0242,0243,0244,0245,0246,0247,0248,0249,0250,0251,0252,0253,0255,0256,0257,0258,0259,0261,0262,0263,0264,0265,0266,0267,0268,0269,0270,0271,0272,0273,0274,0275,0276,0277,0278,0279,0280,0281,0282,0283,0284,0285,0286,0287,0288,0289,0290,0294,0295,0296,0297,0298,0299,0300,0302,0303,0304,0305,0306,0307,0308,0309,0310,0311,0312,0313,0314,0315,0316,0317,0318,0319,0320,0321,0322,0323,0324,0326,0327,0328,0329,0330,0332,0333,0334,0335,0336,0337,0338,0339,0340,0341,0342,,9999,2001,2002,2003,2004,2005,2006,2007,2008,2009,2010,2011,5001,5002,"",
    ""SupplyBalance"": true,
    ""SupplyValidate"": false,
    ""PaidFlag"": null,
    ""VipFee"": 0.0,
    ""Validity"": 0,
    ""PresentAmt"": 0.0
  },
  {
    ""CustId"": 994323,
    ""CardTypeNo"": ""02"",
    ""CardTypeName"": ""金牌会员                      "",
    ""Upgrade"": 0.0,
    ""BranchNo"": "",,,,,,,,,,,,,,,,,,,,,,,,,,3001,3002,3003,4001,4002,4003,4004,4005,4006,4007,4008,4009,4010,4011,4012,4013,4014,4015,4016,4017,4018,4019,4020,4021,4022,4023,4024,4025,4026,4027,4028,4029,4030,4031,4032,4033,4034,4035,4036,4037,4038,4039,4040,4041,4042,4043,4044,4045,4046,4048,4049,4050,4051,4052,4053,4054,4055,4056,4057,0006,0007,1003,1004,1005,1006,1007,1008,1009,1010,1011,1012,1013,1014,1015,1016,1017,1018,1019,1020,1021,1022,1023,1024,1025,1026,1027,1028,1029,1030,1031,1032,1033,1034,1035,1036,1037,1038,1039,1040,1041,1042,1043,1044,1045,1046,1047,1048,1049,1050,1051,1052,1053,1054,1055,1056,1057,1058,1059,1060,1061,1062,1063,1064,1065,1066,1067,1068,1069,1070,1071,1072,1073,1074,1075,1076,1077,1078,1079,1080,1081,1082,1083,1084,1085,1086,1087,1088,1089,1090,1091,1092,1093,1094,1095,1096,1097,1098,1099,1100,1101,1102,1103,1104,1105,1106,1107,1108,1109,1110,1111,1112,1113,1114,1115,1116,1117,1118,1119,1120,1121,1122,1123,1124,1125,1126,1127,1128,1129,1130,1131,1132,1133,1134,1135,1136,1137,1138,1139,1140,1141,1142,1143,1144,1145,1146,1147,1148,1149,1150,1151,1152,1154,1155,1156,1157,1158,1159,1160,1161,1162,1163,1164,1165,1166,1167,1168,1169,1170,1171,1172,1173,1174,1175,1176,1177,1178,1179,1180,1181,1183,1184,1185,1186,1187,9998,0001,0002,0003,0004,0005,0011,1001,0012,0014,0008,1002,0009,0013,0010,0015,0016,0017,0018,0019,0020,0021,0022,0023,0024,0025,0026,0027,0028,0029,0030,0031,0032,0033,0034,0035,0036,0037,0038,0039,0040,0041,0042,0043,0044,0045,0046,0047,0048,0049,0050,0051,0052,0053,0054,0055,0056,0057,0058,0059,0060,0061,0062,0063,0064,0065,0066,0067,0068,0069,0070,0071,0072,0073,0074,0075,0076,0077,0078,0079,0080,0081,0082,0083,0084,0085,0086,0087,0088,0089,0090,0091,0092,0093,0094,0095,0096,0097,0098,0099,0100,0101,0102,0103,0104,0105,0106,0107,0108,0109,0110,0111,0112,0113,0114,0115,0116,0117,0118,0119,0120,0121,0122,0123,0124,0125,0126,0127,0128,0129,0130,0131,0132,0133,0134,0135,0136,0137,0138,0139,0140,0141,0142,0143,0144,0145,0146,0147,0148,0149,0150,0151,0152,0153,0154,0155,0156,0157,0158,0159,0160,0161,0164,0165,0166,0167,0168,0169,0170,0171,0172,0173,0174,0175,0176,0177,0178,0179,0180,0181,0182,0183,0184,0185,0186,0187,0188,0189,0190,0191,0192,0193,0194,0195,0196,0197,0198,0199,0200,0201,0202,0203,0204,0205,0206,0207,0208,0209,0210,0211,0212,0213,0214,0215,0216,0217,0218,0219,0220,0221,0222,0223,0224,0225,0226,0227,0228,0229,0230,0231,0232,0233,0234,0235,0236,0237,0238,0239,0240,0241,0242,0243,0244,0245,0246,0247,0248,0249,0250,0251,0252,0253,0255,0256,0257,0258,0259,0261,0262,0263,0264,0265,0266,0267,0268,0269,0270,0271,0272,0273,0274,0275,0276,0277,0278,0279,0280,0281,0282,0283,0284,0285,0286,0287,0288,0289,0290,0294,0295,0296,0297,0298,0299,0300,0302,0303,0304,0305,0306,0307,0308,0309,0310,0311,0312,0313,0314,0315,0316,0317,0318,0319,0320,0321,0322,0323,0324,0326,0327,0328,0329,0330,0332,0333,0334,0335,0336,0337,0338,0339,0340,0341,0342,,9999,2001,2002,2003,2004,2005,2006,2007,2008,2009,2010,2011,5001,5002,"",
    ""SupplyBalance"": true,
    ""SupplyValidate"": false,
    ""PaidFlag"": null,
    ""VipFee"": 0.0,
    ""Validity"": 0,
    ""PresentAmt"": 0.0
  },
  {
    ""CustId"": 994323,
    ""CardTypeNo"": ""03"",
    ""CardTypeName"": ""钻石会员                      "",
    ""Upgrade"": 0.0,
    ""BranchNo"": "",,,,,,,,,,,,,,,,,,,,,,,,,,3001,3002,3003,4001,4002,4003,4004,4005,4006,4007,4008,4009,4010,4011,4012,4013,4014,4015,4016,4017,4018,4019,4020,4021,4022,4023,4024,4025,4026,4027,4028,4029,4030,4031,4032,4033,4035,4036,4037,4038,4039,4040,4041,4042,4043,4044,4045,4046,4048,4049,4050,4051,4052,4053,4054,4055,4056,4057,0006,0007,1003,1004,1005,1006,1007,1008,1009,1010,1011,1012,1013,1014,1015,1016,1017,1018,1019,1020,1021,1022,1023,1024,1025,1026,1027,1028,1029,1030,1031,1032,1033,1034,1035,1036,1037,1038,1039,1040,1041,1042,1043,1044,1045,1046,1047,1048,1049,1050,1051,1052,1053,1054,1055,1056,1057,1058,1059,1060,1061,1062,1063,1064,1065,1066,1067,1068,1069,1070,1071,1072,1073,1074,1075,1076,1077,1078,1079,1080,1081,1082,1083,1084,1085,1086,1087,1088,1089,1090,1091,1092,1093,1094,1095,1096,1097,1098,1099,1100,1101,1102,1103,1104,1105,1106,1107,1108,1109,1110,1111,1112,1113,1114,1115,1116,1117,1118,1119,1120,1121,1122,1123,1124,1125,1126,1127,1128,1129,1130,1131,1132,1133,1134,1135,1136,1137,1138,1139,1140,1141,1142,1143,1144,1145,1146,1147,1148,1149,1150,1151,1152,1154,1155,1156,1157,1158,1159,1160,1161,1162,1163,1164,1165,1166,1167,1168,1169,1170,1171,1172,1173,1174,1175,1176,1177,1178,1179,1180,1181,1183,1184,1185,1186,1187,9998,0001,0002,0003,0004,0005,0011,1001,0012,0014,0008,1002,0009,0013,0010,0015,0016,0017,0018,0019,0020,0021,0022,0023,0024,0025,0026,0027,0028,0029,0030,0031,0032,0033,0034,0035,0036,0037,0038,0039,0040,0041,0042,0043,0044,0045,0046,0047,0048,0049,0050,0051,0052,0053,0054,0055,0056,0057,0058,0059,0060,0061,0062,0063,0064,0065,0066,0067,0068,0069,0070,0071,0072,0073,0074,0075,0076,0077,0078,0079,0080,0081,0082,0083,0084,0085,0086,0087,0088,0089,0090,0091,0092,0093,0094,0095,0096,0097,0098,0099,0100,0101,0102,0103,0104,0105,0106,0107,0108,0109,0110,0111,0112,0113,0114,0115,0116,0117,0118,0119,0120,0121,0122,0123,0124,0125,0126,0127,0128,0129,0130,0131,0132,0133,0134,0135,0136,0137,0138,0139,0140,0141,0142,0143,0144,0145,0146,0147,0148,0149,0150,0151,0152,0153,0154,0155,0156,0157,0158,0159,0160,0161,0164,0165,0166,0167,0168,0169,0170,0171,0172,0173,0174,0175,0176,0177,0178,0179,0180,0181,0182,0183,0184,0185,0186,0187,0188,0189,0190,0191,0192,0193,0194,0195,0196,0197,0198,0199,0200,0201,0202,0203,0204,0205,0206,0207,0208,0209,0210,0211,0212,0213,0214,0215,0216,0217,0218,0219,0220,0221,0222,0223,0224,0225,0226,0227,0228,0229,0230,0231,0232,0233,0234,0235,0236,0237,0238,0239,0240,0241,0242,0243,0244,0245,0246,0247,0248,0249,0250,0251,0252,0253,0255,0256,0257,0258,0259,0261,0262,0263,0264,0265,0266,0267,0268,0269,0270,0271,0272,0273,0274,0275,0276,0277,0278,0279,0280,0281,0282,0283,0284,0285,0286,0287,0288,0289,0290,0294,0295,0296,0297,0298,0299,0300,0302,0303,0304,0305,0306,0307,0308,0309,0310,0311,0312,0313,0314,0315,0316,0317,0318,0319,0320,0321,0322,0323,0324,0326,0327,0328,0329,0330,0332,0333,0334,0335,0336,0337,0338,0339,0340,0341,0342,,9999,2001,2002,2003,2004,2005,2006,2007,2008,2009,2010,2011,5001,5002,"",
    ""SupplyBalance"": true,
    ""SupplyValidate"": false,
    ""PaidFlag"": null,
    ""VipFee"": 0.0,
    ""Validity"": 0,
    ""PresentAmt"": 0.0
  }
]";

            var data = JsonHelper.JsonConvertDeserialize<List<Temp_VipType>>(strJson);
            string messageId = Guid.NewGuid().ToString("N");
            int custId = 994323;
            string branchNo = "000";
            string productionType = "18";
            MQ_VipData<Temp_VipType> mqData = new MQ_VipData<Temp_VipType>
            {
                Name = messageId,
                custid = custId,
                branchNo = branchNo,
                ProductionType = productionType,
                data = data
            };
            return mqData;
        }
    }
}

