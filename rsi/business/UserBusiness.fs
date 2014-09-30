module UserBusiness

open System.Collections.Generic
open UserDao

type User(id:string,name : string, user : string, email : string, approver : string) = 
    member x.Id = id
    member x.Name = name
    member x.User = user
    member x.Email = email
    member x.Approver = approver

let listUser =  List.map (fun (i:UserEntity) -> User(i.Id,i.Name, i.User, i.Email, i.Approver)) UserDao.listUser

let listApprover = List.map (fun (i:UserEntity) -> User(i.Id,i.Name, i.User, i.Email, i.Approver)) UserDao.listApprover 

let getUser (user:string) = UserDao.getUser user

let getUserByName (name:string) = UserDao.getUserByName name

let getUserAdapted (i:UserEntity) =  User(i.Id,i.Name, i.User, i.Email, i.Approver)

let getLoggedUser (user:string) = getUserAdapted(getUser(user))

let isApprover (user:string) = 
    match getUser(user).Approver with
        | "Y" -> true
        | "N" -> false
        | _ -> false
