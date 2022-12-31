module Day3

open Utils
open System.IO

let data = File.ReadAllLines("../../../inputs/day3.txt") |> Array.toList

let weights =
    List.append [ 'a' .. 'z' ] [ 'A' .. 'Z' ]
    |> List.mapi (fun i e -> e, i + 1)
    |> dict

let weight c = weights[c]

let solve =
    List.map (
        String.halves
        >> Tuple2.map String.toSet
        >> Tuple2.map2 Set.intersect
        >> Set.toSeq
        >> Seq.head
        >> weight
    )
    >> List.sum

printfn "%A" (solve data)

let solve2 =
    List.chunkBySize 3
    >> List.map (List.map String.toSet >> Set.intersectMany >> Seq.head >> weight)
    >> List.sum

printfn "%A" (solve2 data)
