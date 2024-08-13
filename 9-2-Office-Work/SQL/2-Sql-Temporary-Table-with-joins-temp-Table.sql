select a.CorporateIdn, a.TripIdn, count(*) as NumCompletedStops into #temp1 
from MOBYLB_TripActuals_NA_4_0(nolock) as a
inner join MOBYLB_StopActuals_NA_4_0(nolock) as b on a.TripKey = b.TripKey
where a.TripStatus in (5,6)
group by a.CorporateIdn, a.TripIdn

select a.CorporateIdn, a.TripIdn, d.EmpNum as Driver, d.LogonID, count(*) as NumOfPlannedStops 
into #temp2 from MOBYLB_Trip_NA_4_0(nolock) as a
inner join MOBYLB_Stop_NA_4_0(nolock) as b on a.CorporateIdn = b.CorporateIdn and a.TripIdn = b.TripIdn
inner join MOBYLB_TripActuals_NA_4_0(nolock) as c on a.CorporateIdn = c.CorporateIdn and a.TripIdn = c.TripIdn
inner join MOBYLB_Driver_NA_4_0 as d on a.Driver1 = d.EmpNum
where a.Status in (5,6)
group by a.CorporateIdn, a.TripIdn, d.EmpNum, d.LogonID

select a.CorporateIdn, a.TripIdn, b.NumOfPlannedStops, a.NumCompletedStops, b.Driver, b.LogonID
from #temp1 as a left join #temp2 as b on a.CorporateIdn = b.CorporateIdn and b.TripIdn = a.TripIdn
where a.NumCompletedStops != b.NumOfPlannedStops

drop table #temp1
drop table #temp2