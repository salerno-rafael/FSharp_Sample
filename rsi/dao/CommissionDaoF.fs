module CommissionDaoF

open System.Data
open System
open System.Collections.Generic

let private connection = "conn.rsi"
let private today = DateTime.Now.ToString("ddMMMyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"))

let commissionPending (userId : string, commissionId : string) = 
    DataAccess.insertQuery 
        (connection, 
         "insert into commission_pending values(id_commission_pending_seq.NEXTVAL," + commissionId + "," + userId 
         + ",TO_DATE('" + today + "','DD-MON-YY'))")

let commissionApproved (userId : string, commissionId) = 
    DataAccess.insertQuery 
        (connection, 
         "insert into commission_approved values(id_commission_approved_seq.NEXTVAL," + commissionId + "," + userId 
         + ",TO_DATE('" + today + "','DD-MON-YY'))")

let getStatusList = 
    let rows = Seq.toList ( DataAccess.executeQuery (connection, "select distinct status from commission"))
    List.map (fun (row:List<string> ) -> int row.[0]) rows

