@rem EXPORT INTERFACE BATCH FILE
if [%1]==[] (
	mkdir "../exportedInterfaces"
	C:\Sources\xcomponent.net\generated\XCStudio\XCBuild\xcbuild.exe --compilationmode=Debug --exportInterface -env=Dev -output="../exportedInterfaces" -project="../Calculator_Model.xcml"
) else (
	C:\Sources\xcomponent.net\generated\XCStudio\XCBuild\xcbuild.exe --compilationmode=Debug --exportInterface -env=Dev -output=%1 -project="../Calculator_Model.xcml"
)