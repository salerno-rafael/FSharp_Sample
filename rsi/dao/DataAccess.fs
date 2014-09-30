module DataAccess

open System.Data
open System.Configuration
open System.Collections.Generic
open Oracle.DataAccess.Client
open System
open EnvironmentConfiguration

let private getConnection (connectionName : string) = 
    let element = new EnvironmentSettings()
    element.GetSettingElementEnvironment(connectionName).url

let private openConnection (connectionName : string) = 
    let connection = new OracleConnection(getConnection connectionName)
    connection.Open()
    connection

let private openConnectionReader (connectionName : string, query : string) = 
    let cmd = openConnection(connectionName).CreateCommand(CommandText = query, CommandType = CommandType.Text)
    let reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
    reader

let private reader (connectionName : string, query : string) = openConnectionReader (connectionName, query)

let deleteQuery (connectionName : string, query : string) = openConnectionReader (connectionName, query)
let updateQuery (connectionName : string, query : string) = openConnectionReader (connectionName, query)
let insertQuery (connectionName : string, query : string) = openConnectionReader (connectionName, query)

let private readLine (read : OracleDataReader) = 
    let list = new List<string>()
    for i = 0 to read.FieldCount - 1 do
        list.Add(read.GetValue(i).ToString())
    list

let executeQuery (connectionName : string, query : string) = 
    let result = new List<List<string>>()
    let read = reader (connectionName, query)
    while read.Read() do
        result.Add(readLine read)
    result
