@echo off
  set TmpFile="%temp%.\tmp.vbs"
  echo> %TmpFile% n=Now
  echo>>%TmpFile% With WScript
  echo>>%TmpFile% .Echo "set m1="   + monthname(month(n), true)
  echo>>%TmpFile% .Echo "set m2="   + monthname(month(n), false)
  echo>>%TmpFile% .Echo "set woy="  + CStr(datepart("ww", n))
  echo>>%TmpFile% .Echo "set year=" + CStr(Year(n))
  echo>>%TmpFile% .Echo "set yr="   + Right(Year(n),2)
  echo>>%TmpFile% .Echo "set month="+ Right(100+Month(n),2)
  echo>>%TmpFile% .Echo "set day="  + Right(100+Day(n),2)
  echo>>%TmpFile% .Echo "set hour=" + Right(100+Hour(n),2)
  echo>>%TmpFile% .Echo "set min="  + Right(100+Minute(n),2)
  echo>>%TmpFile% .Echo "set sec="  + Right(100+Second(n),2)
  echo>>%TmpFile% .Echo "set dow="  + WeekDayName(Weekday(n),1)
  echo>>%TmpFile% .Echo "set dow2=" + WeekDayName(Weekday(n))
  echo>>%TmpFile% .Echo "set iso="  + CStr(1 + Int(n-2) mod 7)
  echo>>%TmpFile% .Echo "set iso2=" + CStr(Weekday(n,2))
  echo>>%TmpFile% .Echo "set dayofyear=" + CStr(DatePart("y",n))
  echo>>%TmpFile% End With
  cscript //nologo "%temp%.\tmp.vbs" > "%temp%.\tmp.bat"
  call "%temp%.\tmp.bat"
  del  "%temp%.\tmp.bat"
  del  %TmpFile%
  set TmpFile=
  set stamp=%year%-%month%-%day%.%hour%_%min%_%sec%
  set buildNumber=%yr%.%woy%.%dayofyear%.%hour%%min%	
  if not "%~1"=="" goto :EOF
 
  echo The year  is "%year%" or "%yr%"
  echo The month is "%month%" "%m1%" "%m2%"
  echo The day   is "%day%" "%dow%" "%dow2%"
  echo The day of year  is  "%dayofyear%"
  echo.
  echo ISO8601 Day-Of-Week number is "%iso%" and week of year is: "%woy%"
 
 msbuild MultimodeEnum.csproj /p:MyBuildNo=%buildNumber%
  pause
