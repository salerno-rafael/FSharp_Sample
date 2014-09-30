module UserViewModel

type UserViewModel(id:string,name : string, user : string, email : string, approver : string) = 
    member x.Id = id
    member x.Name = name
    member x.User = user
    member x.Email = email
    member x.Approver = approver

let adapterUserToViewModel (user : UserBusiness.User) = 
    UserViewModel(user.Id,user.Name, user.User, user.Email, user.Approver)

let adapterUserToListViewModel (userList : list<UserBusiness.User>) = 
    userList |> List.map (fun i -> UserViewModel(i.Id,i.Name, i.User, i.Email, i.Approver))
