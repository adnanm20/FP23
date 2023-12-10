namespace DBStore
open Microsoft.Data.Sqlite
module Connection =
  let private makeConnStr (filename: string) =
    "Data Source = ./" + filename
  let connection = new SqliteConnection(makeConnStr "inventory.db")

module Types =
  type Item = {
    Id:int64;
    Name:string;
    Qty:int64;
    Px:double
  }

module Queries = 
  let conn = Connection.connection
  conn.Open()
  let CreateSchema () = 
    let cmd = conn.CreateCommand()
    cmd.CommandText <- """
      DROP TABLE IF EXISTS items;
      CREATE TABLE items (
        Id INTEGER PRIMARY KEY,
        Name varchar(255) NOT NULL,
        Qty INTEGER NOT NULL,
        Px REAL NOT NULL
      );
      """
    cmd.ExecuteNonQuery() |> ignore
    ()
  let insertItem (item:Types.Item) =
    let cmd = conn.CreateCommand()
    cmd.CommandText <- """
      INSERT INTO items
      (Name, Qty, Px) VALUES (@name, @qty, @px)
      """
    cmd.Parameters.AddWithValue("@name", item.Name) |> ignore
    cmd.Parameters.AddWithValue("@qty", item.Qty) |> ignore
    cmd.Parameters.AddWithValue("@px", item.Px) |> ignore
    cmd.ExecuteNonQuery() |> ignore
    ()
  
  let selectItem (id:int64) =
    let cmd = conn.CreateCommand()
    cmd.CommandText <- """
      SELECT * FROM items WHERE Id = @id
      """
    cmd.Parameters.AddWithValue("@id", id) |> ignore
    let reader = cmd.ExecuteReader()
    reader.Read() |> ignore
    let id = reader.GetInt64(0)
    let name = reader.GetString(1)
    let qty = reader.GetInt64(2)
    let px = reader.GetDouble(3)
    let item:Types.Item = {Id = id; Name = name; Qty = qty; Px = px}
    item