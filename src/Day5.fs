module Day5

open Utils
open System.IO

let data = File.ReadAllLines("../../../inputs/day5.txt") |> Array.toList

let solution rev input =
    let rawStacks, rawProcedures = List.splitAt (List.findIndex ((=) "") input) input

    let isNotFourth n = n % 4 <> 0

    let stacks =
        rawStacks[.. List.length rawStacks - 2]
        |> List.map (
            String.filteri (fun i _ -> isNotFourth (i + 1))
            >> Seq.toList
            >> List.ofSeq
            >> List.chunkBySize 3
            >> List.map (List.item 1)
        )
        |> List.transpose
        |> List.map (List.filter ((<>) ' '))

    let procedures =
        rawProcedures[1..]
        |> List.map (
            String.split " "
            >> (function
            | [ _; x; _; y; _; z ] -> [ int x; int y; int z ]
            | _ -> invalidArg "list" "list doesn't match expected format")
        )

    let runOnStacks (acc: char list list) (procedure: int list) =
        match procedure with
        | [ move; from; dest ] ->
            let fromIndex = from - 1
            let destIndex = dest - 1

            acc
            |> List.updateAt fromIndex (List.skip move acc[fromIndex])
            |> List.updateAt
                destIndex
                (List.append (List.take move acc[fromIndex] |> if rev then List.rev else id) (acc[destIndex]))
        | _ -> invalidArg "list" "list doesn't match expected format"

    let resultStacks = List.fold runOnStacks stacks procedures

    resultStacks |> List.map List.head |> System.String.Concat

printfn "%A" (solution true data)
printfn "%A" (solution false data)
