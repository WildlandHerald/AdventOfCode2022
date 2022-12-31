module Day4

open Utils
open System.IO

let data = File.ReadAllLines("../../../inputs/day4.txt") |> Array.toList

let rangesContain ranges =
    match ranges with
    | [ [ x1; y1 ]; [ x2; y2 ] ] -> (x1 >= x2 && y1 <= y2) || (x1 <= x2 && y1 >= y2)
    | _ -> invalidArg "ranges" "ranges were provided in incorrect format"

let solution test input =
    input
    |> List.filter (
        String.split ","
        >> List.map (String.split "-")
        >> List.map (List.map int)
        >> test
    )
    |> List.length

printfn "%A" (solution rangesContain data)

let rangesOverlap ranges =
    match ranges with
    | [ [ x1; y1 ]; [ x2; y2 ] ] -> x1 <= y2 && y1 >= x2
    | _ -> invalidArg "ranges" "ranges were provided in incorrect format"

printfn "%A" (solution rangesOverlap data)
