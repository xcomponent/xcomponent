using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XComponent.Communication.Serialization.Json;
using NUnit.Framework;
using XCClientAPICommon.ApiExtensions;
using XCClientAPICommon.Client;
using XComponent.helloworld.helloworldApi;


namespace XComponent.HelloWorld.IntegrationTests
{
    [TestFixture]
    public class HelloWorldTestsTestFixture
    {
        private Process _testhelloworld_HelloMicroserviceRuntimeProcess;
        

        private bool _startWebSocketBridge = false;
        private Process _webSocketBridgeProcess = null;

        [TestFixtureSetUp]
        public void SetUp()
        {
            

            if (_startWebSocketBridge)
            {
                _webSocketBridgeProcess = StartWebSocketBridge(@"Resources\XCWebSocketBridge\xcwebsocketbridge.exe", "443", 5000, @"Resources\XCWebSocketBridge\Api", ProcessWindowStyle.Hidden);
            }

            _testhelloworld_HelloMicroserviceRuntimeProcess = StartRuntime(@"Resources\XCRuntime\xcruntime.exe", @"Resources\Microservices\helloworld-HelloMicroservice\helloworld-HelloMicroservice.xcr", 30000, ProcessWindowStyle.Hidden);
            
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            StringBuilder errorsBuilder = new StringBuilder();

            if (_testhelloworld_HelloMicroserviceRuntimeProcess != null)
            {
                try
                {
                    CloseProcess(_testhelloworld_HelloMicroserviceRuntimeProcess);
                }
                catch (Exception e)
                {
                    errorsBuilder.AppendLine(e.ToString());
                }
            }
            

            if (_startWebSocketBridge && _webSocketBridgeProcess != null)
            {
                try
                {
                    CloseProcess(_webSocketBridgeProcess);
                }
                catch (Exception e)
                {
                    errorsBuilder.AppendLine(e.ToString());
                }
            }

            

            string errors = errorsBuilder.ToString();
            if (!string.IsNullOrEmpty(errors))
            {
                Assert.Fail(errors);
            }
        }

        private static void CloseProcess(Process process)
        {
            try
            {
                process.Kill();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("The process [pid {0}] has already exited", process.Id);
            }
            catch (Win32Exception)
            {
                Assert.Fail("The process [pid {0}][{1} {2}] {3}", process.Id, process.StartInfo.FileName, process.StartInfo.Arguments, "could not be terminated");
            }
        }

        [Test]
        [TestCase("Hello Guest")]
        
        public void TestSayHelloEvent(string helloResponse)
        {
            ApiWrapper<helloworldApi> testhelloworldApi = null;
            

            try
            {
                testhelloworldApi = new ApiWrapper<helloworldApi>();

                ClientApiOptions clientApiOptionshelloworldApi = new ClientApiOptions();
                if (!testhelloworldApi.Init(testhelloworldApi.Api.DefaultXcApiFileName, clientApiOptionshelloworldApi))
                {
                    AssertReport("helloworldApi", testhelloworldApi.Report);
                    return;
                }
                

                string userName = "Guest";
                

                #region SendEvent Run
                {
                    List<ManualResetEvent> events = new List<ManualResetEvent>();

                    var run1ExpectationStatus0 = new TestExpectationStatus(1, 1);
                    var run1Update0Event = new ManualResetEvent(false);
                    events.Add(run1Update0Event);

					Action<XComponent.helloworld.helloworldApi.HelloWorld.HelloResponseInstance> run1Update0HelloResponseStateMachineOnInstanceUpdated  = delegate(XComponent.helloworld.helloworldApi.HelloWorld.HelloResponseInstance instance)
                    {
						if(1 == 0)
						{
							Assert.Fail(string.Format("The state machine response for user {0} is not valid,  expected value: {1}", userName, helloResponse) + ". Expected 0 update but one was received");
						}

                        if (!run1ExpectationStatus0.IsSatisfied)
                        {
							int satisfiedConstraintCount = 0;
							var currentConstraintStatus = new List<TestConstraintStatus>();

							var actualValue0 = instance.PublicMember.Text;
							bool isSatisfied0 = actualValue0 == string.Format("{0}", helloResponse);
							if (isSatisfied0)
							{
								satisfiedConstraintCount++;
							}
							var constraintInstance0 = new TestConstraintStatus(string.Format(@"instance.PublicMember.Text == {0}", string.Format("{0}", helloResponse)), actualValue0, isSatisfied0);
							currentConstraintStatus.Add(constraintInstance0);
						
							

							if (satisfiedConstraintCount > run1ExpectationStatus0.SatisfiedConstraintCount || run1ExpectationStatus0.SatisfiedConstraintCount == 0)
							{
								run1ExpectationStatus0.SetStatus(currentConstraintStatus.ToArray());
							}
						}
                        if (run1ExpectationStatus0.IsSatisfied)
                        {
                            
                            
                            run1Update0Event.Set();
                        }
                    };

                    testhelloworldApi.Api.HelloWorld_Component.HelloResponse_StateMachine.InstanceUpdated += run1Update0HelloResponseStateMachineOnInstanceUpdated;

					if(1 == 0)
					{
                        run1Update0Event.Set();
					}
                    

                    var sentEventString = @"{
  ""Name"": ""$(userName)""
}";
                    var sentEvent =
                        JObjectWrapper.Parse(sentEventString).ToObject<XComponent.HelloWorld.UserObject.SayHello>();
                    testhelloworldApi.Api.HelloWorld_Component.HelloWorldManager_StateMachine.SendEvent(sentEvent,
                        ex => Assert.Fail(ex.ToString()));

                    var eventsArray = events.ToArray();
                    bool allUpdatesReceived;
                    if (eventsArray.Length > 0)
                    {
                        allUpdatesReceived = WaitHandle.WaitAll(eventsArray, 10000);
                    }
                    else
                    {
                        allUpdatesReceived = true;
                    }

                    if (!allUpdatesReceived)
                    {
                        StringBuilder failureMessage = new StringBuilder();
                        if (!run1Update0Event.WaitOne(0) && run1ExpectationStatus0.UpdateCount > 0)
                        {
                            failureMessage.Append(string.Format("The state machine response for user {0} is not valid,  expected value: {1}", userName, helloResponse)).Append(". ");
                            failureMessage.AppendFormat("Received {0} instance(s) out of {1} expected", run1ExpectationStatus0.ReceivedUpdateCount, run1ExpectationStatus0.UpdateCount)
								.AppendLine();
                            if (run1ExpectationStatus0.ConstraintStatus == null || run1ExpectationStatus0.ConstraintStatus.Length == 0)
                            {
                                failureMessage.AppendLine("Could not receive the expected InstanceUpdated event(s):");
								failureMessage.Append("\tinstance.PublicMember.Text == ").Append(string.Format("{0}", helloResponse)).AppendLine();
								
                            }
                            else
                            {
								failureMessage.AppendLine("The following constraints failed validation:");
                                foreach (var constraint in run1ExpectationStatus0.ConstraintStatus)
                                {
                                    if (!constraint.IsSatisfied)
                                    {
                                        failureMessage.AppendFormat("\tExpected {0}, Actual {1}", constraint.Description, constraint.ActualValue).AppendLine();
                                    }
                                }
                            }
							failureMessage.AppendLine();
                        }
                        
                        Assert.Fail(failureMessage.ToString());
                    }

                    testhelloworldApi.Api.HelloWorld_Component.HelloResponse_StateMachine.InstanceUpdated -= run1Update0HelloResponseStateMachineOnInstanceUpdated;
                    
                    
                }
                #endregion

                
            }
            finally
            {
                if (testhelloworldApi != null)
                {
                    testhelloworldApi.Dispose();
                }
                
            }
        }
        

        private Process StartWebSocketBridge(string bridgePath, string bridgePort, int startuTimeInMs, string apiPath, ProcessWindowStyle windowStyle)
        {
            var rootedApiPath = GetRootedPath(apiPath);
            ProcessStartInfo info = new ProcessStartInfo(bridgePath, string.Format("--port={0} --apipath={1}", bridgePort, rootedApiPath));
            return StartProcess(startuTimeInMs, windowStyle, info);
        }

        private Process StartRuntime(string runtimePath, string xcrPath, int startupTimeInMs, ProcessWindowStyle windowStyle)
        {
            var rootedXcrPath = GetRootedPath(xcrPath);
            ProcessStartInfo info = new ProcessStartInfo(runtimePath, rootedXcrPath);
            return StartProcess(startupTimeInMs, windowStyle, info);
        }

        private static Process StartProcess(int startupTimeInMs, ProcessWindowStyle windowStyle, ProcessStartInfo info)
        {
            info.WindowStyle = windowStyle;
            if (windowStyle == ProcessWindowStyle.Hidden)
            {
                info.CreateNoWindow = true;
            }
            info.UseShellExecute = false;
            info.RedirectStandardError = true;
            info.RedirectStandardOutput = true;

            var process = new Process();

            process.StartInfo = info;
    
            var commonFormat = "[pid {0}] {1}";
            DataReceivedEventHandler consoleDataHandler = (sender, args) => Console.WriteLine(commonFormat, process.Id, args.Data);
            process.ErrorDataReceived += consoleDataHandler;
            process.OutputDataReceived += consoleDataHandler;

            StringBuilder outputCollector = new StringBuilder();
            DataReceivedEventHandler dataHandler = (sender, args) => outputCollector.AppendFormat(commonFormat, process.Id, args.Data).AppendLine();
            process.ErrorDataReceived += dataHandler;
            process.OutputDataReceived += dataHandler;

            bool processStarted = process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
            if (!processStarted)
            {
                Assert.Fail("The process {0} {1} did not start", info.FileName, info.Arguments);
            }

            bool hasExited = process.WaitForExit(startupTimeInMs);

            if (hasExited)
            {
                process.WaitForExit();

                process.CancelOutputRead();
                process.CancelErrorRead();
                Assert.Fail(
                    "The process {0} {1} abnormally exited with code {3} before the expected startup time {2}ms{4}{5}",
                    info.FileName, info.Arguments, startupTimeInMs, process.ExitCode, Environment.NewLine, outputCollector);
            }
            else
            {
                process.ErrorDataReceived -= dataHandler;
                process.OutputDataReceived -= dataHandler;
            }

            return process;
        }

        private static string GetRootedPath(string path)
        {
            string rootedXcrPath = path;
            if (!System.IO.Path.IsPathRooted(path))
            {
                rootedXcrPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            }
            return rootedXcrPath;
        }

        private static void RunScript(string command, int timeoutInMs, ProcessWindowStyle windowStyle)
        {
            using (var process = new Process())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", "/c" + command);
                startInfo.WindowStyle = windowStyle;

                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;

                process.StartInfo = startInfo;

                bool scriptStarted = process.Start();
                if (!scriptStarted)
                {
                    Assert.Fail("The script {0} {1} did not start", command, timeoutInMs);
                }

                using (var combinedStream = new StringWriter())
                using (Task<bool> processWaiter = Task.Factory.StartNew(() => process.WaitForExit(timeoutInMs)))
                using (Task outputReader = Task.Factory.StartNew(AppendLinesFunc, Tuple.Create(combinedStream, "[INFO]", process.StandardOutput)))
                using (Task errorReader = Task.Factory.StartNew(AppendLinesFunc, Tuple.Create(combinedStream, "[ERROR]", process.StandardError)))
                {
                    bool waitResult = processWaiter.Result;

                    if (!waitResult)
                    {
                        process.Kill();
                    }

                    Task.WaitAll(outputReader, errorReader);
                    string combinedOutput = combinedStream.ToString();

                    if (!waitResult)
                    {
                        Assert.Fail(
                            "The execution of the script {0} did not complete after the expected timeout {1}ms{2}Script output:{3}",
                            command, timeoutInMs, Environment.NewLine, combinedOutput);
                    }

                    int exitCode = process.ExitCode;
                    if (exitCode != 0)
                    {
                        Assert.Fail("The execution of the script {0} returned the error code {1}.{2}Script output:{3}",
                            command, exitCode, Environment.NewLine, combinedOutput);
                    }
                }
            }
        }

        private static void AppendLinesFunc(object packedParams)
        {
            // Unpack params from tuple object
            var paramsTuple = (Tuple<StringWriter, string, StreamReader>)packedParams;
            StringWriter writer = paramsTuple.Item1;
            string marker = paramsTuple.Item2;
            StreamReader reader = paramsTuple.Item3;

            // Collect output from reader
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Append to writer is critical section in order to prevent concurrent
                // writes from stdout and stderr to interfere with each other.
                lock (writer)
                {
                    writer.WriteLine("{0} {1}: {2}", marker, DateTime.Now, line);
                }
            }
        }

        private static void AssertReport(string apiName, InitReport report)
        {
            if (!string.IsNullOrEmpty(report.Message))
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("Init failed for api {0} : {1}", apiName, report.Message).AppendLine();

                foreach (var componentName in report.ComponentsInitSucceeded)
                {
                    builder.AppendFormat("Init succeeded : {0}", componentName).AppendLine();
                }
                foreach (var componentName in report.ComponentsInitFailed)
                {
                    builder.AppendFormat("Init failed : {0}", componentName).AppendLine();
                }

                Assert.Fail(builder.ToString());
            }
        }
    }
}
