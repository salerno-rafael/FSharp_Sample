module CommissionBusinessF

let commissionPendingLog (userName : string, commissionId:string) = 
    CommissionDaoF.commissionPending (UserDao.getUser(userName).Id,commissionId)

let commissionApprovedLog (userName : string,commissionId:string) = 
    CommissionDaoF.commissionApproved (UserDao.getUser(userName).Id,commissionId)

let getStatusList = 
    List.map (fun (i:int) -> (RsiStatusF.status.[i], i)) CommissionDaoF.getStatusList
    