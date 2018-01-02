@rem GENERATE PACKAGE BATCH FILE
if [%1]==[] (
	mkdir "../generatedPackage"
	C:\Sources\xcomponent.net\generated\XCStudio\XCBuild\xcbuild.exe --compilationmode=Debug --generatePackage -env=Dev -output="../generatedPackage" -project="../Calculator_Model.xcml"
) else (
	C:\Sources\xcomponent.net\generated\XCStudio\XCBuild\xcbuild.exe --compilationmode=Debug --generatePackage -env=Dev -output=%1 -project="../Calculator_Model.xcml"
)