<Query Kind="FSharpProgram" />

type Result = 
    | Success of int
    | Failure of string
    | Error of Exception

let inputs = [ "Food"; "Foo"; Unchecked.defaultof<String>; ]

let complexOp (input: string) = 
    try
        if input.Length % 2 = 0 then
            Success input.Length
        else
            Failure "Length is odd."
    with 
    | ex -> Error ex

let processResult r = 
    match r with
    | Success s -> printfn "Even length: %d" s
    | Failure f -> printfn "%s" f
    | Error e -> printfn "%A" e
      
let main () = 
    let results = 
        inputs 
        |> Seq.map complexOp
    
    results |> Seq.iter processResult
    
main ()