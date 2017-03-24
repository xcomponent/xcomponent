# XComponent Testing

You can refer to this article to have an overview about [Testing Strategies in a microservices architecture](http://martinfowler.com/articles/microservice-testing/).

Your objective is to combine 3 kinds of tests:
* Unit testing: XComponent's triggered methods and XComponent's Apis can't be mocked for unit tests.
* Component testing: Thanks to XCSpy, the components/the microservices can be tested. This is a usefull tool, to be sure that the microservice correctlyy implements the required business logic.
* Integration/Non regression testing: A testing framework included in XComponent platform which is used to ensure that ensure external dependencies meet the contract expected of them or that our collection of microservices collaborate correctly to provide end-to-end business flows.

In addition to these tests, we can prototype fast:
* Using a WPF generated application
* Through a generated Swagger web page


**The objective of this article is to give more details about the last item : *Integration/Non regression testing***.

When we are working on a specific component, we can check is behaviour using XCSpy, we can also create unit tests. 
However, all this tests don't offer the guaranty that all the components, all the microservices correctly interacts each other.

How the testing framework works ?

1. Tests are described in a JSON configuration file containing:
    * The description of the events to send
    * The description of the events to receive
    * The description of the expected values

2. At the end of build of your project, we should call the xcomponent compiler *xctools* to generate a visual studio project containing the tests.

3. The tests can be integrated on your build factory. We can also script the deployment and the execution of the test environment with XComponent AC2.

JSON file format:

```json
{
    "TestProjectName": "HelloWorldTests",
    "TestedProjectName": "helloworld",
    "DefaultNamespace": "XComponent.HelloWorld.IntegrationTests",
    "AssemblyName": "XComponent.HelloWorld.IntegrationTests",
    "TargetFramework": "v4.5.1",
    "XcomponentVersion": "4.6.0-rc0240",
    "XcomponentDistribution": "community",
    "VisualStudioToolsVersion": "14.0",
    "NUnitVersion": "2.6.3",
    "NUnitTargetFramework": "v4.0",
    "TestFixtures": [
        {
		"TestFixtureName": "HelloWorldTests",
		"WindowStyle": "Hidden",
		"Microservices": [
			{
				"MicroserviceName": "helloworld-HelloMicroservice",
				"XcrPath": ".\\xcassemblies\\helloworld-HelloMicroservice.xcr",
				"StartupTimeInMs": 30000
			}
		],
		"WebSocketBridge": {
			"IsEnabled": false,
			"StartupTimeInMs": 5000,
			"Port": 443,
			"ApiPath": ""
		},
		"Apis": [
			{
				"ApiName": "helloworldApi",
				"ApiPath": ".\\xcassemblies\\"
			}
		],
		"Tests": [
			{
				"TestName": "TestSayHelloEvent",
				"Parameters": [
					{
						"Type": "string",
						"Name": "helloResponse"
					}
				],
				"Variables": [
					{
						"Type": "string",
						"Name": "userName",
						"DefaultValue": "Guest"
					},
				],
				"TestCases": [
					{
						"Values": ["\"Hello Guest\""]
					}
				],
				"Runs": [
				{
					"RunType": "SendEvent",
					"Input": {
						"MessageType": "XComponent.HelloWorld.UserObject.SayHello",
						"Message": {
							"Name": "$(userName)"
						},
						"Target": {
							"ApiName": "helloworldApi",
							"Component": "HelloWorld",
							"StateMachine": "HelloWorldManager",
						}
					},
					"TimeoutInMs": 10000,
					"Output": {
					"ExpectedInstances": [
						{
							"Source": {
								"ApiName": "helloworldApi",
								"Component": "HelloWorld",
								"StateMachine": "HelloResponse"
							},
							"PublicMemberType": "XComponent.HelloWorld.UserObject.HelloResponse",
							"Constraints": [
								{
									"PropertyPath": "instance.PublicMember.Text",
									"Operator": "==",
									"ExpectedValue": "${helloResponse}",
									"IsStringValue": true
								}
							],
					"FailureMessage": "The state machine response for user ${userName} is not valid,  expected value: ${helloResponse}"
							},
						]
					}						
				},		
		  ]
		}
    	]
        }
    ]
}
```

Once your JSON file is created, you have to call xctools to generate a Microsoft Visual Studio solution, using the following parameters:
```
XComponent.XCTools.exe -t --testconfig="HelloWorld.json" --testoutput="Integration.Test\HelloWorldTests"
```

After the buid, a Visual Studio project is generated. These tests can be executed by the build factory.

![Visual Studio test project](../Documentation/Images/tests.png)


A full example is available in the HelloWorld project [Hello World sample](../Examples/xc.helloworld/README.md).



