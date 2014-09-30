module UserDao

open System.Collections.Generic

type UserEntity(id : string, name : string, user : string, email : string, approver : string) = 
    member x.Id = id
    member x.Name = name
    member x.User = user
    member x.Email = email
    member x.Approver = approver

let private connection = "conn.rsi"

let private validateSimpleReturn(users:UserEntity list) = 
    if users.IsEmpty  then UserEntity("","","","","") else users.Head

let private getRows(rows: List<string> list) = 
     validateSimpleReturn(List.map (fun (row : List<string>) -> UserEntity(row.[0], row.[1], row.[2], row.[3], row.[4])) rows)

let listUser : list<UserEntity> = 
    let rows = Seq.toList (DataAccess.executeQuery (connection, "select * from user_rsi"))
    List.map (fun (i : List<string>) -> UserEntity(i.[0], i.[1], i.[2], i.[3], i.[4])) rows

let listApprover : list<UserEntity> = 
    let rows = Seq.toList (DataAccess.executeQuery (connection, "select * from user_rsi where approver = 'Y'"))
    List.map (fun (i : List<string>) -> UserEntity(i.[0], i.[1], i.[2], i.[3], i.[4])) rows

let getUser (user : string) = 
    getRows(Seq.toList (DataAccess.executeQuery (connection, "select * from user_rsi where user_name ='" + user + "'")))

let getUserByName (name : string) = 
    getRows(Seq.toList (DataAccess.executeQuery (connection, "select * from user_rsi where name ='" + name + "'")))