@echo off
echo.
echo # Remove unwanted solution temporary build files.
echo.
SET /p QUES=# Have you created setup of the new build yet? [Y/N] : 
IF "%QUES%" == "Y" (
	rd /s /q "%~dp0Pokemon Sprite Inserter\bin" && echo # Done deleting "bin".
	rd /s /q "%~dp0Pokemon Sprite Inserter\obj" && echo # Done deleting "obj".
	echo.
) ELSE (
	echo.
	echo # Please create setup of new build asap and run me again!
	echo.
)
pause