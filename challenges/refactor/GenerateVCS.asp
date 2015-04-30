<!--#INCLUDE virtual="/global/functions/ADOVBS.INC"-->
<%
	'declare the variables
	dim mlngEventID, DST_NBR, EMP_NBR, calDate, seq, calYear, calMon, calDay, calEndYear, calEndMon, calEndDay, calEndDate, startTime, endTime, startDateTime, endDateTime, beginDate, endDate, title, dsTime, rc, objRS, strvCalendar

		'Since we can't include comments in the vCalendar code these are vCalendar items we are not using (dsTime has a new value too)
		'"DAYLIGHT:TRUE;" & dsTime & vbCrlf & _
		'"TZ:-06" & vbCrlf & _

	'get the incoming querystring variable, this is what makes this event unique
	mlngEventID = Request.QueryString("id")

	'make sure the querystring did return a variable value
	if mlngEventID = "" then
		Response.Write "No Event ID found. Unable to proceed."
		Response.End
	else
		if len(mlngEventID) = 17 then
			mlngEventID = "000" & mlngEventID
		elseif len(mlngEventID) = 18 then
			mlngEventID = "00" & mlngEventID
		elseif len(mlngEventID) = 19 then
			mlngEventID = "0" & mlngEventID
		end if 
		DST_NBR = left(mlngEventID,4)
		EMP_NBR = mid(mlngEventID,5,6)
		calDate = mid(mlngEventID,11,8)
		seq = right(mlngEventID,2)
		calYear = left(calDate,4)
		calEndYear = left(calDate,4)
		calMon = mid(calDate,5,2)
		calEndMon = mid(calDate,5,2)
		calDay = right(calDate,2)
		calEndDay = right(calDate,2)
		calStartDate = calDate
		title = Request.QueryString("type")
		'The time values passed in do not include seconds so we are adding those
		startTime = Request.QueryString("start") & "00"
		if startTime >= "240000" then
			startTime = "00" & right(startTime,4)
		end if

		'This sets the event starting date/time
		startDateTime = calStartDate & startTime

		'This adjusts the end time for all day events
		if Request.QueryString("end") = "0000" or Request.QueryString("end") = "2400" then
			endTime = "235900"
		else
			endTime = Request.QueryString("end") & "00"
		end if

		'This adjusts the end time if the event ends between midnight and 1 am (in the database that would be 24xxxx, for the calendar it must be 00xxxx)
		if endTime > "240000" then
			endTime = "00" & right(endTime,4)
		end if

		'This changes day for the end date if the end time is after midnight
		if endTime < startTime then
			calEndDay = calEndDay + 01
		end if

		'This changes the month (and the year if necessary) if the new end day is greater than the last day of any given month
		select case calEndMon
			case 01
				if calEndDay > 31 then
					calEndDay = "0" & calEndDay - 31
					calEndMon = "02"
				end if
			case 02
				if calEndYear <> 2012 or calEndYear <> 2016 or calEndYear <> 2020 or calEndYear <> 2024 then
					if calEndDay > 28 then
						calEndDay = "0" & calEndDay - 28
						calEndMon = "03"
					end if
				elseif calEndYear = 2012 or calEndYear = 2016 or calEndYear = 2020 or calEndYear = 2024 then
					if calEndDay > 29 then
						calEndDay = "0" & calEndDay - 29
						calEndMon = "03"
					end if
				end if
			case 03
				if calEndDay > 31 then
					calEndDay = "0" & calEndDay - 31
					calEndMon = "04"
				end if
			case 04
				if calEndDay > 30 then
					calEndDay = "0" & calEndDay - 30
					calEndMon = "05"
				end if
			case 05
				if calEndDay > 31 then
					calEndDay = "0" & calEndDay - 31
					calEndMon = "06"
				end if
			case 06
				if calEndDay > 30 then
					calEndDay = "0" & calEndDay - 30
					calEndMon = "07"
				end if
			case 07
				if calEndDay > 31 then
					calEndDay = "0" & calEndDay - 31
					calEndMon = "08"
				end if
			case 08
				if calEndDay > 31 then
					calEndDay = "0" & calEndDay - 31
					calEndMon = "09"
				end if
			case 09
				if calEndDay > 30 then
					calEndDay = "0" & calEndDay - 30
					calEndMon = "10"
				end if
			case 10
				if calEndDay > 31 then
					calEndDay = "0" & calEndDay - 31
					calEndMon = "11"
				end if
			case 11
				if calEndDay > 30 then
					calEndDay = "0" & calEndDay - 30
					calEndMon = "12"
				end if
			case 12
				if calEndDay > 31 then
					calEndDay = "0" & calEndDay - 31
					calEndMon = "01"
					calEndYear = calEndYear + 01
				end if
		end select
		calEndDate = calEndYear & calEndMon & calEndDay  

		'This sets the end date/time
		endDateTime = calEndDate & endTime
	
		beginDate = left(calStartDate,4) & "-" & mid(calStartDate,5,2) & "-" & right(calStartDate,2) & " " & left(startTime,2) & ":" & mid(startTime,3,2) & ":" & right(startTime,2)
		endDate = left(calEndDate,4) & "-" & mid(calEndDate,5,2) & "-" & right(calEndDate,2) & " " & left(endTime,2) & ":" & mid(endTime,3,2) & ":" & right(endTime,2)

		'THESE ARE THE SCHEDULED BEGINNING AND ENDING DATES FOR DAYLIGHT SAVINGS TIME AS OF 2012
		select case left(calDate,4)
			case 2012
'        dsTime = "-07;20120311T025959;20121104T010000;CST;CDT"
				if calDate & startTime >= 20120311025950 and calDate & endTime <= 20121104010000 then
					dsTime = +05
				else
					dsTime = +06
				end if
			case 2013
'        dsTime = "-07;20130310T025959;20131103T010000;CST;CDT"
				if calDate & startTime >= 20130310025950 and calDate & endTime <= 20131103010000 then
					dsTime = +05
				else
					dsTime = +06
				end if
			case 2014
'        dsTime = "-07;20140309T025959;20141102T010000;CST;CDT"
				if calDate & startTime >= 20140309025950 and calDate & endTime <= 20141102010000 then
					dsTime = +05
				else
					dsTime = +06
				end if
			case 2015
'        dsTime = "-07;20150308T025959;20151101T010000;CST;CDT"
				if calDate & startTime >= 20150308025950 and calDate & endTime <= 20151101010000 then
					dsTime = +05
				else
					dsTime = +06
				end if
			case 2016
'        dsTime = "-07;20160313T025959;20161106T010000;CST;CDT"
				if calDate & startTime >= 20160313025950 and calDate & endTime <= 20161106010000 then
					dsTime = +05
				else
					dsTime = +06
				end if
			case 2017
'        dsTime = "-07;20170312T025959;20171105T010000;CST;CDT"
				if calDate & startTime >= 20170312025950 and calDate & endTime <= 20171105010000 then
					dsTime = +05
				else
					dsTime = +06
				end if
			case 2018
'        dsTime = "-07;20180311T025959;20181104T010000;CST;CDT"
				if calDate & startTime >= 20180311025950 and calDate & endTime <= 20181104010000 then
					dsTime = +05
				else
					dsTime = +06
				end if
			case 2019
'        dsTime = "-07;20190310T025959;20191103T010000;CST;CDT"
				if calDate & startTime >= 20190310025950 and calDate & endTime <= 20191103010000 then
					dsTime = +05
				else
					dsTime = +06
				end if
			case 2020
'        dsTime = "-07;20200308T025959;20201101T010000;CST;CDT"
				if calDate & startTime >= 20200308025950 and calDate & endTime <= 20201101010000 then
					dsTime = +05
				else
					dsTime = +06
				end if
			case 2021
'        dsTime = "-07;20210314T025959;20211107T010000;CST;CDT"
				if calDate & startTime >= 20210314025950 and calDate & endTime <= 20211107010000 then
					dsTime = +05
				else
					dsTime = +06
				end if
		end select

	end if


	'Create a recordset for this event
	set objRS = Server.CreateObject("ADODB.Recordset")
	call objRS.Fields.Append("Event_ID",adVarChar,20)
	call objRS.Fields.Append("Event_Begin_Date",adVarChar,19)
	call objRS.Fields.Append("Event_End_Date",adVarChar,19)
	call objRS.Fields.Append("Event_Title",adVarChar,44)
	objRS.Fields.Refresh
	objRS.Open

	objRS.AddNew
	objRS("Event_ID") = mlngEventID
	objRS("Event_Begin_Date") = beginDate
	objRS("Event_End_Date") = endDate
	objRS("Event_Title") = title
	objRS.Update


	strvCalendar = BuildVCalendar(objRS)

	Response.ContentType = "text/x-vCalendar"
	Response.AddHeader "Content-Disposition", "filename=Event" & mlngEventID & ".vcs;"
	Response.Write strvCalendar
	Response.End

	function BuildVCalendar(byval objRS)
		dim dtStart, dtEnd, strSubject, strLocation, strDesc, time_zone, dtDuration
		time_zone = dsTime
		dtStart = DateAdd("h",time_zone, objRS("Event_Begin_Date"))
		dtEnd = DateAdd("h",time_zone, objRS("Event_End_Date"))
		
		dtStart = Year(dtStart) & _
		Right("00" & Month(dtStart), 2) & _
		Right("00" & Day(dtStart), 2) & _
		"T" & _
		Right("00" & Hour(dtStart), 2) & _
		Right("00" & Minute(dtStart), 2) & _
		Right("00" & Second(dtStart), 2) & _
		"Z"
		
		dtEnd = Year(dtEnd) & _
		Right("00" & Month(dtEnd), 2) & _
		Right("00" & Day(dtEnd), 2) & _
		"T" & _
		Right("00" & Hour(dtEnd), 2) & _
		Right("00" & Minute(dtEnd), 2) & _
		Right("00" & Second(dtEnd), 2) & _
		"Z"  

		
		strSubject = objRS("Event_Title")
		strLocation = ""
		'Currently we are not providing a description for the event but that could change.
		strDesc = ""
		'   VCALENDAR CODE STARTS HERE
		BuildVCalendar = _
		"BEGIN:VCALENDAR" & vbCrlf & _
		"VERSION:1.0" & vbCrlf & _ 
		"BEGIN:VEVENT" & vbCrlf & _
		"DTSTART:" & dtStart & vbCrlf & _
		"DTEND:" & dtEnd & vbCrlf & _
		"SUMMARY;ENCODING=QUOTED-PRINTABLE:"  & strSubject & vbCrlf & _
		"LOCATION;ENCODING=QUOTED-PRINTABLE:" & strLocation & vbCrlf & _
		"UID:" & objRS("Event_ID") & dtStart & strSubject & vbCrlf & _
		"PRIORITY:3" & vbCrlf & _
		"TRANSP:0" & vbCrlf & _
		"End:VEVENT" & vbCrlf & _
		"End:VCALENDAR" & vbCrlf
	end function
%>
 
