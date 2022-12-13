module Day1

open Utils
open System.IO

let data = File.ReadAllText "inputs/day1.txt"

let showPart1 list =
    printfn "Part 1: %A" (List.max list)
    list

let result =
    data
    |> String.split "\n\n"
    |> List.map (String.split "\n" >> List.map int >> List.sum)
    |> List.sortDescending
    |> showPart1
    |> List.take 3
    |> List.sum

printfn "Part 2: %A" result
