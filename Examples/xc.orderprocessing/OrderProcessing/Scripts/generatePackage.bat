@rem GENERATE PACKAGE BATCH FILE
if [%1]==[] (
	mkdir "../generatedPackage"
	XComponent.XCTools.exe --Debug --generatePackage -env=Dev -output="../generatedPackage" -project="../OrderProcessing_Model.xcml"
) else (
	XComponent.XCTools.exe --Debug --generatePackage -env=Dev -output=%1 -project="../OrderProcessing_Model.xcml"
)